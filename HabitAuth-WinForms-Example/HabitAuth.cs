using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HabitAuthSDK
{
    public class UserData
    {
        public string Username { get; set; } = string.Empty;
        public string Subscription { get; set; } = "free";
        public long ExpiresAt { get; set; } = 0;
        public string Hwid { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public long CreatedAt { get; set; } = 0;
        public bool IsOnline { get; set; } = false;
    }

    public class AppData
    {
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = "1.0.0";
        public string LatestVersion { get; set; } = "1.0.0";
        public string DownloadUrl { get; set; } = string.Empty;
        public string Status { get; set; } = "active";
    }

    public class ResponseResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }

    public static class HabitAuth
    {
        private static string _appId = string.Empty;
        private static string _appSecret = string.Empty;
        private static string _version = "1.0.0";
        private static string _baseUrl = "https://habitauth.com/api/v1";
        private static readonly HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(15) };

        public static UserData User { get; private set; } = new UserData();
        public static AppData App { get; private set; } = new AppData();
        public static bool IsInitialized { get; private set; } = false;

        public static void Setup(string appId, string appSecret, string version = "1.0.0", string baseUrl = "https://habitauth.com/api/v1")
        {
            _appId = appId;
            _appSecret = appSecret;
            _version = version;
            _baseUrl = baseUrl.TrimEnd('/');
        }

        public static string GetHardwareId()
        {
            try
            {
                string raw = $"{Environment.MachineName}-{Environment.UserName}-{Environment.ProcessorCount}-{Environment.OSVersion}";
                using (var sha = SHA256.Create())
                {
                    byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(raw));
                    return Convert.ToHexString(bytes).ToLowerInvariant();
                }
            }
            catch
            {
                return "hwid-" + Guid.NewGuid().ToString("N").Substring(0, 16);
            }
        }

        public static async Task<ResponseResult> InitializeAsync()
        {
            try
            {
                var payload = new
                {
                    app_id = _appId,
                    app_secret = _appSecret,
                    version = _version
                };

                var response = await PostJsonAsync("/client/init", payload);
                if (response.Success)
                {
                    IsInitialized = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseResult { Success = false, Message = ex.Message, Code = "NETWORK_ERROR" };
            }
        }

        public static async Task<ResponseResult> LoginAsync(string username, string password)
        {
            try
            {
                var payload = new
                {
                    app_id = _appId,
                    username = username.Trim(),
                    password = password,
                    hwid = GetHardwareId(),
                    sid = "SID-" + Environment.UserName
                };

                return await PostJsonAsync("/client/login", payload);
            }
            catch (Exception ex)
            {
                return new ResponseResult { Success = false, Message = ex.Message, Code = "NETWORK_ERROR" };
            }
        }

        public static async Task<ResponseResult> RegisterAsync(string username, string password, string licenseKey)
        {
            try
            {
                var payload = new
                {
                    app_id = _appId,
                    username = username.Trim(),
                    password = password,
                    license_key = licenseKey.Trim(),
                    hwid = GetHardwareId(),
                    sid = "SID-" + Environment.UserName
                };

                return await PostJsonAsync("/client/register", payload);
            }
            catch (Exception ex)
            {
                return new ResponseResult { Success = false, Message = ex.Message, Code = "NETWORK_ERROR" };
            }
        }

        public static async Task<ResponseResult> LicenseLoginAsync(string licenseKey)
        {
            try
            {
                var payload = new
                {
                    app_id = _appId,
                    license_key = licenseKey.Trim(),
                    hwid = GetHardwareId(),
                    sid = "SID-" + Environment.UserName
                };

                return await PostJsonAsync("/client/license-login", payload);
            }
            catch (Exception ex)
            {
                return new ResponseResult { Success = false, Message = ex.Message, Code = "NETWORK_ERROR" };
            }
        }

        public static async Task<ResponseResult> ResetHwidAsync(string username, string password)
        {
            try
            {
                var payload = new
                {
                    app_id = _appId,
                    username = username.Trim(),
                    password = password
                };

                return await PostJsonAsync("/client/reset-hwid", payload);
            }
            catch (Exception ex)
            {
                return new ResponseResult { Success = false, Message = ex.Message, Code = "NETWORK_ERROR" };
            }
        }

        public static async Task<bool> HeartbeatAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(User.Token)) return false;
                var payload = new
                {
                    app_id = _appId,
                    token = User.Token,
                    hwid = GetHardwareId()
                };

                var res = await PostJsonAsync("/client/heartbeat", payload);
                return res.Success;
            }
            catch
            {
                return false;
            }
        }

        private static async Task<ResponseResult> PostJsonAsync(string path, object data)
        {
            string json = JsonSerializer.Serialize(data);
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await _httpClient.PostAsync(_baseUrl + path, content);
                string responseBody = await response.Content.ReadAsStringAsync();

                using (var doc = JsonDocument.Parse(responseBody))
                {
                    var root = doc.RootElement;
                    bool success = root.TryGetProperty("success", out var s) && s.GetBoolean();
                    string message = root.TryGetProperty("message", out var m) ? m.GetString() ?? "" : "";
                    string code = root.TryGetProperty("code", out var c) ? c.GetString() ?? "" : "";

                    if (success)
                    {
                        if (root.TryGetProperty("token", out var tok))
                        {
                            User.Token = tok.GetString() ?? "";
                        }
                        if (root.TryGetProperty("user", out var usr))
                        {
                            if (usr.TryGetProperty("username", out var u)) User.Username = u.GetString() ?? "";
                            if (usr.TryGetProperty("hwid", out var h)) User.Hwid = h.GetString() ?? "";
                            if (usr.TryGetProperty("expires_at", out var exp)) User.ExpiresAt = exp.GetInt64();
                            if (usr.TryGetProperty("subscription", out var sub)) User.Subscription = sub.GetString() ?? "default";
                        }
                        if (root.TryGetProperty("app", out var ap))
                        {
                            if (ap.TryGetProperty("app_name", out var an)) App.Name = an.GetString() ?? "";
                            if (ap.TryGetProperty("version", out var v)) App.Version = v.GetString() ?? "1.0.0";
                            if (ap.TryGetProperty("latest_version", out var lv)) App.LatestVersion = lv.GetString() ?? "1.0.0";
                            if (ap.TryGetProperty("download_url", out var du)) App.DownloadUrl = du.GetString() ?? "";
                        }
                    }

                    return new ResponseResult
                    {
                        Success = success,
                        Message = message,
                        Code = code
                    };
                }
            }
        }
    }
}
