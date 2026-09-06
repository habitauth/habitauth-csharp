# Habit Auth C# (.NET) Client SDK & Complete Example Solutions

Official C# client integration library and full source code examples (WinForms Form1 + Main Page, Console application) for **Habit Auth** enterprise software licensing and anti-tamper security.

[![Website](https://img.shields.io/badge/Official_Website-habitauth.com-6366f1.svg)](https://habitauth.com)
[![Documentation](https://img.shields.io/badge/Documentation-habitauth.com/docs-10b981.svg)](https://habitauth.com)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

---

## Solution Structure

This repository includes a complete Visual Studio solution with two fully functional projects:

```
habitauth-csharp/
├── HabitAuth.sln                         # Visual Studio Solution file
├── HabitAuth-WinForms-Example/           # Complete Windows Forms Application
│   ├── HabitAuth-WinForms-Example.csproj
│   ├── Form1.cs                          # Login & Register GUI Form (Form1)
│   ├── Form1.Designer.cs
│   ├── Form1.resx
│   ├── Main.cs                           # Main Dashboard Page (shown after login)
│   ├── Main.Designer.cs
│   ├── Main.resx
│   ├── HabitAuth.cs                      # Core Habit Auth SDK
│   ├── Program.cs
│   ├── App.config
│   └── Properties/
│       └── AssemblyInfo.cs
└── HabitAuth-Console-Example/            # Interactive Console Application
    ├── HabitAuth-Console-Example.csproj
    ├── HabitAuth.cs                      # Core Habit Auth SDK
    └── Program.cs                        # Interactive menu (Login, Register, Key, HWID)
```

---

## Features

- **Zero Third-Party Dependencies:** Works out of the box on standard .NET BCL libraries without external NuGet packages.
- **Cross-Framework Compatibility:** Compatible with .NET Framework 4.5 through 4.8, .NET Core 3.1, .NET 5, 6, 7, 8, 9, 10, and Unity Mono.
- **Hardware-ID (HWID) Locking:** Automatically generates unique SHA-256 machine hardware fingerprints.
- **WinForms GUI Included:** Pre-built modern dark theme Login window (`Form1`) and Post-Login Dashboard (`Main`).
- **Remote Killswitch & Heartbeat:** Background session verification ensuring immediate termination if a license is revoked.

---

## Quick Setup

1. Open `HabitAuth.sln` in Visual Studio 2019 / 2022.
2. Open `Form1.cs` or `Program.cs` and replace the configuration constants with your credentials from [habitauth.com](https://habitauth.com):

```csharp
private const string AppId = "your_application_id_here";
private const string AppSecret = "your_application_secret_here";
private const string Version = "1.0.0";
```

3. Build and Run!

---

## Code Example

```csharp
using HabitAuthSDK;

// 1. Initialize
HabitAuth.Setup("app_c0049143710d4e5c", "sec_...", "1.0.0");
var init = await HabitAuth.InitializeAsync();

// 2. Login
var login = await HabitAuth.LoginAsync("username", "password");
if (login.Success)
{
    Console.WriteLine("Welcome, " + HabitAuth.User.Username);
    Console.WriteLine("Subscription: " + HabitAuth.User.Subscription);
}
```

---

(C) 2026 Habit Auth. All rights reserved.
