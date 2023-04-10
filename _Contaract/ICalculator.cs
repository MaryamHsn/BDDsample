using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contaract
{
    public interface ICalculator//:IDisposable
    {
         int FirstNumber { get; set; }
         int SecondNumber { get; set; }
        int Add();
    }
}
