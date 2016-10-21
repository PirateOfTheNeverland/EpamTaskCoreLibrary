using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTaskCoreLibrary.Pages
{
    public static class ComposeLetter
    {
        static ComposeLetter() { }

        public static void Open()
        {
            ActionProvider.NavigateToUrlAndWait(UIMap.composeLetterBaseUrl, 2000);
        }

        public static void WriteLetter(string to, string cc, string bcc, string subject, string text)
        {
            ActionProvider.SendKeysXpath(UIMap.composeLetterToXpath, true, to);
            ActionProvider.SendKeysXpath(UIMap.composeLetterSubjectXpath, true, subject);
            ActionProvider.ClickAndWaitXpath(UIMap.composeLetterSwitchToSimpleTextLayoutXpath, 500);
            ActionProvider.SendKeysXpath(UIMap.composeLetterSimpleTextXpath, true, text);
        }

        public static void SaveLetterToDrafts()
        {
            ActionProvider.ClickAndWaitXpath(UIMap.composeLetterSaveDraftsXpath, 1000);
        }
    }
}
