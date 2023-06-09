using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Allure.Commons;
namespace ProyectoFinalSpectFlow
{
    [Binding]

    
    public class Hooks
    {
       public static  AllureLifecycle allure = AllureLifecycle.Instance;
        [BeforeTestRun]
        public static void BeforeTest()
        {
            allure.CleanupResultDirectory();
        }
    }
}
