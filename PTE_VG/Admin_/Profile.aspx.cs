using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Profile : System.Web.UI.Page
    {
        Search search = new Search();
        Find find = new Find();
        Updaters updaters = new Updaters();
        Insertion insertion = new Insertion();
        Delete delete = new Delete();
        Secure secure = new Secure();
        string[] args = new string[6];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Admin_ID() != "0")
            {
                Admin_Name_box.Text = find.Admin(Admin_ID()).Rows[0]["Name"].ToString();
                Contact.Text = secure.Decrypt(find.Admin(Admin_ID()).Rows[0]["Contact"].ToString(), "TSIE-GEHM-TAKUCF");
                Email.Text = secure.Decrypt(find.Admin(Admin_ID()).Rows[0]["Email"].ToString(), "TSIE-GEHM-TAKUCF");
                Institute.Text = find.Admin(Admin_ID()).Rows[0]["Institute"].ToString();
                Institute.Enabled = false;
            }
        }

        string Admin_ID()
        {
            Admin_Info admin_Info = new Admin_Info();
            return admin_Info.Get_Cookie(HttpContext.Current);
        }

        protected void Update_Student_Click(object sender, EventArgs e)
        {
            args[0] = Admin_Name_box.Text;
            args[1] = secure.Encrypt(Contact.Text, "TSIE-GEHM-TAKUCF");
            args[2] = secure.Encrypt(Email.Text, "TSIE-GEHM-TAKUCF");
            args[4] = find.Admin(Admin_ID()).Rows[0]["Institute"].ToString();
            args[5] = find.Admin(Admin_ID()).Rows[0]["Status"].ToString();
            if (Password.Text != null && Password.Text != "" && Password.Text.Length > 6)
            {
                args[3] = secure.Encrypt(Password.Text, "TSIE-GEHM-TAKUCF");
            }
            else
            {
                args[3] = find.Admin(Admin_ID()).Rows[0]["Password"].ToString();
            }
            updaters.Admin(args, Admin_ID());
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Cookies.Remove("AdminInfo");
            Response.Redirect("Login.aspx");
        }
    }
}