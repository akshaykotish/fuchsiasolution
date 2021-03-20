using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Login : System.Web.UI.Page
    {
        Search search = new Search();
        Find find = new Find();
        Updaters updaters = new Updaters();
        Insertion insertion = new Insertion();
        Delete delete = new Delete();
        Secure secure = new Secure();
        string[] args = new string[8];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string userid = secure.Encrypt(Email.Text, "TSIE-GEHM-TAKUCF");
            string pass = secure.Encrypt(Password.Text, "TSIE-GEHM-TAKUCF");
            if(find.Students(userid, pass).Rows.Count != 0)
            {
                HttpCookie Student_Cookie = new HttpCookie("StudentInfo");
                Student_Cookie["S_ID"] = find.Students(userid, pass).Rows[0]["Student_Id"].ToString();
                Student_Cookie.Expires.Add(new TimeSpan(3, 0, 0));
                Response.Cookies.Add(Student_Cookie);
                Response.Redirect("User/S_Home.aspx");
            }
            else if(find.Admin(userid, pass).Rows.Count != 0)
            {
                HttpCookie Admin_Cookie = new HttpCookie("AdminInfo");
                Admin_Cookie["A_ID"] = find.Admin(userid, pass).Rows[0]["Admin_Id"].ToString();
                Admin_Cookie.Expires.Add(new TimeSpan(3, 0, 0));
                Response.Cookies.Add(Admin_Cookie);
                Response.Redirect("Admin_/Dashboard.aspx");
            }
            else
            {

            }
        }
    }
}