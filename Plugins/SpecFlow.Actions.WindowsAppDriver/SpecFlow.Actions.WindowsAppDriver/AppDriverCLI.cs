﻿using SpecFlow.Actions.WindowsAppDriver.Configuration;
using System;
using System.Diagnostics;

namespace SpecFlow.Actions.WindowsAppDriver
{
    public class AppDriverCli : IAppDriverCli
    {
        private readonly IWindowsAppDriverConfiguration _windowsAppDriverConfiguration;

        private Process? _appDriverProcess;

        public AppDriverCli(IWindowsAppDriverConfiguration windowsAppDriverConfiguration)
        {
            _windowsAppDriverConfiguration = windowsAppDriverConfiguration;
        }

        /// <summary>
        /// Starts the WindowsAppDriver.exe process
        /// </summary>
        public void Start()
        {
            _appDriverProcess = Process.Start(_windowsAppDriverConfiguration.WindowsAppDriverPath ?? Environment.GetEnvironmentVariable("WINDOWS_APP_DRIVER_FILE_PATH"));
        }

        /// <summary>
        /// Disposes the WindowsAppDriver.exe process
        /// </summary>
        public void Dispose()
        {
            _appDriverProcess?.Kill();
        }
    }
}