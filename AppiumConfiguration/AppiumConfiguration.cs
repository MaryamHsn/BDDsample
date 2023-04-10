using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumConfiguration
{
    public class AppiumConfiguration
    {
        public static WindowsDriver<WindowsElement> Session { get; private set; }
         

        public static void Setup()
        {
            if (Session != null)
                return;



            var applicationExecutableFilePath = ConfigurationManager.AppSettings["ApplicationExecutablePath"];

            Directory.Exists(applicationExecutableFilePath).Should().BeTrue();


            var applicationExecutableFileName = string.Join(@"\", new[]
            {
                applicationExecutableFilePath,
                ConfigurationManager.AppSettings["ApplicationExecutableFileName"],
            });

            File.Exists(applicationExecutableFileName).Should().BeTrue();

            var applicationExecutableFileInfo = new FileInfo(applicationExecutableFileName);

            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", applicationExecutableFileInfo.FullName);
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");

            Session = new WindowsDriver<WindowsElement>(new Uri(ConfigurationManager.AppSettings["WindowsApplicationDriverUrl"]),
                appiumOptions);

            //Assert.NotNull(Session);
        }

        public static void TearDown()
        {

        }
    }
}
