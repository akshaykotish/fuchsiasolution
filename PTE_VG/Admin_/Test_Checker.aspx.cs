using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Test_Checker : System.Web.UI.Page
    {
        Search search = new Search();
        Find find = new Find();
        Insertion insertion = new Insertion();
        Delete delete = new Delete();
        Secure secure = new Secure();
        string[] args = new string[5];


        protected void Page_Load(object sender, EventArgs e)
        {
            All_Test.DataSource = search.Batch_Test();
            All_Test.DataBind();
        }

        protected void All_Test_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Batch_id = DataBinder.Eval(e.Row.DataItem, "Batch_ID").ToString();
                string Test_id = DataBinder.Eval(e.Row.DataItem, "Test_ID").ToString();
                string TimeStamp = DataBinder.Eval(e.Row.DataItem, "TimeStamp").ToString();


                Label Test_Name = (Label)e.Row.FindControl("Test_Name");
                Label Batch_Name = (Label)e.Row.FindControl("Batch_Name");
                Label Created_on = (Label)e.Row.FindControl("Created_On");
                Label No_of_Question = (Label)e.Row.FindControl("No_of_Questions");

                if ((find.Batches(Batch_id).Rows.Count != 0) && (find.Test(Test_id).Rows.Count != 0))
                {
                    Test_Name.Text = find.Test(Test_id).Rows[0]["Name"].ToString();
                    Batch_Name.Text = find.Batches(Batch_id).Rows[0]["Title"].ToString();
                    Created_on.Text = TimeStamp;
                    No_of_Question.Text = find.Test_Maker(Test_id).Rows.Count.ToString();
                }
            }
        }

        protected void Load_test_questions_Command(object sender, CommandEventArgs e)
        {

            string batch_test_id = e.CommandName.ToString();
            batch_test_id_fld.Value = batch_test_id;

            if (find.Giving_BATCH(batch_test_id).Rows.Count != 0)
            {
                All_Students.DataSource = find.Giving_BATCH(batch_test_id);
                All_Students.DataBind();

                string Batch_id = find.Batch_Test(batch_test_id).Rows[0]["Batch_ID"].ToString();
                string Test_id = find.Batch_Test(batch_test_id).Rows[0]["Test_ID"].ToString();

                if ((find.Batches(Batch_id).Rows.Count != 0) && (find.Test(Test_id).Rows.Count != 0))
                {
                    //Test_Details.Text = "Test :- " + find.Test(Test_id).Rows[0]["Name"].ToString() + " || Batch :- " + find.Batches(Batch_id).Rows[0]["Title"].ToString();    
                }
            }
            else
            {

            }

        }

        protected void All_Students_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Student_ID = DataBinder.Eval(e.Row.DataItem, "Student_ID").ToString();

                Label Student_Name = (Label)e.Row.FindControl("Student_Name");
                Label Contact = (Label)e.Row.FindControl("Contact");
                Label Email = (Label)e.Row.FindControl("Email");
                Label IsChecked = (Label)e.Row.FindControl("IsChecked");

                if (find.Students(Student_ID).Rows.Count != 0)
                {
                    Student_Name.Text = find.Students(Student_ID).Rows[0]["Name"].ToString();
                    Contact.Text = secure.Decrypt(find.Students(Student_ID).Rows[0]["Contact"].ToString(), "TSIE-GEHM-TAKUCF"); ;
                    Email.Text = secure.Decrypt(find.Students(Student_ID).Rows[0]["Email"].ToString(), "TSIE-GEHM-TAKUCF"); ;
                    IsChecked.ForeColor = Color.Red;
                    IsChecked.Text = "Uncheck";
                }
            }
        }

        protected void Load_Student_Sheet_Command(object sender, CommandEventArgs e)
        {
            string Giving_ID = e.CommandName;


            //string script = "document.getElementById('myModal').style.display = 'block';";
            //ClientScript.RegisterStartupScript(this.GetType(), "LoadModal", script, true);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('Sheets.aspx?gid=" + secure.Encrypt(Giving_ID, "momo-ctni-isbest") + "' ,'_blank');", true);

            //string script = "window.open('Sheets.aspx?gid=" + secure.Encrypt(Giving_ID, "momo-ctni-isbest") + "','_blank";
            //ClientScript.RegisterStartupScript(this.GetType(), "redirect", script, true);

        }



        private void Mark_btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Mark_btn_Command(object sender, CommandEventArgs e)
        {
            args[0] = e.CommandArgument.ToString();
            args[1] = e.CommandName;
            args[2] = "";
            args[3] = "0";

            if (find.Marking(args[0]).Rows.Count == 0)
            {
                insertion.Marking(args);
            }
        }

        protected void Mark_btn_Command1(object sender, CommandEventArgs e)
        {

        }

        protected void All_Questions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            args[0] = e.CommandArgument.ToString();
            args[1] = e.CommandName;
            args[2] = "";
            args[3] = "0";

            if (find.Marking(args[0]).Rows.Count == 0)
            {
                insertion.Marking(args);
            }
        }

        protected void Student_Search_Button_Click(object sender, EventArgs e)
        {
            string keyword = Student_Search_Console.Text;

            DataTable temp_table = new DataTable();
            temp_table.Columns.Add(new DataColumn("Giving_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("Student_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("Batch_Test_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("TimeStamp", typeof(string)));


            for (int i = 0; i < find.Student_Name(keyword).Rows.Count; i++)
            {
                for (int j=0; j < find.Giving(find.Student_Name(keyword).Rows[i]["Student_Id"].ToString(), batch_test_id_fld.Value).Rows.Count; j++)
                {
                    temp_table.ImportRow(find.Giving(find.Student_Name(keyword).Rows[i]["Student_Id"].ToString(), batch_test_id_fld.Value).Rows[j]);
                }
            }


            All_Test.DataSource = temp_table;
            All_Test.DataBind();
        }

        protected void Search_Batch_Test_Btn_Click(object sender, EventArgs e)
        {
            string keyword = Search_Batch_Test_Console.Text;

            DataTable temp_table = new DataTable();
            temp_table.Columns.Add(new DataColumn("Batch_Test_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("Batch_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("Test_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("TimeStamp", typeof(string)));


            for (int i = 0; i < find.Test_NAME(keyword).Rows.Count; i++)
            {
                for(int j=0; j< find.Batch_Test_TestID(find.Test_NAME(keyword).Rows[i]["Test_ID"].ToString()).Rows.Count; j++)
                {
                    temp_table.ImportRow(find.Batch_Test_TestID(find.Test_NAME(keyword).Rows[i]["Test_ID"].ToString()).Rows[j]);
                }
            }

            for (int i = 0; i < find.Batch_Name(keyword).Rows.Count; i++)
            {
                for (int j = 0; j < find.Batch_Test_BATCHID(find.Batch_Name(keyword).Rows[i]["Batch_ID"].ToString()).Rows.Count; j++)
                {
                    temp_table.ImportRow(find.Batch_Test_BATCHID(find.Batch_Name(keyword).Rows[i]["Batch_ID"].ToString()).Rows[j]);
                }
            }

            All_Test.DataSource = temp_table;
            All_Test.DataBind();
        }
    }
}