using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Find find = new Find();
        protected void Page_Load(object sender, EventArgs e)
        {
            User_lbl.Text = find.Admin(Admin_ID()).Rows.Count != 0 ? find.Admin(Admin_ID()).Rows[0]["Name"].ToString() : "User";
        }
        string Admin_ID()
        {
            Admin_Info admin_Info = new Admin_Info();
            return admin_Info.Get_Cookie(HttpContext.Current);
        }
    }
}