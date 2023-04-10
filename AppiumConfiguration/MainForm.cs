using System;
using System.Linq;
using System.Threading.Tasks; 
using Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;

namespace AppiumConfiguration
{
    public class MainForm : IMainForm
    {
        private Lazy<IWebElement> btn;
        private IWebElement SayHelloButton => btn.Value;

        private readonly IConfigurationManager configurationManager;

        private const string mainFormAutomationId = "Form1";

        private readonly Lazy<WindowsElement> mainFormWindow;
        public string WindowHandle { get; private set; }


        public MainForm(IConfigurationManager configurationManager)
        {
            this.configurationManager = configurationManager;

            mainFormWindow = new Lazy<WindowsElement>(() =>
                findMainFormWindowsElement().Result);
            btn = new Lazy<IWebElement>(() => mainFormWindow.Value.FindElementByAccessibilityId("btn"));
            //Load();

        }


        #region methods
        //public void Load()
        //{
        //    btn = new Lazy<IWebElement>(() =>
        //        AppiumDriverWrapper.WindowsDriver.FindElementByAccessibilityId(fileToolBarAutomationId).FindElementByName(newProjectToolBarItemName));

        //    openProjectToolBarItem = new Lazy<IWebElement>(() =>
        //    {
        //        By.Name(openProjectToolBarItemName).WaitUtilFindElements();
        //        return AppiumDriverWrapper.WindowsDriver.FindElementByAccessibilityId(fileToolBarAutomationId).FindElementsByName(openProjectToolBarItemName).Last();
        //    });

        //    serverExplorerToolBarItem = new Lazy<AppiumWebElement>(() =>
        //    {
        //        By.Name(serverExplorerToolBarItemName).WaitUtilFindElements();
        //        return AppiumDriverWrapper.WindowsDriver.FindElementByName(serverExplorerToolBarItemName);
        //    });
        //    projectExplorerToolBarItem = new Lazy<AppiumWebElement>(() =>
        //    {
        //        By.Name(projectExplorerToolBarItemName).WaitUtilFindElements();
        //        return AppiumDriverWrapper.WindowsDriver.FindElementByName(projectExplorerToolBarItemName);
        //    });

        //    fileMenu = new Lazy<AppiumWebElement>(() => AppiumDriverWrapper.WindowsDriver.FindElementByAccessibilityId(mainMenuAutomationId)
        //        .FindElementByName(fileMenuName));



        //    projectMenu = new Lazy<IWebElement>(() =>
        //        AppiumDriverWrapper.WindowsDriver.FindElementByAccessibilityId(mainMenuAutomationId)
        //            .GetAllElements().First(
        //                f => f.Key == "MainMenu")
        //            .Value.First().GetAllElements().Single(
        //                f => f.Key == "Project").Value.Last());


        //    //projectMenu = new Lazy<AppiumWebElement>(() =>
        //    //    AppiumDriverWrapper.WindowsDriver.FindElementByAccessibilityId(mainMenuAutomationId)
        //    //        .FindElementByName("Publish..."));

        //    //projectMenu = new Lazy<AppiumWebElement>(() =>
        //    //AppiumDriverWrapper.WindowsDriver.FindElementByAccessibilityId(mainMenuAutomationId)
        //    //.FindElementByTagName(""));
        //}
        private async Task<WindowsElement> findMainFormWindowsElement()
        {
            AppiumDriverWrapper.Setup(configurationManager);

            WindowHandle = AppiumDriverWrapper.WindowsDriver.WindowHandles.First();

            AppiumDriverWrapper.WindowsDriver.SwitchTo().Window(WindowHandle);

            return AppiumDriverWrapper.WindowsDriver.FindElementByAccessibilityId(mainFormAutomationId);
        }

        public bool Run()
        {
            return mainFormWindow.Value != null;
        }

        public void ClickOnButton()
        {
            SayHelloButton.Click();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
#endregion
    }
}
