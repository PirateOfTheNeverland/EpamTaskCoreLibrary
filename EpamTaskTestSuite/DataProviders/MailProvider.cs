using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTaskTestSuite.Entities;

namespace EpamTaskTestSuite.DataProviders
{
    public class MailProvider
    {
        public static IEnumerable<Mail> Mails
        {
            get
            {
                yield return new Mail()
                {
                    Recipient = "ivandseqweov@mailtest.ru",
                    Subject = "Subject of letter111",
                    Text = "text-text-text"
                };
            }
        }
    }
}
