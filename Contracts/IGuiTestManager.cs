using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGuiTestManager : IDisposable
    {
        IMainForm MainForm { get; }
        ICalculator Calculator { get; }
    }
}
