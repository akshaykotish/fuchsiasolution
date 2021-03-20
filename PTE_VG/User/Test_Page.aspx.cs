using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using PTE_VG.Kotish.Codes;
using System.Web.UI.WebControls;
using System.Net;

namespace PTE_VG
{
    public partial class Test_Page : System.Web.UI.Page
    {
        Search search = new Search();
        Find find = new Find();
        Updaters updaters = new Updaters();
        Insertion insertion = new Insertion();
        Delete delete = new Delete();
        Secure secure = new Secure();
        string[] args = new string[8];
        Timer timer = new Timer();
        int loaded_count = 0;
        string test_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if((Request.QueryString["Test_ID"] != null))
            {
                test_id = secure.Decrypt(Request.QueryString["Test_ID"], "MONE-YMAT-TERSLT");
                string student_id = Student_ID();
                string giving_id = Giving_ID(test_id);

                int q_count = find.Test_Maker(test_id).Rows.Count;
                int done_count = find.Giving_Ans(giving_id).Rows.Count;

                if(q_count > done_count)
                {
                    mbox.Visible = true;
                    if (!IsPostBack)
                    {
                        Load_Test(test_id);
                        loaded_count++;
                    }

                }
                else
                {
                    Response.Redirect("Sheets.aspx?gid=" + secure.Encrypt(giving_id, "momo-ctni-isbest") );
                }
            }
           
        }

        string Student_ID()
        {
            Student_Info student_Info = new Student_Info();
            return student_Info.Get_Cookie(HttpContext.Current);
        }

        string Batch_ID()
        {
            return find.Students(Student_ID()).Rows.Count != 0 ? find.Students(Student_ID()).Rows[0]["Batch_ID"].ToString() : "0";
        }

        string Batch_Test_ID(string test_id)
        {
            return find.Batch_Test(Batch_ID().ToString(), test_id).Rows.Count != 0 ? find.Batch_Test(Batch_ID().ToString(), test_id).Rows[0]["Batch_Test_ID"].ToString() : "0";
        }

       string Giving_ID(string test_id)
        {
            string student_id = Student_ID().ToString();
            string batch_test_id = Batch_Test_ID(test_id).ToString();
            return find.Giving(student_id, batch_test_id).Rows.Count != 0 ? find.Giving(student_id, batch_test_id).Rows[0]["Giving_ID"].ToString() : "0";
        }

        string Get_Time(string id)
        {
            return find.Question(Question_ID(id)).Rows.Count != 0 ? find.Question(Question_ID(id)).Rows[0]["Duration"].ToString() : "0";
        }

        void Load_Test(string id)
        {
            HttpCookie stdnt = new HttpCookie("student");
            if(stdnt != null)
            {
                Response.Cookies.Remove("student");
            }


            DataTable test_tbl = find.Test(id);
            int Question_ID_temp = Question_ID(id);
            if (test_tbl.Rows.Count != 0 && Question_ID_temp != 0 && find.Question(Question_ID_temp).Rows.Count != 0)
            {
                Test_Title.Text = test_tbl.Rows[0]["Name"].ToString();
                string question_title_temp = find.Question(Question_ID_temp).Rows[0]["Title"].ToString();
                Ques_Title.Text = question_title_temp;
                string question_text = find.Question(Question_ID_temp).Rows[0]["Text"].ToString();
                Ques_Text.Text = secure.Decrypt(question_text, "1111-2222-123123");
                Batch_Title.Text = find.Batches(Batch_ID().ToString()).Rows.Count != 0 ? find.Batches(Batch_ID().ToString()).Rows[0]["Title"].ToString() : "Unkown Batch";

                string ques = secure.Decrypt(find.Question(Question_ID_temp).Rows[0]["Image"].ToString(), "4444-2222-123456");
                if (ques != null && ques != "")
                {
                    string img_file = "Images/Question/" + ques;
                    string image_output = "<h5></h5><img src='" + img_file + "' style='width:100%;' />";
                    div_image_pnl.InnerHtml = image_output;
                }

                string aud = secure.Decrypt(find.Question(Question_ID_temp).Rows[0]["Audio"].ToString(), "4444-2222-123456");
                if (aud != null && aud != "")
                {
                    string adio_file = "Audio/Question/" + aud;
                    string audio_output = "<audio controls><source src='" + adio_file + "' type='audio/mpeg'>Your browser does not support the audio element.</audio>";
                    div_audio_pnl.InnerHtml = audio_output;
                }


                Clock_Duration.InnerText = Get_Time(id) == "0" ? "Unlimited" : Get_Time(id); ;

                Mcq_chk_boxs.Items.Clear();
                DataTable mcq_tbl = find.MCQs(Question_ID_temp.ToString());
                for (int i = 0; i < mcq_tbl.Rows.Count; i++)
                {
                    ListItem listItem = new ListItem();
                    listItem.Text = secure.Decrypt(mcq_tbl.Rows[i]["MCQ"].ToString(), "1111-2222-123123");
                    listItem.Value = mcq_tbl.Rows[i]["MCQ_ID"].ToString();
                    Mcq_chk_boxs.Items.Add(listItem);
                }

                fill_up_panel.Controls.Clear();
                string fill_up_temp = secure.Decrypt(find.Question(Question_ID_temp).Rows[0]["Fill_Ups"].ToString(), "1111-2222-123123");
                string output = "";
                int idds = 0;
                for (int i = 0; i < fill_up_temp.Length; i++)
                {
                    if (fill_up_temp[i] == '{' && fill_up_temp[i + 1] == 'F' && fill_up_temp[i + 2] == 'I' && fill_up_temp[i + 3] == 'L' && fill_up_temp[i + 4] == 'L' && fill_up_temp[i + 5] == 'U' && fill_up_temp[i + 6] == 'P' && fill_up_temp[i + 7] == '}')
                    {
                        Label label = new Label();
                        label.ID = "label" + idds;
                        label.Text = output;
                        fill_up_panel.Controls.Add(label);

                        TextBox textBox = new TextBox();
                        textBox.ID = "Fill_up" + idds;
                        //textBox.Text = "Fill_Up" + idds;
                        textBox.Text = "";
                        textBox.Load += TextBox_Load;
                        textBox.TextChanged += TextBox_TextChanged;
                        textBox.Attributes.Add("Placeholder", "Fill Up");
                        textBox.CssClass = "fillboxclass";
                        //textBox.CssClass = "fillboxclass flup";
                        fill_up_panel.Controls.Add(textBox);
                        output = "";
                        i = i + 7;
                        idds++;
                    }
                    else
                    {
                        output = output + fill_up_temp[i];
                    }

                    if(i == fill_up_temp.Length-1)
                    {
                        Label label = new Label();
                        label.ID = "label" + idds;
                        label.Text = output;
                        fill_up_panel.Controls.Add(label);
                    }
                }

                if(find.Question(Question_ID_temp).Rows[0]["Accept_Text"].ToString() != "1")
                {
                    text.Visible = false;
                }

                if (find.MCQs(Question_ID_temp).Rows.Count == 0)
                {
                    MCQs.Visible = false;
                }

                if (fill_up_temp.Length == 0)
                {
                    fillups.Visible = false;
                }

                if (find.Question(Question_ID_temp).Rows[0]["Audio_Ans"].ToString() != "1")
                {
                    ansAudio.Visible = false;
                } 
                

                Student_Cookie(id);
            }
        }

