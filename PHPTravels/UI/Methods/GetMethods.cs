using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Methods
{
    public class GetMethods
    {
        public static string GetText(IWebElement element)
        {
            try
            {
                return element.Text;
            }
            catch (Exception)
            {
                Logger.Logger.AddLog($"Error occured while getting the element text");
                throw new Exception($"Error occured while getting the element text");
            }

        }

        public static string GetAttributeValue(IWebElement element, string sAttribute = "value")
        {
            try
            {
                return element.GetAttribute(sAttribute);
            }
            catch (Exception)
            {
                Logger.Logger.AddLog($"Error occured while getting the attribute value: {sAttribute}");
                throw new Exception($"Error occured while getting the attribute value: {sAttribute}");
            }
        }
    }
}
