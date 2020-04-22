using System.Net;
using Microsoft.Reporting.WebForms;

namespace Yerel.Core.Web.Reporting
{
    public class MyReportCredentials : IReportServerCredentials
    {
        private readonly string _userName;
        private readonly string _passWord;
        private readonly string _domainName;

        public MyReportCredentials(string userName, string passWord, string domainName)
        {
            _userName = userName;
            _passWord = passWord;
            _domainName = domainName;
        }

        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }

        public ICredentials NetworkCredentials
        {
            get { return new NetworkCredential(_userName, _passWord, _domainName); }
        }

        public bool GetFormsCredentials(out Cookie authCookie, out string user,
         out string password, out string authority)
        {
            authCookie = null;
            user = password = authority = null;
            return false;
        }
    }
}