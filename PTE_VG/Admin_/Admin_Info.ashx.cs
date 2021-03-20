using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTE_VG
{
    /// <summary>
    /// Summary description for Admin_Info
    /// </summary>
    public class Admin_Info : IHttpHandler
    {
        public string Get_Cookie(HttpContext context)
        {
            string Admin_id = "0";
            HttpCookie admin_cookie = context.Request.Cookies["AdminInfo"];
            if (admin_cookie != null)
            {
                Admin_id = admin_cookie["A_ID"];
            }
            return Admin_id;
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}