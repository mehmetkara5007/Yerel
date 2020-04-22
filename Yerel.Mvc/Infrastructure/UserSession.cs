using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using Yerel.Entities;

namespace Yerel.Mvc.Infrastructure
{
    [Serializable]
    public class ProductSession : IRequiresSessionState
    {
        public void Ekle(Product Product)
        {
            AktifProduct = Product;
        }

        public Product AktifProduct
        {
            get
            {
                if (HttpContext.Current.Session["__AktifProduct"] != null)
                    return (Product) HttpContext.Current.Session["__AktifProduct"];
                return null;
            }
            set
            {
                if (HttpContext.Current != null) HttpContext.Current.Session["__AktifProduct"] = value;
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

        public string SayfaAdi
        {
            get
            {
                return HttpContext.Current.Session["__SayfaAdi"] != null ? HttpContext.Current.Session["__SayfaAdi"].ToString() : "";
            }
            set
            {
                HttpContext.Current.Session["__SayfaAdi"] = value;
            }
        }

        public int DuzenlenenSayfa
        {
            get
            {
                return HttpContext.Current.Session["__DuzenlenenSayfa"] != null ? Convert.ToInt32(HttpContext.Current.Session["__DuzenlenenSayfa"]) : 0;
            }
            set
            {
                HttpContext.Current.Session["__DuzenlenenSayfa"] = value;
            }
        }

        public List<int> Secilenler
        {
            get
            {
                if (HttpContext.Current.Session["__Secilenler"] != null)
                    return (List<int>)HttpContext.Current.Session["__Secilenler"];
                return null;
            }
            set { if (HttpContext.Current != null) HttpContext.Current.Session["__Secilenler"] = value; }
        }

    }
}