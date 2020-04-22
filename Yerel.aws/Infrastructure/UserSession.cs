using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using Yerel.Entities;

namespace Yerel.aws.Infrastructure
{
    [Serializable]
    public class UserSession : IRequiresSessionState
    {
        public void Ekle(User User)
        {
            AktifUser = User;
        }

        public User AktifUser
        {
            get
            {
                if (HttpContext.Current.Session["__AktifUser"] != null)
                    return (User) HttpContext.Current.Session["__AktifUser"];
                return null;
            }
            set
            {
                if (HttpContext.Current != null) HttpContext.Current.Session["__AktifUser"] = value;
            }
        }

        //public List<Menu> Menuler
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["__Menuler"] != null)
        //            return (List<Menu>)HttpContext.Current.Session["__Menuler"];
        //        return null;
        //    }
        //    set { if (HttpContext.Current != null) HttpContext.Current.Session["__Menuler"] = value; }
        //}
    }
}