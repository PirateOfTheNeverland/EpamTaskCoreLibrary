using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EpamTaskTestSuite.Tests
{
    [SetUpFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        public void Init()
        {
            Console.WriteLine("Start test run");
            EpamTaskCoreLibrary.ActionProvider.Start();
            EpamTaskCoreLibrary.ActionProvider.NavigateToBase();
        }

        [OneTimeTearDown]
        public void TestCleanup()
        {
            EpamTaskCoreLibrary.ActionProvider.Stop();
            Console.WriteLine("Test run finished");
        }
    }
}
