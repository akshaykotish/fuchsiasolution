using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Test_Assign : System.Web.UI.Page
    {
        Search search = new Search();
        Find find = new Find();
        Insertion insertion = new Insertion();
        Delete delete = new Delete();
        Secure secure = new Secure();
        string[] args = new string[5];

        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Databases();
        }

        void Load_Databases()
        {
            All_Batch.DataSource = search.Batches();
            All_Batch.DataBind();

            All_Test.DataSource = search.Test();
            All_Test.DataBind();
        }

        protected void All_Batch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Title = DataBinder.Eval(e.Row.DataItem, "Title").ToString();
                string Time_Stamp = DataBinder.Eval(e.Row.DataItem, "Created_On").ToString();
                string batch_id = DataBinder.Eval(e.Row.DataItem, "Batch_ID").ToString();
                Label test_name = (Label)e.Row.FindControl("Batch_Title");
                Label Crtd_on = (Label)e.Row.FindControl("Created_on");
                Label students = (Label)e.Row.FindControl("Students");
                Label tests = (Label)e.Row.FindControl("Tests");
                test_name.Text = Title;
                Crtd_on.Text = Time_Stamp;
                students.Text = find.Students_Batch(batch_id).Rows.Count.ToString();
                tests.Text = find.Batch_Test_BATCHID(batch_id).Rows.Count.ToString();
            }
        }

        protected void Load_Tests_Command(object sender, CommandEventArgs e)
        {
            Load_Tests(e.CommandName, "");
        }

        void Load_Tests(string value, string keyword)
        {
            Batch_ID.Value = value;

            DataTable temp_table = new DataTable();
            temp_table.Columns.Add(new DataColumn("Test_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("Name", typeof(string)));
            temp_table.Columns.Add(new DataColumn("Details", typeof(string)));
            temp_table.Columns.Add(new DataColumn("TimeStamp", typeof(string)));

            DataTable remain_table = new DataTable();
            remain_table.Columns.Add(new DataColumn("Test_ID", typeof(string)));
            remain_table.Columns.Add(new DataColumn("Name", typeof(string)));
            remain_table.Columns.Add(new DataColumn("Details", typeof(string)));
            remain_table.Columns.Add(new DataColumn("TimeStamp", typeof(string)));

            if (keyword == "")
            {
                for (int i = 0; i < search.Test().Rows.Count; i++)
                {
                    if (find.Batch_Test(Batch_ID.Value, search.Test().Rows[i]["Test_ID"].ToString()).Rows.Count != 0)
                    {
                        temp_table.ImportRow(search.Test().Rows[i]);
                    }
                    else
                    {
                        remain_table.ImportRow(search.Test().Rows[i]);
                    }
                }

                for (int i = 0; i < remain_table.Rows.Count; i++)
                {
                    temp_table.ImportRow(remain_table.Rows[i]);
                }

            }
            else
            {
                for (int i = 0; i < search.Test().Rows.Count; i++)
                {
                    if (find.Batch_Test(Batch_ID.Value, search.Test().Rows[i]["Test_ID"].ToString()).Rows.Count != 0 && find.Test_NAME(keyword).Rows.Count != 0)
                    {
                        temp_table.ImportRow(search.Test().Rows[i]);
                    }
                    else
                    {
                        remain_table.ImportRow(search.Test().Rows[i]);
                    }
                }


            }


            All_Test.DataSource = temp_table;
            All_Test.DataBind();
        }

        protected void All_Test_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Name = DataBinder.Eval(e.Row.DataItem, "Name").ToString();
                string Details = DataBinder.Eval(e.Row.DataItem, "TimeStamp").ToString();
                Label test_name = (Label)e.Row.FindControl("Test_Name");
                Label Crtd_on = (Label)e.Row.FindControl("dtl");
                test_name.Text = Name;
                Crtd_on.Text = Details;

                Button view_question = (Button)e.Row.FindControl("View_Question");
                view_question.CommandArgument = DataBinder.Eval(e.Row.DataItem, "Test_ID").ToString();


                Button action_btn = (Button)e.Row.FindControl("Action_Test_Btn");


                if (Batch_ID.Value == "0")
                {
                    action_btn.Enabled = false;
                    action_btn.BackColor = Color.DarkGray;
                    action_btn.BorderColor = Color.DarkGray;
                    action_btn.ForeColor = Color.White;
                    action_btn.Text = "Waiting..";
                }
                else
                {
                    if (find.Batch_Test(Batch_ID.Value,DataBinder.Eval(e.Row.DataItem, "Test_ID").ToString()).Rows.Count == 0)
                    {
                        action_btn.BackColor = Color.Green;
                        action_btn.BorderColor = Color.Green;
                        action_btn.ForeColor = Color.White;
                        action_btn.Text = "Assign";
                        action_btn.CommandName = "Assign";
                        e.Row.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        action_btn.BackColor = Color.Red;
                        action_btn.BorderColor = Color.Red;
                        action_btn.ForeColor = Color.White;
                        action_btn.Text = "Remove";
                        action_btn.CommandName = "Remove";
                    }
                }
            }
        }

        protected void Action_Test_Btn_Command(object sender, CommandEventArgs e)
        {
            args[0] = Batch_ID.Value;
            args[1] = e.CommandArgument.ToString();
            args[2] = DateTime.Now.ToString();
            if (e.CommandName == "Assign")
            {
                insertion.Batch_Test(args);
            }
            else
            {
                delete.Batch_Test(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]));
            }
            Load_Databases();
            Load_Tests(Batch_ID.Value, "");
        }

        protected void Create_Btn_Click(object sender, EventArgs e)
        {
            args[0] = Create_Console.Text;
            args[1] = "";
            args[2] = DateTime.Now.ToString();
            args[3] = "O";
            if (find.Batch_Name(args[0]).Rows.Count == 0)
            {
                insertion.Batches(args);
                Load_Databases();
            }
        }

        protected void Search_Btn_Click(object sender, EventArgs e)
        {
            All_Batch.DataSource = find.Batch_Name(Search_Console.Text);
            All_Batch.DataBind();
        }

        protected void Search_Test_Btn_Click(object sender, EventArgs e)
        {
            Load_Tests(Batch_ID.Value, Searh_Test_Console.Text);
        }

        protected void View_Question_Command(object sender, CommandEventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('Sheets.aspx?tid=" + secure.Encrypt(e.CommandArgument.ToString(), "momo-ctni-isbest") + "' ,'_blank');", true);
        }
    }
}