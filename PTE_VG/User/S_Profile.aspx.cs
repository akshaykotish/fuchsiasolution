using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class S_Profile : System.Web.UI.Page
    {
        Search search = new Search();
        Find find = new Find();
        Updaters updaters = new Updaters();
        Insertion insertion = new Insertion();
        Delete delete = new Delete();
        Secure secure = new Secure();
        string[] args = new string[10];

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Student_ID() != "0")
            {
                Student_Name_box.Text = find.Students(Student_ID()).Rows[0]["Name"].ToString();
                Father_Name_box.Text = find.Students(Student_ID()).Rows[0]["Father_Name"].ToString();
                Contact.Text = secure.Decrypt(find.Students(Student_ID()).Rows[0]["Contact"].ToString(), "TSIE-GEHM-TAKUCF"); 
                Email.Text = secure.Decrypt(find.Students(Student_ID()).Rows[0]["Email"].ToString(), "TSIE-GEHM-TAKUCF"); 
                Date_Of_Join.Text = find.Students(Student_ID()).Rows[0]["Date_Of_Join"].ToString();
                Date_Of_Join.Enabled = false;
                Institute.Text = find.Students(Student_ID()).Rows[0]["Institute"].ToString();
                Institute.Enabled = false;
                Date_Of_Birth.Text = find.Students(Student_ID()).Rows[0]["Date_Of_Birth"].ToString();
                Batch.Text = find.Batches(find.Students(Student_ID()).Rows[0]["Batch_ID"].ToString()).Rows[0]["Title"].ToString();
                Batch.Enabled = false;
            }
        }

        string Student_ID()
        {
            Student_Info student_Info = new Student_Info();
            return student_Info.Get_Cookie(HttpContext.Current);
        }

        protected void Update_Student_Click(object sender, EventArgs e)
        {
            args[0] = Student_Name_box.Text;
            args[1] = Father_Name_box.Text;
            args[2] = secure.Encrypt(Contact.Text, "TSIE-GEHM-TAKUCF");
            args[3] = secure.Encrypt(Email.Text, "TSIE-GEHM-TAKUCF");
            args[4] = find.Students(Student_ID()).Rows[0]["Batch_ID"].ToString();
            args[5] = Date_Of_Join.Text;
            args[6] = find.Students(Student_ID()).Rows[0]["Institute"].ToString();
            args[7] = Date_Of_Birth.Text;
            args[8] = find.Students(Student_ID()).Rows[0]["Status"].ToString();
            if (Password.Text != null && Password.Text != "" && Password.Text.Length > 6)
            {
                args[9] = secure.Encrypt(Password.Text, "TSIE-GEHM-TAKUCF");
            }
            else
            {
                args[9] = find.Students(Student_ID()).Rows[0]["Password"].ToString();
            }
            updaters.Student(args, Student_ID());
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Cookies.Remove("StudentInfo");
            Response.Redirect("Login.aspx");
        }
    }
}