using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Logger
{
    public class Log
    {
        public int iStepNumber { get; set; }
        public string sStepName { get; set; }
        public bool bVerification { get; set; }
        public bool bError { get; set; }
        public bool bScenario { get; set; }
    }
}
