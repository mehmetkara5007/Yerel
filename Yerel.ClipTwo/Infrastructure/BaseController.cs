using System.Web.Mvc;

namespace Yerel.ClipTwo.Infrastructure
{

    public class BaseController : Controller
    {
        public void SuccessNotification(string message)
        {
            Notification("success", message);
        }

        public void WarningNotification(string message)
        {
            Notification("warning", message);
        }

        public void InfoNotification(string message)
        {
            Notification("info", message);
        }

        public void DangerNotification(string message)
        {
            Notification("error", message);
        }

        private void Notification(string notifyType, string message)
        {
            TempData["notifyType"] = notifyType;
            TempData["notifyMessage"] = message;
        }
    }
}