        void testtitle(string id)
        {

        }

        void Student_Cookie(string id)
        {
            HttpCookie stdnt = new HttpCookie("student");
            stdnt["student_id"] = Student_ID().ToString();
            stdnt["question_id"] = Question_ID(id).ToString();
            stdnt["giving_id"] = Giving_ID(id).ToString();
            stdnt["giving_ans_id"] = "NO";
            stdnt.Expires.Add(new TimeSpan(0, 30, 0));
            Response.Cookies.Add(stdnt);
        }

        private void TextBox_Load(object sender, EventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void Save_Audio_File()
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(audio_blob.Value);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Alert')</script>");
        }
        

        int Question_ID(string Test_id)
        {
            for(int i=0; i<find.Test_Maker(Test_id).Rows.Count; i++)
            {
                if(find.Giving_Ans(Giving_ID(Test_id).ToString(), find.Test_Maker(Test_id).Rows[i]["Question_ID"].ToString()).Rows.Count == 0)
                {
                    return Convert.ToInt32(find.Test_Maker(Test_id).Rows[i]["Question_ID"].ToString());
                }
            }

            return 0;
        }

        string Giving_Ans_ID_Cookie(string id)
        {
            HttpCookie stdnt = Request.Cookies["student"];
            if (stdnt != null)
            {
                string val = stdnt["giving_ans_id"].ToString();
                return val;
            }
            Response.Cookies.Remove("student");
            return "NO";
        }

        public void Submit_Question()
        {
            string fill_up_arr = fill_hdn.Value;
            string mcq_arr = "";
            for(int i=0; i<Mcq_chk_boxs.Items.Count; i++)
            {
                if(Mcq_chk_boxs.Items[i].Selected)
                {
                    mcq_arr = mcq_arr + Mcq_chk_boxs.Items[i].Value + ";";
                }
            }

            if (test_id != null)
            {
                args[0] = Giving_ID(test_id).ToString();
                args[1] = Question_ID(test_id).ToString();
                string timepass = live_time.Value;
                if(timepass != "" && timepass != null && timepass != "NaN")
                {
                    args[2] = (Convert.ToInt32(Get_Time(test_id)) - Convert.ToInt32(timepass)).ToString();
                }
                else
                {
                    args[2] = "0";
                }
                args[3] = secure.Encrypt(Text_ans.Text, "1111-2222-123123"); 
                args[4] = "";
                args[5] = mcq_arr;
                args[6] = fill_up_arr;
                args[7] = DateTime.Now.ToString();

                if (Giving_Ans_ID_Cookie(test_id) == "NO")
                {
                    insertion.Giving_Ans(args);
                }
                else
                {
                    updaters.Giving_Ans_for_audio(args, Giving_Ans_ID_Cookie(test_id));
                }

                if(Question_ID(test_id) == 0)
                {
                    Response.Redirect("/S_Home.aspx");
                }
                else
                {
                    Load_Test(test_id);
                }
                //Session["Load"] = "True";
                //Server.TransferRequest(HttpContext.Current.Request.Url.AbsoluteUri, false);
            }
        }
        
        

        protected void Time_Btn_Click(object sender, EventArgs e)
        {
            Submit_Question();
        }

        public void sample(string[] s_args)
        {
            for(int i=0; i<s_args.Length; i++)
            {
                Console.Write(s_args[i]);
            }
        }

        protected void Submit_Question_Btn_Click(object sender, EventArgs e)
        {
            Submit_Question();
        }

        protected void Save_Audio_Click(object sender, EventArgs e)
        {
            Save_Audio_File();
        }
    }
}