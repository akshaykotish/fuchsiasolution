using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTE_VG
{
    /// <summary>
    /// Summary description for Student_Info
    /// </summary>
    public class Student_Info : IHttpHandler
    {

        public string Get_Cookie(HttpContext context)
        {
            string Student_id = "0";
            HttpCookie stud_cookie = context.Request.Cookies["StudentInfo"];
            if (stud_cookie != null)
            {
                Student_id = stud_cookie["S_ID"];
            }
            return Student_id;
        }

        public void ProcessRequest(HttpContext context)
        {
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