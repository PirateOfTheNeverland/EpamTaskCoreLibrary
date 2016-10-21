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
            ActionProvider.NavigateToUrl(UIMap.composeLetterBaseUrl);
        }

        public static void WriteLetter(string to, string cc, string bcc, string subject, string text)
        {
        }
    }
}
