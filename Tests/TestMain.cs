using PageObjectBase.Commons;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCsharpSeleniumHomework.Tests
{
    public class TestMain : BaseTest
    {
        static void Main(string[] args)
        {
            Log.Info("Test Main to test Jenkins");
            Log.Info("ConfigurationManager.AppSettings[GlobalConstants.BROWSER].ToUpper(): " + ConfigurationManager.AppSettings[GlobalConstants.BROWSER].ToUpper());
            Console.WriteLine("Console: ConfigurationManager.AppSettings[GlobalConstants.BROWSER].ToUpper(): " + ConfigurationManager.AppSettings[GlobalConstants.BROWSER].ToUpper());
        }
    }
}
