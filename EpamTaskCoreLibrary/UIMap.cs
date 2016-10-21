using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTaskCoreLibrary
{
    public class UIMap
    {
        #region Common
        public static string commonUserEmailId = "PH_user-email";
        public static string commonLogoutId = "PH_logoutLink";
        #endregion

        #region MainPage
        public static string mainPageLoginId = "mailbox__login";
        public static string mainPagePasswordId = "mailbox__password";
        public static string mainPageAuthButtonId = "mailbox__auth__button";
        //public static string composeLetterXpath = "(//a[@id='js-mailbox-writemail'])";
        //public static string 
        #endregion

        #region ComposeLetterPage
        public static string composeLetterBaseUrl = "https://e.mail.ru/compose/";
        public static string composeLetterToXpath = "//textarea[@data-original-name='To']";
        public static string composeLetterSubjectXpath = "//input[@name='Subject']";
        public static string composeLetterSimpleTextXpath = "//textarea[@name='Body']";
        public static string composeLetterSwitchToSimpleTextLayoutXpath = "//span[contains(text(), 'Убрать оформление')]";
        public static string composeLetterRichTextXpath = "//body[@id='tinymce']";
        public static string composeLetterSaveDraftsXpath = "//span[contains(text(), 'Сохранить')]";
        #endregion

        #region DraftsPage
        public static string draftsBaseUrl = "https://e.mail.ru/messages/drafts/";
        public static string draftsListitemXpath = "//a[@class='js-href b-datalist__item__link']";
        public static string draftsFirstSubjectXpath = "//div[@class='b-datalist__item__subj']";
        public static string draftsLetterSubjectAttributeName = "data-subject";
        #endregion
    }
}
