using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Sheets : System.Web.UI.Page
    {
        Search search = new Search();
        Find find = new Find();
        Insertion insertion = new Insertion();
        //Delete delete = new Delete();
        Secure secure = new Secure();
        string[] args = new string[5];
        int serial;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["gid"] != null && !IsPostBack)
            {
                string Giving_ID = secure.Decrypt(Request.QueryString["gid"], "momo-ctni-isbest");
                All_Questions.DataSource = find.Giving_Ans(Giving_ID);
                All_Questions.DataBind();

                if (find.Giving(Giving_ID).Rows.Count != 0)
                {
                    studentdtl.Visible = true;
                    string Student_id = find.Giving(Giving_ID).Rows[0]["Student_ID"].ToString();
                    string Batch_Test_ID = find.Giving(Giving_ID).Rows[0]["Batch_Test_ID"].ToString();
                    if (find.Batch_Test(Batch_Test_ID).Rows.Count != 0 && find.Students(Student_id).Rows.Count != 0)
                    {
                        string Batch_ID = find.Batch_Test(Batch_Test_ID).Rows[0]["Batch_ID"].ToString();
                        string Test_ID = find.Batch_Test(Batch_Test_ID).Rows[0]["Test_ID"].ToString();

                        if (find.Test(Test_ID).Rows.Count != 0)
                        {
                            Sheet_title.Text = find.Test(Test_ID).Rows[0]["Name"].ToString();
                        }

                        if (find.Batches(Batch_ID).Rows.Count != 0)
                        {
                            Sheet_title.Text = Sheet_title.Text + " || " + find.Batches(Batch_ID).Rows[0]["Title"].ToString();
                        }

                        Sheet_Name.Text = find.Students(Student_id).Rows[0]["Name"].ToString();
                        Sheet_Contact.Text = secure.Decrypt(find.Students(Student_id).Rows[0]["Contact"].ToString(), "TSIE-GEHM-TAKUCF");
                        Sheet_Email.Text = secure.Decrypt(find.Students(Student_id).Rows[0]["Email"].ToString(), "TSIE-GEHM-TAKUCF");

                        Sheet_Date.Text = find.Giving(Giving_ID).Rows[0]["TimeStamp"].ToString();

                        
                    }
                }
            }
            else if(Request.QueryString["tid"] != null && !IsPostBack)
            {
                studentdtl.Visible = false;
                string tid = secure.Decrypt(Request.QueryString["tid"].ToString(), "momo-ctni-isbest");
                All_Questions.DataSource = find.Test_Maker(tid);
                All_Questions.DataBind();
            }
            
        }

        string Student_ID()
        {
            Student_Info student_Info = new Student_Info();
            return student_Info.Get_Cookie(HttpContext.Current);
        }

        string Admin_ID()
        {
            Admin_Info admin_Info = new Admin_Info();
            return admin_Info.Get_Cookie(HttpContext.Current);
        }

        protected void All_Questions_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Serial_Number = (Label)e.Row.FindControl("Serial_Number");
                Label Question_Title = (Label)e.Row.FindControl("Question_Title");

                HtmlGenericControl ques_img_pnl = (HtmlGenericControl)e.Row.FindControl("ques_img_pnl");
                HtmlGenericControl ques_audio_pnl = (HtmlGenericControl)e.Row.FindControl("ques_audio_pnl");
                HtmlGenericControl ques_text_pnl = (HtmlGenericControl)e.Row.FindControl("ques_text_pnl");
                HtmlGenericControl ques_mcq_pnl = (HtmlGenericControl)e.Row.FindControl("ques_mcq_pnl");
                HtmlGenericControl ques_fill_up_pnl = (HtmlGenericControl)e.Row.FindControl("ques_fill_up_pnl");

                HtmlGenericControl ans_audio_pnl = (HtmlGenericControl)e.Row.FindControl("ans_audio_pnl");
                HtmlGenericControl ans_text_pnl = (HtmlGenericControl)e.Row.FindControl("ans_text_pnl");
                HtmlGenericControl ans_mcq_pnl = (HtmlGenericControl)e.Row.FindControl("ans_mcq_pnl");
                HtmlGenericControl ans_fill_ups_pnl = (HtmlGenericControl)e.Row.FindControl("ans_fill_ups_pnl");

                Panel Marks_Pnl = (Panel)e.Row.FindControl("Marks_Pnl");

                string Question_ID = DataBinder.Eval(e.Row.DataItem, "Question_ID").ToString();
               
                if (find.Question(Convert.ToInt32(Question_ID)).Rows.Count != 0)
                {
                    serial++;
                    Serial_Number.Text = "Question " + serial;
                    Question_Title.Text = find.Question(Convert.ToInt32(Question_ID)).Rows[0]["Title"].ToString();

                    string ques_test_temp = secure.Decrypt(find.Question(Convert.ToInt32(Question_ID)).Rows[0]["Text"].ToString(), "1111-2222-123123");
                    ques_text_pnl.InnerText = ques_test_temp;

                    string imggl = find.Question(Convert.ToInt32(Question_ID)).Rows[0]["Image"].ToString();
                    if(imggl != "" && imggl != null)
                    {
                        string image_output = "<img src='" + imggl + "' style='width:100%;' />";
                        ques_img_pnl.InnerHtml = "<h4>Following is the Image</h4>" + image_output;
                        ques_img_pnl.Visible = true;
                    }

                    string fle = find.Question(Convert.ToInt32(Question_ID)).Rows[0]["Audio"].ToString();
                    if (fle != "" && fle != null)
                    {
                        string audio_output = "<audio controls><source src='" + fle + "' type='audio/mpeg'>Your browser does not support the audio element.</audio>";
                        ques_audio_pnl.InnerHtml = "<h4>Following is the Audio</h4>" + audio_output;
                        ques_audio_pnl.Visible = true;
                    }

                    string mcqs = "";
                    for (int i = 0; i < find.MCQs(Question_ID).Rows.Count; i++)
                    {
                        if (find.MCQs(Question_ID).Rows[i]["Answer"].ToString() == "1")
                        {
                            mcqs = mcqs + "<div class='mcq' style='font-weight:bold; font-weight:small;'>" + (i + 1) + ") " + secure.Decrypt(find.MCQs(Question_ID).Rows[i]["MCQ"].ToString(), "1111-2222-123123") + "</div>";
                        }
                        else
                        {
                            mcqs = mcqs + "<div class='mcq' style='font-weight:small;' >" + (i + 1) + ") " + secure.Decrypt(find.MCQs(Question_ID).Rows[i]["MCQ"].ToString(), "1111-2222-123123") + "</div>";
                        }
                    }
                    if (mcqs != "" && mcqs != null)
                    {
                        ques_mcq_pnl.InnerHtml = "<h4>Following is the MCQs</h4>" + mcqs;
                        ques_mcq_pnl.Visible = true;
                    }
                        

                    string fill_up_temp = secure.Decrypt(find.Question(Convert.ToInt32(Question_ID)).Rows[0]["Fill_Ups"].ToString(), "1111-2222-123123"); ;
                    string fill_ups = "";
                    int idds = 0;
                    for (int i = 0; i < fill_up_temp.Length; i++)
                    {
                        if (fill_up_temp[i] == '{' && fill_up_temp[i + 1] == 'F' && fill_up_temp[i + 2] == 'I' && fill_up_temp[i + 3] == 'L' && fill_up_temp[i + 4] == 'L' && fill_up_temp[i + 5] == 'U' && fill_up_temp[i + 6] == 'P' && fill_up_temp[i + 7] == '}')
                        {
                            fill_ups = fill_ups + "<label style='font-weight;bold; margin:0.5%; border-radius:3px; padding-left:5%; padding-right:5%; font-size:small; background-color:whitesmoke; border:solid 1px gray; color:gray;'> fill up " + (idds + 1) + " </label>";
                            i = i + 7;
                            idds++;
                        }
                        else
                        {
                            fill_ups = fill_ups + fill_up_temp[i];
                        }
                    }
                    if (fill_ups != "" && fill_ups != null)
                    {
                        ques_fill_up_pnl.InnerHtml = "<h4>Following is the Fill Ups</h4>" + fill_ups;
                        ques_fill_up_pnl.Visible = true;
                    }
                        

                    //------------ANSWER------------------
                    if (Request.QueryString["gid"] != null)
                    {
                        string Giving_Ans_ID = DataBinder.Eval(e.Row.DataItem, "Giving_Ans_ID").ToString();

                        string Ans_MCQ_ID = DataBinder.Eval(e.Row.DataItem, "Ans_MCQ_ID").ToString();
                        string Ans_Fill_Ups = DataBinder.Eval(e.Row.DataItem, "Ans_Fill_Ups").ToString();

                        ans_text_pnl.InnerText = secure.Decrypt(DataBinder.Eval(e.Row.DataItem, "Ans_Text").ToString(), "1111-2222-123123"); ;
                        
                        if (ans_text_pnl.InnerText != "" && ans_text_pnl.InnerText != null)
                        {
                            ans_text_pnl.Visible = true;
                        }

                        string ansaudo = DataBinder.Eval(e.Row.DataItem, "Ans_Audio").ToString();
                        if (ansaudo != "" && ansaudo != null)
                        {
                            string audio_output = "<audio controls><source src='" + ansaudo + "' type='audio/mpeg'>Your browser does not support the audio element.</audio>";
                            ans_audio_pnl.InnerHtml = "<h4>Following is the Audio</h4>" + audio_output;
                            ans_audio_pnl.Visible = true;
                        }
                            

                        string mcq_temp_id = "";
                        string mcq_output = "";
                        for (int i = 0; i < Ans_MCQ_ID.Length; i++)
                        {
                            if (Ans_MCQ_ID[i] == ';')
                            {
                                if (find.MCQs(Convert.ToInt32(mcq_temp_id)).Rows.Count != 0)
                                {
                                    mcq_output = mcq_output + "⚬ <label class='mcq'>" + secure.Decrypt(find.MCQs(Convert.ToInt32(mcq_temp_id)).Rows[0]["MCQ"].ToString(), "1111-2222-123123") + "</label><br/><br/>";
                                    mcq_temp_id = "";
                                }
                            }
                            else
                            {
                                mcq_temp_id = mcq_temp_id + Ans_MCQ_ID[i];
                            }
                        }
                        if (mcq_output != "" && mcq_output != null)
                        {
                            ans_mcq_pnl.InnerHtml = "<h4>Following is the MCQ</h4>" + mcq_output;
                            ans_mcq_pnl.Visible = true;
                        }
                            

                        int j = 0;
                        fill_ups = "";
                        for (int i = 0; i < fill_up_temp.Length; i++)
                        {
                            if (fill_up_temp[i] == '{' && fill_up_temp[i + 1] == 'F' && fill_up_temp[i + 2] == 'I' && fill_up_temp[i + 3] == 'L' && fill_up_temp[i + 4] == 'L' && fill_up_temp[i + 5] == 'U' && fill_up_temp[i + 6] == 'P' && fill_up_temp[i + 7] == '}')
                            {
                                string tmp_fill_up = "";
                                while (j < Ans_Fill_Ups.Length && Ans_Fill_Ups[j] != ';')
                                {
                                    tmp_fill_up = tmp_fill_up + Ans_Fill_Ups[j];
                                    j++;
                                }
                                j++;

                                fill_ups = fill_ups + "<label style='font-weight;bold; margin:0.5%; border-radius:3px; padding-left:5%; padding-right:5%; font-size:small; background-color:whitesmoke; border:solid 1px gray; color:gray;'> " + tmp_fill_up + " </label>";
                                i = i + 7;
                            }
                            else
                            {
                                fill_ups = fill_ups + fill_up_temp[i];
                            }
                        }
                        if (fill_ups != "" && fill_ups != null)
                        {
                            ans_fill_ups_pnl.InnerHtml = "<h4>Following is the Fill Ups</h4>" + fill_ups;
                            ans_fill_ups_pnl.Visible = true;
                        }



                        Label Marks_get = (Label)e.Row.FindControl("Marks_get");
                        Label Remark_get = (Label)e.Row.FindControl("Remark_get");

                        if (find.Marking(Giving_Ans_ID).Rows.Count == 0 && (Admin_ID() != "0" || Student_ID() == "0"))
                        {
                            TextBox textBox = (TextBox)e.Row.FindControl("remark_box");
                            textBox.Visible = false;
                            int c = 0;
                            for (int i = 0; i < find.Marks(Question_ID).Rows.Count; i++)
                            {
                                Button Mark_btn = (Button)e.Row.FindControl("Mark_btn" + i);
                                Mark_btn.Visible = true;
                                Mark_btn.Text = find.Marks(Question_ID).Rows[i]["Mark"].ToString() + " - " + find.Marks(Question_ID).Rows[i]["Value"].ToString();
                                Mark_btn.CommandArgument = find.Marks(Question_ID).Rows[i]["Marks_ID"].ToString();
                                Mark_btn.CommandName = Giving_Ans_ID;
                                textBox.Visible = true;
                                c++;
                            }
                            if(c==0)
                            {
                                Marks_get.Text = "Unmarkable";
                                Remark_get.Text = "This question doesn't carry any mark.";
                            }
                            
                        }
                        else
                        {
                            string mark_id = find.Marking(Giving_Ans_ID).Rows.Count != 0 ? find.Marking(Giving_Ans_ID).Rows[0]["Marks_ID"].ToString() : "0";
                            Marks_get.Text = find.Marks(Convert.ToInt32(mark_id)).Rows.Count != 0 ? find.Marks(Convert.ToInt32(mark_id)).Rows[0]["Value"].ToString() : "UnCheck";
                            Remark_get.Text = find.Marking(Giving_Ans_ID).Rows.Count != 0 ? find.Marking(Giving_Ans_ID).Rows[0]["Remark"].ToString() : "No remark";
                        }
                    }
                }
            }
        }
        

        protected void All_Questions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Control control = (Control)e.CommandSource;
            GridViewRow gridViewRow = (GridViewRow)control.Parent.NamingContainer;
            
            TextBox textBox = (TextBox)gridViewRow.FindControl("remark_box");

            args[0] = e.CommandName;
            args[1] = e.CommandArgument.ToString();
            args[2] = textBox.Text;
            args[3] = "0";
            insertion.Marking(args);



            Label Marks_get = (Label)gridViewRow.FindControl("Marks_get");
            Marks_get.Text = find.Marks(Convert.ToInt32(e.CommandArgument)).Rows[0]["Value"].ToString();
        }
    }
}