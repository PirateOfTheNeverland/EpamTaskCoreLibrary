using EpamTaskTestSuite.DataProviders;
using EpamTaskTestSuite.Entities;
using NUnit.Framework;

namespace EpamTaskTestSuite.Tests
{
    [TestFixture]
    [TestFixtureSource(typeof(UserProvider), "Users")]
    public class DraftsVerificationTest
    {
        private User _user;

        public DraftsVerificationTest(User user)
        {
            _user = user;
        }

        [SetUp]
        public void SetUp()
        {
            // Precon 1. Login
            EpamTaskCoreLibrary.Pages.MainPage.Login(_user.Name, _user.Password, "");
            // Precon 2. Verify that you were successfully logged in
            Assert.AreEqual(_user.Name + "@" + _user.Domain, EpamTaskCoreLibrary.Pages.MainPage.GetCurrentUserEmail());
        }

        [TearDown]
        public void TearDown()
        {
            EpamTaskCoreLibrary.Pages.MainPage.Logout();
            Assert.IsTrue(EpamTaskCoreLibrary.Pages.MainPage.IsLoggedOut());
        }

        [Test]
        [TestCaseSource(typeof(MailProvider), "Mails")]
        public void VerifySavedLetterMovedToDrafts(Mail email)
        {
            // Step 1. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 2. Store number of draft letters
            int count = EpamTaskCoreLibrary.Pages.DraftsPage.GetNumberOfDraftLetters();
            // Step 3. Go to composing new letter
            EpamTaskCoreLibrary.Pages.ComposeLetter.Open();
            // Step 4. Fill in required fields
            EpamTaskCoreLibrary.Pages.ComposeLetter.WriteLetter(email.Recipient, email.Subject, email.Text);
            // Step 5. Save to drafts
            EpamTaskCoreLibrary.Pages.ComposeLetter.SaveLetterToDrafts();
            // Step 6. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 7. Verify that number of draft letters increased by 1
            Assert.AreEqual(count + 1, EpamTaskCoreLibrary.Pages.DraftsPage.GetNumberOfDraftLetters());
        }

        [Test]
        [TestCaseSource(typeof(MailProvider), "Mails")]
        public void VerifySavedLetterHasCorrectSubject(Mail email)
        {
            // Step 1. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 2. Store number of draft letters
            int count = EpamTaskCoreLibrary.Pages.DraftsPage.GetNumberOfDraftLetters();
            // Step 3. Go to composing new letter
            EpamTaskCoreLibrary.Pages.ComposeLetter.Open();
            // Step 4. Fill in required fields
            EpamTaskCoreLibrary.Pages.ComposeLetter.WriteLetter(email.Recipient, email.Subject, email.Text);
            // Step 5. Save to drafts
            EpamTaskCoreLibrary.Pages.ComposeLetter.SaveLetterToDrafts();
            // Step 6. Go to drafts
            EpamTaskCoreLibrary.Pages.DraftsPage.Open();
            // Step 7. Verify subject
            Assert.AreEqual(email.Subject, EpamTaskCoreLibrary.Pages.DraftsPage.GetSubjectOfFirstDraftLetter());
        }

    }
}
