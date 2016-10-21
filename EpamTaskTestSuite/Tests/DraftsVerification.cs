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
            // Precon 1. Login
            //EpamTaskCoreLibrary.Pages.MainPage.Login(login, password, "");
            // Precon 2. Verify that you were successfully logged in
            //Assert.AreEqual(login + '@' + domain, EpamTaskCoreLibrary.Pages.MainPage.GetCurrentUserEmail());
        }

        [TearDown]
        public void TearDown()
        {
            EpamTaskCoreLibrary.Pages.MainPage.Logout();
            Assert.IsTrue(EpamTaskCoreLibrary.Pages.MainPage.IsLoggedOut());
            EpamTaskCoreLibrary.ActionProvider.Stop();
        }

        [Test]
        [TestCase("aivanooooov", "123qwe123", "mail.ru")]
        public void VerifySavedLetterMovedToDrafts(string login, string password, string extension)
        {
            // ToDo: Step 4 - вынести данные в DataProvider

            // Step 1. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 2. Store number of draft letters
            int count = EpamTaskCoreLibrary.Pages.DraftsPage.GetNumberOfDraftLetters();
            // Step 3. Go to composing new letter
            EpamTaskCoreLibrary.Pages.ComposeLetter.Open();
            // Step 4. Fill in required fields
            EpamTaskCoreLibrary.Pages.ComposeLetter.WriteLetter("ivandseqweov@mailtest.ru", "Subject of letter111", "text-text-text");
            // Step 5. Save to drafts
            EpamTaskCoreLibrary.Pages.ComposeLetter.SaveLetterToDrafts();
            // Step 6. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 7. Verify that number of draft letters increased by 1
            Assert.AreEqual(count + 1, EpamTaskCoreLibrary.Pages.DraftsPage.GetNumberOfDraftLetters());
        }

        [Test]
        [TestCase("aivanooooov", "123qwe123", "mail.ru")]
        public void VerifySavedLetterHasCorrectSubject(string login, string password, string extension)
        {
            // ToDo: Step 4 и 7 - вынести данные в DataProvider

            // Step 1. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 2. Store number of draft letters
            int count = EpamTaskCoreLibrary.Pages.DraftsPage.GetNumberOfDraftLetters();
            // Step 3. Go to composing new letter
            EpamTaskCoreLibrary.Pages.ComposeLetter.Open();
            // Step 4. Fill in required fields
            EpamTaskCoreLibrary.Pages.ComposeLetter.WriteLetter("ivandseqweov@mailtest.ru", "Subject of letter111", "text-text-text");
            // Step 5. Save to drafts
            EpamTaskCoreLibrary.Pages.ComposeLetter.SaveLetterToDrafts();
            // Step 6. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 7. Verify subject
            Assert.AreEqual("Subject of letter111", EpamTaskCoreLibrary.Pages.DraftsPage.GetSubjectOfFirstDraftLetter());
        }

    }
}
