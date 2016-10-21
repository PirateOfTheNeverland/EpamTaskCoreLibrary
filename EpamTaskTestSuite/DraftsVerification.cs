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
        [TestCase("aivanooooov", "123qwe123", "mail.ru")]
        public void VerifySavedLetterMovedToDrafts(string login, string password, string extension)
        {
            // Step 1 и 2 нужно будет вынести в SetUp
            // Step 6 и 9 - вынести данные в DataProvider

            // Step 1. Login
            EpamTaskCoreLibrary.Pages.MainPage.Login(login, password, "");
            // Step 2. Verify that you were successfully logged in
            Assert.AreEqual(login + '@' + extension, EpamTaskCoreLibrary.Pages.MainPage.GetCurrentUserEmail());

            // Step 3. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 4. Store number of draft letters
            int count = EpamTaskCoreLibrary.Pages.DraftsPage.GetNumberOfDraftLetters();

            // Step 5. Go to composing new letter
            EpamTaskCoreLibrary.Pages.ComposeLetter.Open();
            // Step 6. Fill in required fields
            EpamTaskCoreLibrary.Pages.ComposeLetter.WriteLetter("ivandseqweov@mailtest.ru", "Subject of letter111", "text-text-text");
            // Step 7. Save to drafts
            EpamTaskCoreLibrary.Pages.ComposeLetter.SaveLetterToDrafts();
            // Step 8. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 9. Verify that number of draft letters increased by 1
            Assert.AreEqual(count + 1, EpamTaskCoreLibrary.Pages.DraftsPage.GetNumberOfDraftLetters());
        }

        [Test]
        [TestCase("aivanooooov", "123qwe123", "mail.ru")]
        public void VerifySavedLetterHasCorrectSubject(string login, string password, string extension)
        {
            // Step 1 и 2 нужно будет вынести в SetUp
            // Step 6 и 9 - вынести данные в DataProvider

            // Step 1. Login
            EpamTaskCoreLibrary.Pages.MainPage.Login(login, password, "");
            // Step 2. Verify that you were successfully logged in
            Assert.AreEqual(login + '@' + extension, EpamTaskCoreLibrary.Pages.MainPage.GetCurrentUserEmail());
            // Step 3. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 4. Store number of draft letters
            int count = EpamTaskCoreLibrary.Pages.DraftsPage.GetNumberOfDraftLetters();
            // Step 5. Go to composing new letter
            EpamTaskCoreLibrary.Pages.ComposeLetter.Open();
            // Step 6. Fill in required fields
            EpamTaskCoreLibrary.Pages.ComposeLetter.WriteLetter("ivandseqweov@mailtest.ru", "Subject of letter111", "text-text-text");
            // Step 7. Save to drafts
            EpamTaskCoreLibrary.Pages.ComposeLetter.SaveLetterToDrafts();
            // Step 8. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 9. Verify subject
            Assert.AreEqual("Subject of letter111", EpamTaskCoreLibrary.Pages.DraftsPage.GetSubjectOfFirstDraftLetter());
        }

    }
}
