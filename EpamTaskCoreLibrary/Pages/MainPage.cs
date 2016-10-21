using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTaskCoreLibrary.Pages
{
    public static class MainPage
    {
        static MainPage() { }

        public static void Login(string login, string password, string ext)
        {
            ActionProvider.SendKeysId(UIMap.mainPageLoginId, true, login);
            ActionProvider.SendKeysId(UIMap.mainPagePasswordId, true, password);
            if (ext != "")
            {
                // ToDo: select extension
            }
            ActionProvider.ClickAndWaitId(UIMap.mainPageAuthButtonId, 2000);
        }

        public static string GetCurrentUserEmail()
        {
            return ActionProvider.GetTextId(UIMap.commonUserEmailId);
        }
    }
}
