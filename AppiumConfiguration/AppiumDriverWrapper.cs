using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace AppiumConfiguration
{
    internal static class AppiumDriverWrapper
    {
        public static WindowsDriver<WindowsElement> WindowsDriver { get; private set; }

        public static void Setup(IConfigurationManager configurationManager)
        {
            if (WindowsDriver != null)
                return;

            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", createApplicationExecutableFileInfo(configurationManager).FullName);
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");

            WindowsDriver = new WindowsDriver<WindowsElement>(new Uri(configurationManager.WindowsApplicationDriverUrl),
                 appiumOptions);

            if (WindowsDriver == null)
                throw new ApplicationException("Appium Windows Driver in not run properly.");
        }

        private static FileInfo createApplicationExecutableFileInfo(IConfigurationManager configurationManager)
        {
            var applicationExecutableFilePath = configurationManager.ApplicationExecutablePath;

            if (!Directory.Exists(applicationExecutableFilePath))
                throw new ApplicationException($"{applicationExecutableFilePath} is not exist.");

            var applicationExecutableFileName = string.Join(@"\", new[]
            {
                applicationExecutableFilePath,
                configurationManager.ApplicationExecutableFileName,
            });

            if (!File.Exists(applicationExecutableFileName))
                throw new ApplicationException($"{applicationExecutableFileName} is not exist.");

            var applicationExecutableFileInfo = new FileInfo(applicationExecutableFileName);
            return applicationExecutableFileInfo;
        }

        public static void TearDown()
        {
            if (WindowsDriver == null)
                return;

            var windowHandles = WindowsDriver.WindowHandles.ToList();
            windowHandles.Reverse();

            Debug.WriteLine($"windowHandles Count in TearDown: {windowHandles.Count}");

            foreach (var windowHandle in windowHandles)
            {
                WindowsDriver.SwitchTo().Window(windowHandle);
                WindowsDriver.CloseApp();
            }

            WindowsDriver.Quit();
            WindowsDriver = null;
        }

        public static Actions CreateActions()
        {
            return new Actions(WindowsDriver);
        }

        public static void SendKeys(params string[] keys)
        {
            var actions = CreateActions();

            foreach (var key in keys)
                actions.SendKeys(key);

            actions.Perform();
        }
    }
}
