using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Logger
{
    public class Logger
    {

        private static List<Log> lSteps = new List<Log>();

        public static void AddLog(string sLogEntry, bool bVerification = false, bool bError = false)
        {
            Log log = new Log();
            log.sStepName = sLogEntry;
            log.bVerification = bVerification;
            log.bError = bError;

            if (lSteps.Count == 0)
            {
                log.iStepNumber = 1;
            }
            else
            {
                log.iStepNumber = lSteps.Where(x => !x.bVerification).Count() + 1;
            }
            lSteps.Add(log);
        }

        public static void CreateLog()
        {
            string sValue = "";
            int iVerification = 1;
            foreach (Log step in lSteps)
            {
                if (!step.bVerification)
                {
                    iVerification = 1;
                }
                if (step.bError)
                {
                    sValue += "     *";
                    sValue += "   " + (step.iStepNumber - 1) + "." + iVerification + " " + "Error occurred: " + step.sStepName + Environment.NewLine;
                }
                else if (step.bVerification)
                {
                    sValue += "     •";
                    sValue += "   " + (step.iStepNumber - 1) + "." + iVerification + " " + step.sStepName + Environment.NewLine;
                    iVerification++;
                }
                else
                {
                    sValue += "• ";
                    sValue += step.iStepNumber.ToString() + ". " + step.sStepName + Environment.NewLine;
                }
            }

            string sPath = Path.Combine(new string[]
            {
                TestContext.Parameters["LogPath"],
                DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt"
            });

            if (!File.Exists(sPath))
            {
                using (StreamWriter sw = new StreamWriter(sPath))
                    sw.WriteLine(sValue);
            }
        }
    }
}
