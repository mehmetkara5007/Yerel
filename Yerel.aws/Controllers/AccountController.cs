using Yerel.aws.Infrastructure;
using Yerel.aws.Models;
using System.Web.Mvc;
using System.Web.Security;
using Yerel.Entities;
using Yerel.Business;

namespace Yerel.aws.Controllers
{
    public class AccountController : BaseController
    {

        private readonly IUserService _userService;
        private readonly IDataTempService _DataTempService;

        public AccountController(IUserService userService, IDataTempService dataTempService)
        {
            _userService = userService;
            _DataTempService = dataTempService;
        }

        public ActionResult Login()
        {
            if (Session != null && Session["Login"] != null && User.Identity.IsAuthenticated)
                return View("UnAuthorize");
            if (Session != null && Session["Login"] != null)
                return RedirectToAction("ReLogin");

            LoginViewModel model = new LoginViewModel
            {
                User = new User(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Login(LoginViewModel mModel, bool loginCheck, string returnUrl, UserSession PersonelSession)
        {
            User p = _userService.GetUserByEmail(mModel.EMail, EncryptionUtility.Encrypt(mModel.Password));
            if (p != null)
            {
                FormsAuthentication.SetAuthCookie(p.Email, loginCheck);
                PersonelSession.Ekle(p);
                Session["Login"] = p.Email;

                return string.IsNullOrEmpty(returnUrl)
                    ? RedirectToAction("Index", "Home")
                    : (ActionResult)Redirect(returnUrl);
            }
            else
            {
                DangerNotification("Sistemde böyle bir kullanıcı adı veya şifre bulunamamıştır");
            }

            LoginViewModel model = new LoginViewModel
            {
                User = new User(),
            };
            return View(model);
        }

    }
}