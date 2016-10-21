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
            // Step 1. Login
            EpamTaskCoreLibrary.Pages.MainPage.Login(login, password, "");
            // Step 2. Verify that you were successfully logged in
            Assert.AreEqual(login + '@' + extension, EpamTaskCoreLibrary.Pages.MainPage.GetCurrentUserEmail());
            // Step 3. Go to composing new letter
            EpamTaskCoreLibrary.Pages.ComposeLetter.Open();
            // Step 4. Fill in required fields
            EpamTaskCoreLibrary.Pages.ComposeLetter.WriteLetter("ivanov@mailtest.ru", "", "", "Subject of letter", "text-text-text");
        }

    }
}
