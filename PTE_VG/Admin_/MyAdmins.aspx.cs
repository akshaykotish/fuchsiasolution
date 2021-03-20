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
    public partial class MyAdmins : System.Web.UI.Page
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
            All_Admins.DataSource = search.Admins();
            All_Admins.DataBind();
        }

        protected void All_Admins_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Student_Name = (Label)e.Row.FindControl("Student_Name");
                Label Contact = (Label)e.Row.FindControl("Contact");
                Label Email = (Label)e.Row.FindControl("Email");
                Label Institute = (Label)e.Row.FindControl("Institute");
                Button Chng_Status = (Button)e.Row.FindControl("Change_Status");

                Student_Name.Text = DataBinder.Eval(e.Row.DataItem, "Name").ToString();
                Contact.Text = secure.Decrypt(DataBinder.Eval(e.Row.DataItem, "Contact").ToString(), "TSIE-GEHM-TAKUCF");
                Email.Text = secure.Decrypt(DataBinder.Eval(e.Row.DataItem, "Email").ToString(), "TSIE-GEHM-TAKUCF");
                Institute.Text = DataBinder.Eval(e.Row.DataItem, "Institute").ToString();
                string chng_stts = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                Chng_Status.CommandArgument = DataBinder.Eval(e.Row.DataItem, "Admin_ID").ToString();
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

            string Admin_ID = e.CommandArgument.ToString();
            if (e.CommandName == "1")
            {
                updaters.Admin_Status(Admin_ID, "0");
            }
            else
            {
                updaters.Admin_Status(Admin_ID, "1");
            }
            All_Admins.DataSource = find.Admin_All(Search_Console.Text);
            All_Admins.DataBind();
        }

        protected void Create_Question_Click(object sender, EventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('AddAdmin.aspx' ,'_blank');", true);
        }

        protected void Find_Btn_Click(object sender, EventArgs e)
        {
            All_Admins.DataSource = find.Admin_All(Search_Console.Text);
            All_Admins.DataBind();
        }
    }
}