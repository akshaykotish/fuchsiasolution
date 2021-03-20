using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Student : System.Web.UI.MasterPage
    {
        Find find = new Find();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Student_ID() == "0" || find.Students(Student_ID()).Rows.Count == 0 || find.Students(Student_ID()).Rows[0]["Status"].ToString() == "0")
            {
                Response.Redirect("Login.aspx");
            }
        }
        string Student_ID()
        {
            Student_Info student_Info = new Student_Info();
            return student_Info.Get_Cookie(HttpContext.Current);
        }
    }
}