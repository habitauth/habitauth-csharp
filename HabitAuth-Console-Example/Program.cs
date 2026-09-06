using System;
using System.Threading.Tasks;
using HabitAuthSDK;

namespace HabitAuthConsole
{
    internal class Program
    {
        private const string AppId = "app_c0049143710d4e5c";
        private const string AppSecret = "sec_0000000000000000";
        private const string Version = "1.0.0";

        static async Task Main(string[] args)
        {
            Console.Title = "Habit Auth - Console Client";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
=====================================================
   HABIT AUTH - ENTERPRISE CLIENT LICENSING
   High Performance Authentication & Hardware Lock
=====================================================");
            Console.ResetColor();

            Console.WriteLine("[*] Connecting to Habit Auth...");
            HabitAuth.Setup(AppId, AppSecret, Version);

            var initResult = await HabitAuth.InitializeAsync();
            if (!initResult.Success)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[-] Initialization failed: " + initResult.Message);
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[+] Connected to Habit Auth.");
            Console.ResetColor();
            Console.WriteLine("[*] Hardware ID: " + HabitAuth.GetHardwareId());
            Console.WriteLine();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("[1] Login with Username & Password");
                Console.WriteLine("[2] Register with License Key");
                Console.WriteLine("[3] Login with License Key Only");
                Console.WriteLine("[4] Reset HWID");
                Console.WriteLine("[5] Exit");
                Console.WriteLine("---------------------------------------------");
                Console.ResetColor();
                Console.Write("Select an option [1-5]: ");

                string choice = Console.ReadLine()?.Trim() ?? "";

                if (choice == "1")
                {
                    Console.Write("Username: ");
                    string user = Console.ReadLine()?.Trim() ?? "";
                    Console.Write("Password: ");
                    string pass = Console.ReadLine() ?? "";

                    Console.WriteLine("[*] Authenticating...");
                    var res = await HabitAuth.LoginAsync(user, pass);
                    if (res.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[+] Login successful!");
                        Console.WriteLine("    Username: " + HabitAuth.User.Username);
                        Console.WriteLine("    Subscription: " + HabitAuth.User.Subscription);
                        Console.WriteLine("    Expiry: " + (HabitAuth.User.ExpiresAt == 0 ? "Lifetime" : HabitAuth.User.ExpiresAt.ToString()));
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[-] Error: " + res.Message);
                        Console.ResetColor();
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Username: ");
                    string user = Console.ReadLine()?.Trim() ?? "";
                    Console.Write("Password: ");
                    string pass = Console.ReadLine() ?? "";
                    Console.Write("License Key: ");
                    string key = Console.ReadLine()?.Trim() ?? "";

                    Console.WriteLine("[*] Registering...");
                    var res = await HabitAuth.RegisterAsync(user, pass, key);
                    if (res.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[+] Account registered successfully! You can now log in.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[-] Error: " + res.Message);
                        Console.ResetColor();
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("License Key: ");
                    string key = Console.ReadLine()?.Trim() ?? "";

                    Console.WriteLine("[*] Verifying license...");
                    var res = await HabitAuth.LicenseLoginAsync(key);
                    if (res.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[+] License verified successfully!");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[-] Error: " + res.Message);
                        Console.ResetColor();
                    }
                }
                else if (choice == "4")
                {
                    Console.Write("Username: ");
                    string user = Console.ReadLine()?.Trim() ?? "";
                    Console.Write("Password: ");
                    string pass = Console.ReadLine() ?? "";

                    Console.WriteLine("[*] Resetting HWID...");
                    var res = await HabitAuth.ResetHwidAsync(user, pass);
                    if (res.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[+] HWID reset successfully! You can now log in from this machine.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[-] Error: " + res.Message);
                        Console.ResetColor();
                    }
                }
                else if (choice == "5")
                {
                    return;
                }
            }

            Console.WriteLine("\n[+] Press any key to exit...");
            Console.ReadKey();
        }
    }
}
