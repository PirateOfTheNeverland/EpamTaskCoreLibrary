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
            Console.WriteLine("Run tests");
        }

        [OneTimeTearDown]
        public void TestCleanup()
        {
            Console.WriteLine("Test run finished");
        }
    }
}
