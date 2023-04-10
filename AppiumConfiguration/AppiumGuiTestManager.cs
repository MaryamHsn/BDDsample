using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts; 

namespace AppiumConfiguration
{
    public class AppiumGuiTestManager : IAppiumGuiTestManager
    {
        private readonly Lazy<MainForm> mainForm;
        private readonly Lazy<Calculator> calculator;

        public IMainForm MainForm => mainForm.Value;
        public ICalculator Calculator => calculator.Value;

        public AppiumGuiTestManager(IConfigurationManager configurationManager)
        {
            mainForm = new Lazy<MainForm>(() => new MainForm(configurationManager));
            calculator = new Lazy<Calculator>(() => new Calculator(configurationManager));
        }

        public void SwitchToMainForm()
        {
            //AppiumDriverWrapper.WindowsDriver.SwitchTo().Window(mainForm.Value.WindowHandle);
        }

        public void Dispose()
        {
            // MainForm.Dispose();
        }
    }
}
