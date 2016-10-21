using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTaskCoreLibrary.Pages
{
    public static class DraftsPage
    {
        static DraftsPage() { }

        public static void Open()
        {
            ActionProvider.NavigateToUrlAndWait(UIMap.draftsBaseUrl, 2000);
        }

        public static int GetNumberOfDraftLetters()
        {
            return ActionProvider.CountElementsXpath(UIMap.draftsListitemXpath);
        }

        public static string GetSubjectOfFirstDraftLetter()
        {
            return ActionProvider.ReturnElementFromCollectionXpath(UIMap.draftsListitemXpath, 0).GetAttribute(UIMap.draftsLetterSubjectAttributeName);
        }
    }
}
