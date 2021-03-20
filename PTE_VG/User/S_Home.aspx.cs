using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class S_Home : System.Web.UI.Page
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
            assignments_to_print("");
        }

        string Student_ID()
        {
            Student_Info student_Info = new Student_Info();
            return student_Info.Get_Cookie(HttpContext.Current);
        }

        void assignments_to_print(string keywords)
        {

            DataTable temp_table = new DataTable();
            temp_table.Columns.Add(new DataColumn("Batch_Test_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("Batch_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("Test_ID", typeof(string)));
            temp_table.Columns.Add(new DataColumn("TimeStamp", typeof(string)));

            int d_month = 0, d_day = 0, d_year = 0;
            string output = "";
            int s = 0;
            string batch_id = find.Students(Student_ID()).Rows.Count != 0 ? find.Students(Student_ID()).Rows[0]["Batch_ID"].ToString() : "0";
           
            for (int i= find.Batch_Test_BATCHID(batch_id).Rows.Count-1; i>=0 ; i--)
            {
                if(i == find.Batch_Test_BATCHID(batch_id).Rows.Count - 1)
                {
                    output = output + "<h3 style='color:white; text-shadow:1px 1px 1px gray;'>Assignments</h3>";
                }
                string dt = find.Batch_Test_BATCHID(batch_id).Rows[i]["TimeStamp"].ToString();
                int m = Convert.ToDateTime(dt).Month;
                int d = Convert.ToDateTime(dt).Day;
                int y = Convert.ToDateTime(dt).Year;

                if(m != d_month || y != d_year || d != d_day)
                {
                    if (s==1)
                    {
                        output = output + "</div><br/><br/>";//0
                        s = 0;
                    }
                    output = output + "<div class='dates'>"+ d + "-" + m + "-" + y +"</div>";
                    d_month = m;
                    d_year = y;
                    d_day = d;
                    output = output + "<div class='sugar'>";//0
                    s = 1;
                }

                string test_id = find.Batch_Test_BATCHID(batch_id).Rows[i]["Test_ID"].ToString();

                int total_ques = find.Test_Maker(test_id).Rows.Count;

                string batch_test_id = find.Batch_Test_BATCHID(batch_id).Rows[i]["Batch_Test_ID"].ToString();
                string STUDENT_ID = Student_ID();
                string giving_id = find.Giving(STUDENT_ID, batch_test_id).Rows.Count != 0 ? find.Giving(STUDENT_ID, batch_test_id).Rows[0]["Giving_ID"].ToString() : "0";
                int complete = 0;
                if (giving_id != "0")
                {
                    complete = find.Giving_Ans(giving_id).Rows.Count;
                }
                float prcnt = (float)((float)complete / (float)total_ques) * 100;

                string batch_test_Id_val = secure.Encrypt(find.Batch_Test_BATCHID(batch_id).Rows[i]["Batch_Test_ID"].ToString(), "MONE-YMAT-TERSLT");
                if (keywords == "")
                {
                    output = output + "<div class='asgnmnt' onclick=topush('"+ batch_test_Id_val +"')>";//1
                    output = output + "<div class='hdr'>";//2
                    output = output + "Assignmnet " + (i + 1);
                    output = output + "</div>";//2
                    output = output + "<div class='cntnt'>";//3
                    output = output + (find.Test(find.Batch_Test_BATCHID(batch_id).Rows[i]["Test_ID"].ToString()).Rows.Count != 0 ? find.Test(find.Batch_Test_BATCHID(batch_id).Rows[i]["Test_ID"].ToString()).Rows[0]["Name"].ToString() : "Unknown Name");
                    output = output + "</div>";//3
                    output = output + "<div class='percent'>";//4
                    output = output + "<table style='width: 100%;'>";//4.1
                    output = output + "<tr style='width: 100%;'>";//4.2
                    output = output + "<td style='width:" + prcnt + "%; border-radius:5px; background-image:url(" + "Images/Icons/progress.png" + ");  background-position:center; background-size:25px;'>";//4.3
                    output = output + "</td>";//4.3
                    output = output + "<td style='width:" + (100 - prcnt) + "%; background-color:white; border-radius:5px; font-size:6pt;'>";//4.4
                    output = output + prcnt + "% Completed";
                    output = output + "</td>";//4.4
                    output = output + "</tr>";//4.2
                    output = output + "</table>";//4.1
                    output = output + "</div>";//4

                    output = output + "</div>";//1
                }
                else
                {
                    if(find.Test(find.Batch_Test_BATCHID(batch_id).Rows[i]["Test_ID"].ToString(), keywords).Rows.Count != 0)
                    {
                        output = output + "<div class='asgnmnt' onclick=" + "topush('" + batch_test_Id_val + "')'>";//1
                        output = output + "<div class='hdr'>";//2
                        output = output + "Assignmnet " + (i + 1);
                        output = output + "</div>";//2
                        output = output + "<div class='cntnt'>";//3
                        output = output + (find.Test(find.Batch_Test_BATCHID(batch_id).Rows[i]["Test_ID"].ToString(), keywords).Rows.Count != 0 ? find.Test(find.Batch_Test_BATCHID(batch_id).Rows[i]["Test_ID"].ToString(), keywords).Rows[0]["Name"].ToString() : "Unknown Name");
                        output = output + "</div>";//3
                        output = output + "<div class='percent'>";//4
                        output = output + "<table style='width: 100%;'>";//4.1
                        output = output + "<tr style='width: 100%;'>";//4.2
                        output = output + "<td style='width:" + prcnt + "%; border-radius:5px; background-image:url(" + "Images/Icons/progress.png" + ");  background-position:center; background-size:25px;'>";//4.3
                        output = output + "</td>";//4.3
                        output = output + "<td style='width:" + (100 - prcnt) + "%; background-color:white; border-radius:5px; font-size:6pt;'>";//4.4
                        output = output + prcnt + "% Completed";
                        output = output + "</td>";//4.4
                        output = output + "</tr>";//4.2
                        output = output + "</table>";//4.1
                        output = output + "</div>";//4

                        output = output + "</div>";//1
                    }
                }
            }
            if(s==1)
            {
                output = output + "</div>";//0
            }
            if(output == "")
            {
                output = "<h4 style='color:white; text-shadow:1px 1px gray; text-transform:capitalize;font-family:'Century Gothic';' >You don't have any assignment, please contact with your institute and subscribe with us.</h4>";
            }
            assignments.InnerHtml = output;

        }

        protected void Search_Batch_Test_Btn_Click(object sender, EventArgs e)
        {
            assignments_to_print(Search_Batch_Test_Console.Text);
        }

       

        protected void CHng_Pg_Click(object sender, EventArgs e)
        {
            string batch_test_id = secure.Decrypt(Batch_Test_IDFld.Value, "MONE-YMAT-TERSLT");
            if (find.Giving(Student_ID(), batch_test_id).Rows.Count == 0)
            {
                args[0] = Student_ID();
                args[1] = batch_test_id;
                args[2] = DateTime.Now.ToString();
                insertion.Giving(args);
            }
            string url = "Test_Page.aspx?Test_ID=" + secure.Encrypt((find.Batch_Test(batch_test_id).Rows.Count != 0 ? find.Batch_Test(batch_test_id).Rows[0]["Test_ID"].ToString() : "UNKOWN"), "MONE-YMAT-TERSLT");
            Response.Redirect(url);

        }
    }
}