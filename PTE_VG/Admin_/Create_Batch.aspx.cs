using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Create_Batch : System.Web.UI.Page
    {
        Search search = new Search();
        Insertion insertion = new Insertion();
        string[] args = new string[5];

        protected void Page_Load(object sender, EventArgs e)
        {
            All_Batches.DataSource = search.Batches();
            All_Batches.DataBind();
        }

        protected void All_Batches_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {

                string Title = DataBinder.Eval(e.Row.DataItem, "Title").ToString();
                string Created_On = DataBinder.Eval(e.Row.DataItem, "Created_On").ToString();
                int student_assigned = 0;
                int question_assigned = 0;
                Label btch_name = (Label)e.Row.FindControl("Batch_Name");
                Label Crtd_on = (Label)e.Row.FindControl("Created_On");
                Label Stdnt_No = (Label)e.Row.FindControl("Students_No");
                Label Tst_No = (Label)e.Row.FindControl("Test_No");
                btch_name.Text = Title;
                Crtd_on.Text = Created_On;
                Stdnt_No.Text = student_assigned.ToString();
                Tst_No.Text = question_assigned.ToString();
            }
        }

        protected void Create_Btn_Click(object sender, EventArgs e)
        {
            args[0] = Create_Console.Text;
            args[1] = "0";
            args[2] = DateTime.Now.ToString();
            args[3] = "";
            insertion.Batches(args);
        }
    }
}