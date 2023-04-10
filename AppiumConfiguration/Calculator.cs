using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Contracts;

namespace AppiumConfiguration
{
    public class Calculator : ICalculator
    {
        private readonly IConfigurationManager configurationManager;

        public Calculator(IConfigurationManager configurationManager)
        {
            this.configurationManager = configurationManager;
        }

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
        //public void Dispose()
        //{
        //    Calculator.Dispose();
        //}
    }
}
