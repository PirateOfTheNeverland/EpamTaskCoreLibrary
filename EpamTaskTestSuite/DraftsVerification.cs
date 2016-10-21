using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace EpamTaskTestSuite
{
    [TestFixture]
    public class DraftsVerification
    {
        [SetUp]
        public void SetUp()
        {
            EpamTaskCoreLibrary.ActionProvider.Start();
            EpamTaskCoreLibrary.ActionProvider.NavigateToBase();
            
        }

        [TearDown]
        public void TearDown()
        {
            EpamTaskCoreLibrary.ActionProvider.Stop();
        }

        [Test]
        [TestCase("luckythirteen", "l1u2c3k4y5", "mail.ru")]
        public void Login(string login, string password, string extension)
        {
            // Precon 1. Login
            EpamTaskCoreLibrary.MainPage.Login(login, password, "");
            // Step 2. Verify that you were successfully logged in
            Assert.AreEqual(login + '@' + extension, EpamTaskCoreLibrary.MainPage.GetCurrentUserEmail());
        }

    }
}
