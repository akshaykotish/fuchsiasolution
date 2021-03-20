using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Admin0 : System.Web.UI.MasterPage
    {
        Find find = new Find();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Admin_ID() == "0" || find.Admin(Admin_ID()).Rows.Count == 0 || find.Admin(Admin_ID()).Rows[0]["Status"].ToString() == "0")
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        string Admin_ID()
        {
            Admin_Info admin_Info = new Admin_Info();
            return admin_Info.Get_Cookie(HttpContext.Current);
        }
    }
}