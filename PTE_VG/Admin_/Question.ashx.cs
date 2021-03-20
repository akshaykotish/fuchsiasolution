using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    /// <summary>
    /// Summary description for Question1
    /// </summary>
    public class Question1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpCookie reqCookies = context.Request.Cookies["Question_Info"];
            Updaters updater = new Updaters();
            Secure secure = new Secure();
            Find find = new Find();
            if (context.Request.QueryString["type"] != null && reqCookies != null && context.Request.QueryString["ext"] != null)
            {
                string temp_name = reqCookies["Q_Title"].ToString(); 
                int id = Convert.ToInt32(find.Question(temp_name).Rows.Count != 0 ? find.Question(temp_name).Rows[0]["Question_ID"].ToString() : "0");
                string extension = context.Request.QueryString["ext"];
                temp_name = temp_name.Replace('/', 's');
                temp_name = temp_name.Replace(':', 'd');
                temp_name = temp_name.Replace(' ', 's');
                temp_name = temp_name + "." + extension;
                string secured = secure.Encrypt(temp_name, "4444-2222-123456");
              
                if (context.Request.QueryString["type"] == "a")
                {
                    string filename = context.Server.MapPath("~/Audio/Question/") + temp_name;
                    context.Request.SaveAs(filename, false);
                    updater.Question_Audio(secured, id);
                }
                else if(context.Request.QueryString["type"] == "p")
                {
                    string filename = context.Server.MapPath("~/Images/Question/") + temp_name;
                    context.Request.SaveAs(filename, false);
                    updater.Question_Image(secured, id);
                }
            }
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