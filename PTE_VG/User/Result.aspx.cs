using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Result : System.Web.UI.Page
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
            string batch_id = find.Students(Student_ID()).Rows.Count != 0 ? find.Students(Student_ID()).Rows[0]["Batch_ID"].ToString() : "0";
            All_Test.DataSource = find.Batch_Test_BATCHID(batch_id);
            All_Test.DataBind();
        }

        string Student_ID()
        {
            Student_Info student_Info = new Student_Info();
            return student_Info.Get_Cookie(HttpContext.Current);
        }

        protected void All_Test_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Test_Name = (Label)e.Row.FindControl("Test_Name");
                Label Question_Count = (Label)e.Row.FindControl("Question_Count");
                Label Date_lbl = (Label)e.Row.FindControl("Date");
                Label Marks_Count = (Label)e.Row.FindControl("Marks_Count");

                Button View_Test = (Button)e.Row.FindControl("View_Test");

                string batch_test_id = DataBinder.Eval(e.Row.DataItem, "Test_ID").ToString();
                string test_id = DataBinder.Eval(e.Row.DataItem, "Batch_Test_ID").ToString();

                string giving_id = find.Giving(batch_test_id).Rows[0]["Giving_ID"].ToString();

                Test_Name.Text = find.Test(test_id).Rows[0]["Name"].ToString();
                Question_Count.Text = find.Test_Maker(test_id).Rows.Count.ToString();
                Date_lbl.Text = DataBinder.Eval(e.Row.DataItem, "TimeStamp").ToString();
                float marks = 0;
                for (int i = 0; i < find.Giving_Ans(giving_id).Rows.Count; i++)
                {
                    string giving_ans_id = find.Giving_Ans(giving_id).Rows[i]["Giving_Ans_ID"].ToString();
                    string marks_id = find.Marking(giving_ans_id).Rows.Count != 0 ? find.Marking(giving_ans_id).Rows[0]["Marks_ID"].ToString() : "0";
                    if(marks_id != "0")
                    {
                        float temp = Convert.ToSingle(find.Marks(marks_id).Rows[0]["Value"].ToString() != "" ? find.Marks(marks_id).Rows[0]["Value"].ToString() : "0");
                        marks = marks + temp;
                    }
                }
                Marks_Count.Text = marks.ToString();

                View_Test.CommandArgument = giving_id;
            }
        }

        protected void Find_Btn_Click(object sender, EventArgs e)
        {
            string batch_id = find.Students(Student_ID()).Rows[0]["Batch_ID"].ToString();

            DataTable temp_table = new DataTable();
            temp_table.Columns.Add(new DataColumn("Batch_Test_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("Batch_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("Test_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("TimeStamp", typeof(string)));

            for (int i = 0; i < find.Test_NAME(Search_Console.Text).Rows.Count; i++)
            {
                string test_id_temp = find.Test_NAME(Search_Console.Text).Rows[i]["Test_ID"].ToString();
                if (find.Batch_Test(batch_id, test_id_temp).Rows.Count != 0)
                {
                    temp_table.ImportRow(find.Batch_Test(batch_id, test_id_temp).Rows[0]);
                }
            }
            All_Test.DataSource = temp_table;
            All_Test.DataBind();
        }

        protected void View_Test_Command(object sender, CommandEventArgs e)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('Sheets.aspx?gid=" + secure.Encrypt(e.CommandArgument.ToString(), "momo-ctni-isbest") + "' ,'_blank');", true);
        }
    }
}