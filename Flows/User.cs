using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Flows
{
    public class User
    {
        #region Fields

        private readonly IGuiTestManager guiTestManager;

        #endregion

        #region Properties
        // public bool IsUserSeeLoginForm => guiTestManager.LoginForm.IsDisplayed;

        #endregion

        #region Constructors

        public User(IAppiumGuiTestManager guiTestManager)
        {
            this.guiTestManager = guiTestManager;
        }

        #endregion

        #region Public Methods

        public void RunApp()
        {
            guiTestManager.MainForm.Run();
        }

        public void ClickOnSayHelloButton()
        {
            guiTestManager.MainForm.ClickOnButton();
            guiTestManager.MainForm.ClickOnButton();
        }

        #endregion
    }
}
