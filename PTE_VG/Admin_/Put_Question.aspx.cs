using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Put_Question : System.Web.UI.Page
    {
        public static Put_Question put_Question = new Put_Question();
        Insertion insertion = new Insertion();
        Updaters updater = new Updaters();
        Find find = new Find();
        static Secure secure = new Secure();
        HttpCookie reqCookies;
        HttpCookie userInfo = new HttpCookie("Question_Info");
        int id = 0;
        string[] args = new string[11];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Create_Question"] == "TRUE" && Request.QueryString["Keyword"] == "OMNI")
                {
                    Create_Question();
                }
                if (Request.QueryString["QID"] != null)
                {
                    string qid = secure.Decrypt(Request.QueryString["QID"], "4444-0495-253535");
                    if (find.Question(Convert.ToInt32(qid)).Rows.Count != 0)
                    {
                        args[0] = ttl_box.Value = find.Question(Convert.ToInt32(qid)).Rows[0]["Title"].ToString();
                        args[1] = dur_box.Value = find.Question(Convert.ToInt32(qid)).Rows[0]["Duration"].ToString();
                        args[2] = text_ans.Value = secure.Decrypt(find.Question(Convert.ToInt32(qid)).Rows[0]["Text"].ToString(), "1111-2222-123123");
                        args[6] = fill_up_box.Value = secure.Decrypt(find.Question(Convert.ToInt32(qid)).Rows[0]["Fill_Ups"].ToString(), "1111-2222-123123");
                        if (find.Question(Convert.ToInt32(qid)).Rows[0]["Audio_Ans"].ToString() == "1")
                        {
                            args[8] = "1";
                            aud_ans.Checked = true;
                        }
                        if(find.Question(Convert.ToInt32(qid)).Rows[0]["Accept_Text"].ToString() == "1")
                        {
                            args[7] = "1";
                            text_ans.Checked = true;
                        }
                        args[10] = find.Question(Convert.ToInt32(qid)).Rows[0]["Type"].ToString();

                        string out_mcq = "";
                        for (int i=0; i<find.MCQs(qid).Rows.Count; i++)
                        {
                            if(find.MCQs(qid).Rows[i]["Answer"].ToString() == "1")
                            {
                                out_mcq = out_mcq + "<span class='mcq ans'>" + (i + 1) + ") " + secure.Decrypt(find.MCQs(qid).Rows[i]["MCQ"].ToString(), "1111-2222-123123") + "</span>";
                            }
                            else
                            {
                                out_mcq = out_mcq + "<span class='mcq'>" + (i + 1) + ") " + secure.Decrypt(find.MCQs(qid).Rows[i]["MCQ"].ToString(), "1111-2222-123123") + "</span>";
                            }
                        }
                        MCQs.InnerHtml = out_mcq;

                        args[3] = null;
                        args[4] = null;
                        args[5] = null;
                        args[8] = null;
                        args[9] = DateTime.Now.ToString();
                        args[10] = "Unknown";
                        args_2_cookies();
                    }
                }
            }
            reqCookies = Request.Cookies["Question_Info"];
            if (reqCookies != null)
            {
                cookies_2_args();
            }
            else
            {
                reqCookies = HttpContext.Current.Request.Cookies["Question_Info"];
                if(reqCookies != null)
                {
                    cookies_2_args();
                }
            }

        }

        int check_id()
        {
            HttpCookie objHTTPCk = HttpContext.Current.Request.Cookies.Get("Question_Info");
            if (reqCookies != null)
            {
                string title = reqCookies["Q_Title"].ToString();
                id = Convert.ToInt32(find.Question(title).Rows.Count != 0 ? find.Question(title).Rows[0]["Question_ID"].ToString() : "0");
            }
            else if (objHTTPCk != null)
            {
                string title = objHTTPCk["Q_Title"].ToString();
                id = Convert.ToInt32(find.Question(title).Rows.Count != 0 ? find.Question(title).Rows[0]["Question_ID"].ToString() : "0");
            }
            return id;
        }

        void intialize_args()
        {
            args[0] = "Untitled " + DateTime.Now.ToString();
            args[1] = "0";
            args[2] = null;
            args[3] = null;
            args[4] = null;
            args[5] = null;
            args[6] = null;
            args[7] = "0";
            args[8] = null;
            args[9] = DateTime.Now.ToString();
            args[10] = "Unknown";
        }
        

        void args_2_cookies()
        {
            userInfo["Q_Title"] = args[0];
            userInfo["Q_Duration"] = args[1];
            userInfo["Q_Text"] = args[2];
            userInfo["Q_Image"] = args[3];
            userInfo["Q_Audio"] = args[4];
            userInfo["Q_PDF"] = args[5];
            userInfo["Q_Fill_Ups"] = args[6];
            userInfo["Q_Audio_Ans"] = args[7];
            userInfo.Expires.Add(new TimeSpan(0, 1, 0));
            HttpContext.Current.Response.Cookies.Add(userInfo);
        }

        void cookies_2_args()
        {
            try
            {
                args[0] = reqCookies["Q_Title"].ToString();
                args[1] = reqCookies["Q_Duration"].ToString();
                args[2] = reqCookies["Q_Text"].ToString();
                args[3] = reqCookies["Q_Image"].ToString();
                args[4] = reqCookies["Q_Audio"].ToString();
                args[5] = reqCookies["Q_PDF"].ToString();
                args[6] = reqCookies["Q_Fill_Ups"].ToString();
                args[7] = reqCookies["Accept_Text"].ToString();
                args[8] = reqCookies["Q_Audio_Ans"].ToString();
                args[10] = reqCookies["Q_Fill_Ups"].ToString();
            }
            catch { }
        }

        public void Create_Question()
        {
            intialize_args();
            insertion.Questions(args);
            args_2_cookies();
        }

        [WebMethod]
        public static string RegisterUser(string email, string password)
        {
            Put_Question put_Question = new Put_Question();
            put_Question.args[0] = "";
            return "SSS";
        }

        [WebMethod]
        public static string Update_Text(string text)
        {
            text = secure.Encrypt(text, "1111-2222-123123");
            put_Question.updater.Question_Text(text, put_Question.check_id());
            put_Question.args[2] = text;
            return "True";
        }

        [WebMethod]
        public static string MCQ_Add(string text, string ans)
        {
            put_Question.args[0] = put_Question.check_id().ToString();
            put_Question.args[1] = secure.Encrypt(text, "1111-2222-123123");
            put_Question.args[2] = ans;
            put_Question.insertion.MCQs(put_Question.args);
            return "True";
        }

        [WebMethod]
        public static string Accept_Audio_(string answer)
        {
            put_Question.updater.Question_Audio_Ans(answer, put_Question.check_id());
            put_Question.args[4] = answer;
            return "True";
        }

        [WebMethod]
        public static string Update_Fill_Ups(string fillups)
        {
            fillups = secure.Encrypt(fillups, "1111-2222-123123");
            put_Question.updater.Question_Fill_Ups(fillups, put_Question.check_id());
            put_Question.args[6] = fillups;
            return "True";
        }

        [WebMethod]
        public static string Update_Details(string title, string duration, string type)
        {
            put_Question.updater.Question_Type(type, put_Question.check_id());
            put_Question.updater.Question_Duration(duration, put_Question.check_id());
            put_Question.updater.Question_Title(title, put_Question.check_id());
            put_Question.args[0] = title;
            put_Question.args[1] = duration;
            put_Question.args[10] = type;
            return "True";
        }

        [WebMethod]
        public static string Marking_Scheme(string name, string value)
        {
            string[] args = new string[3];
            args[0] = put_Question.check_id().ToString();
            args[1] = name;
            args[2] = value;
            put_Question.insertion.Marks(args);
            return "True";
        }

        [WebMethod]
        public static string Accept_Texts(string acpt_text)
        {
            put_Question.updater.Question_Accept_Text(acpt_text, put_Question.check_id());
            put_Question.args[7] = acpt_text;
            return "True";
        }
    }
}