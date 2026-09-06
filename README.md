# Habit Auth C# (.NET) Client SDK

Official zero-dependency C# client library for Habit Auth enterprise software licensing and anti-tamper security.

[![Website](https://img.shields.io/badge/Official_Website-habitauth.com-0284c7?style=flat-square)](https://habitauth.com)
[![Documentation](https://img.shields.io/badge/Developer_Docs-habitauth.com%2Fdocs-2563eb?style=flat-square)](https://habitauth.com/docs)
[![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat-square)](LICENSE)

---

## Features

- **Zero External NuGet Dependencies:** Runs on standard .NET BCL libraries without external third-party packages.
- **Broad Runtime Compatibility:** Full backward and forward compatibility across .NET Framework 4.5 through 4.8, .NET Core 3.1, .NET 5, 6, 7, 8, 9, 10, Unity, and Mono.
- **Dual Cryptographic Verification:** Verifies both RFC 8032 Ed25519 asymmetric signatures and symmetric HMAC-SHA256 digests.
- **Anti-Replay Protection:** Enforces dynamic client-server clock drift synchronization with strict anti-replay validation.
- **Integrated HWID Engine:** Deep multi-attribute hardware identification with spoof detection.
- **Automated Telemetry:** Background thread heartbeat monitoring with remote instant process termination.

---

## Quick Integration

### 1. Add `HabitAuth.cs` to Your Project

Copy `HabitAuth.cs` directly into your Visual Studio project (Windows Forms, WPF, Console, or Unity).

### 2. Initialization & Authentication

```csharp
using System;
using HabitAuth;

namespace MyApp
{
    class Program
    {
        // 1. Configure HabitAuth credentials
        public static HabitAuthApp Auth = new HabitAuthApp(
            name: "YOUR_APP_NAME",
            ownerid: "YOUR_APP_ID",
            secret: "YOUR_APP_SECRET",
            version: "1.0",
            publicKey: "YOUR_ED25519_PUBLIC_KEY"
        );

        static void Main()
        {
            // 2. Establish cryptographically verified session
            if (!Auth.init())
            {
                Console.WriteLine("Init failed: " + Auth.response.message);
                return;
            }

            // 3. User Login
            if (Auth.login("demo_user", "password123"))
            {
                Console.WriteLine("Login successful! Welcome " + Auth.user.username);
                Console.WriteLine("Expiration: " + Auth.user.expires_at);

                // 4. Start background heartbeat telemetry (every 30s)
                Auth.start_heartbeat(30);
            }
            else
            {
                Console.WriteLine("Login failed: " + Auth.response.message);
            }
        }
    }
}
```

---

## Available Methods

| Method | Parameters | Description |
| :--- | :--- | :--- |
| `init()` | `token = null` | Performs initial anti-tamper handshake, syncs clock offset, and retrieves app configuration. |
| `login()` | `username, password` | Authenticates an existing user account with HWID lock enforcement. |
| `register()` | `username, password, licenseKey` | Creates a new user account bound to an unused license key. |
| `license()` | `licenseKey` | Instant 1-key direct license login without credentials. |
| `reset_hwid()` | `username` | Self-service hardware reset subject to administrator cooldown rules. |
| `start_heartbeat()` | `intervalSeconds = 30` | Initiates background telemetry thread. Automatically terminates client if session is revoked. |
| `stop_heartbeat()` | None | Gracefully stops the telemetry heartbeat thread. |

---

## Documentation & Support

- **Full Documentation:** [https://habitauth.com/docs](https://habitauth.com/docs)
- **Official Portal:** [https://habitauth.com](https://habitauth.com)
- **YouTube:** [https://youtube.com/@habitauth](https://youtube.com/@habitauth)
- **Technical Support:** support@habitauth.com
