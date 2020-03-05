using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yerel.Mvc.Infrastructure
{
    public class SendEmail
    {
        private static string _mSmtpMailAddress;
        private static string _mSmtpMailServer;
        private static string _mSmtpMailUserPassword;

        public static bool SendLostEmail(string toAddress, ListDictionary replacements, string subject, string body)
        {
            _mSmtpMailAddress = "doctorate.contact@gmail.com";
            _mSmtpMailServer = "smtp.gmail.com";
            _mSmtpMailUserPassword = "u3tWYsr1BRUNTNRW6xpMBA=="; //EncryptionUtility.Decrypt()

            var md = new MailDefinition
            { From = _mSmtpMailAddress, Subject = subject, IsBodyHtml = true };
            var mail = md.CreateMailMessage(toAddress, replacements, body, new Control());
            var smtp = new SmtpClient
            {
                Host = _mSmtpMailServer,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_mSmtpMailAddress, EncryptionUtility.Decrypt(_mSmtpMailUserPassword))
            }; //(_mSmtpMailServer, 587)
            smtp.Send(mail);
            return true;
        }
    }
}