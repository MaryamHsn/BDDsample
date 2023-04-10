using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contaract
{
    public interface IAppiumGuiTestManager : IGuiTestManager
    {
        void SwitchToMainForm();
    }
} 