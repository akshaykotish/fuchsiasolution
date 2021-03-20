using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;


namespace PTE_VG
{
    public partial class MyStudents : System.Web.UI.Page
    {
        Search search = new Search();
        Find find = new Find();
        Insertion insertion = new Insertion();
        Updaters updaters = new Updaters();
        Delete delete = new Delete();
        Secure secure = new Secure();
        string[] args = new string[5];
        protected void Page_Load(object sender, EventArgs e)
        {
            All_Students.DataSource = search.Students();
            All_Students.DataBind();
        }


        protected void All_Students_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Student_Name = (Label)e.Row.FindControl("Student_Name");
                Label Father_Name = (Label)e.Row.FindControl("Father_Name");
                Label Contact = (Label)e.Row.FindControl("Contact");
                Label Email = (Label)e.Row.FindControl("Email");
                Label Batch = (Label)e.Row.FindControl("Batch");
                Label Date_Of_Join = (Label)e.Row.FindControl("Date_Of_Joining");
                Label Institute = (Label)e.Row.FindControl("Institute");
                Button Chng_Status = (Button)e.Row.FindControl("Change_Status");

                Student_Name.Text = DataBinder.Eval(e.Row.DataItem, "Name").ToString();
                Father_Name.Text = DataBinder.Eval(e.Row.DataItem, "Father_Name").ToString();
                Contact.Text = secure.Decrypt(DataBinder.Eval(e.Row.DataItem, "Contact").ToString(), "TSIE-GEHM-TAKUCF");
                Email.Text = secure.Decrypt(DataBinder.Eval(e.Row.DataItem, "Email").ToString(), "TSIE-GEHM-TAKUCF");
                string batch_id= DataBinder.Eval(e.Row.DataItem, "Batch_ID").ToString();
                Batch.Text = find.Batches(batch_id).Rows.Count != 0 ? find.Batches(batch_id).Rows[0]["Title"].ToString() : "No Batch Assigned";
                Date_Of_Join.Text = DataBinder.Eval(e.Row.DataItem, "Date_Of_Join").ToString();
                Institute.Text = DataBinder.Eval(e.Row.DataItem, "Institute").ToString();
                string chng_stts = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                Chng_Status.CommandArgument = DataBinder.Eval(e.Row.DataItem, "Student_Id").ToString();
                Chng_Status.CommandName = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                if (chng_stts == "1")
                {
                    Chng_Status.Text = "Block";
                    Chng_Status.BackColor = Color.Red;
                    Chng_Status.BorderColor = Color.Red;
                    Chng_Status.ForeColor = Color.White;
                }
                else
                {
                    Chng_Status.Text = "Unblock";
                    Chng_Status.BackColor = Color.Green;
                    Chng_Status.BorderColor = Color.Green;
                    Chng_Status.ForeColor = Color.White;
                }
            }

        }

        protected void Change_Status_Command(object sender, CommandEventArgs e)
        {
            string Student_Id = e.CommandArgument.ToString();
            if(e.CommandName == "1")
            {
                updaters.Student_Status(Student_Id, "0");
            }
            else
            {
                updaters.Student_Status(Student_Id, "1");
            }
            All_Students.DataSource = find.Student_All(Search_Console.Text);
            All_Students.DataBind();
        }

        protected void Find_Btn_Click(object sender, EventArgs e)
        {
            All_Students.DataSource = find.Student_All(Search_Console.Text);
            All_Students.DataBind();
        }

        protected void Create_Question_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('AddStudents.aspx' ,'_blank');", true);
        }
    }
}