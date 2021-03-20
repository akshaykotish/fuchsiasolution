using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using PTE_VG.Kotish.Codes;
using System.Web.UI.WebControls;

namespace PTE_VG
{
    public partial class SaveF : System.Web.UI.Page
    {
        Search search = new Search();
        Find find = new Find();
        Insertion insertion = new Insertion();
        Delete delete = new Delete();
        string[] args = new string[8];
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Load_Student();
            string name = "/Audio/Answers/" + "GID" + args[0] + "QID" + args[1] + ".mp3";
            Request.SaveAs(Server.MapPath(".") + name, false);
            args[4] = name;
            if (Request.QueryString["cnt"] != null && Request.QueryString["cnt"] == "1")
            {
                insertion.Giving_Ans(args);
                Update_Cookies();
            }
            //Request.SaveAs(Server.MapPath(".") + "/" + "Try_Audio.wav", false);
            //Request.SaveAs(Server.MapPath(".") + "/" + "Try_Audio.ogg", false);
        }

        void Load_Student()
        {
            HttpCookie stdnt = Request.Cookies["student"];
            if(stdnt != null)
            {
                args[0] = stdnt["giving_id"].ToString();
                args[1] = stdnt["question_id"].ToString();
            }
        }

        void Dispose_Student()
        {
            HttpCookie stdnt = Request.Cookies["student"];
            if (stdnt != null)
            {
                Response.Cookies.Remove("student");
            }
        }

        void Update_Cookies()
        {
            HttpCookie stdnt = Request.Cookies["student"];
            if (stdnt != null && find.Giving_Ans(args[0], args[1]).Rows.Count != 0)
            {
                string g_id = find.Giving_Ans(args[0], args[1]).Rows[0]["Giving_Ans_ID"].ToString();
                stdnt["giving_ans_id"] = g_id;
                Response.Cookies.Add(stdnt);
            }
        }
    }
}