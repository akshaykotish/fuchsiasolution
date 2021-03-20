using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PTE_VG.Kotish.Codes;

namespace PTE_VG.Admin_.APIs
{
    /// <summary>
    /// Summary description for Data
    /// </summary>
    public class Data : IHttpHandler
    {
        Search search = new Search();
        Find find = new Find();
        Insertion insertion = new Insertion();
        Delete delete = new Delete();
        Secure secure = new Secure();
        Updaters updaters = new Updaters();
        string[] args = new string[5];

        public void ProcessRequest(HttpContext context)
        {
            if(context.Request.QueryString["Batch"] != null)
            {
                context.Response.Write(Students(context.Request.QueryString["Batch"]));
            }
            else if (context.Request.QueryString["Batch_Name"] != null)
            {
                context.Response.Write(Batches(context.Request.QueryString["Batch_Name"]));
            }
            else if(context.Request.QueryString["Add_Batch"] != null && context.Request.QueryString["Add_Batch"] == "Yes")
            {
                string data = context.Request["title"].ToString();
                string data1 = context.Request["details"].ToString();
                Add_Batch(data, data1);
            }
            else if(context.Request.QueryString["BLOCK_USER"] != null && context.Request.QueryString["BLOCK_USER"] == "Yes")
            {
                Change_Block(context.Request["name"].ToString(), context.Request["email"].ToString(), context.Request["contact"].ToString(), context.Request["block"].ToString());
            }
            else if (context.Request.QueryString["Change_Batch"] != null && context.Request.QueryString["Change_Batch"] == "Yes")
            {
                Change_Batch(context.Request["name"].ToString(), context.Request["email"].ToString(), context.Request["contact"].ToString(), context.Request["batch"].ToString());
            }
            else if(context.Request.QueryString["Question_Name"] != null)
            {
                context.Response.Write(Questions(context.Request.QueryString["Question_Name"]));
            }
            else if (context.Request.QueryString["Edit_Question"] != null && context.Request.QueryString["Edit_Question"] == "Yes")
            {
                string title = context.Request["Question_Name"].ToString();
                string type = context.Request["Question_Type"].ToString();
                string created_on = context.Request["Question_Created_On"].ToString();
                context.Response.Write(Question_Edit(title, type, created_on));
            }
            else if (context.Request.QueryString["Delete_Question"] != null && context.Request.QueryString["Delete_Question"] == "Yes")
            {
                string title = context.Request["Question_Name"].ToString();
                string type = context.Request["Question_Type"].ToString();
                string created_on = context.Request["Question_Created_On"].ToString();
                context.Response.Write(Question_Delete(title, type, created_on));
            }
            else if(context.Request.QueryString["Test_Name"] != null)
            {
                context.Response.Write(Tests(context.Request.QueryString["Test_Name"]));
            }
            else if (context.Request.QueryString["Test_Questions"] != null)
            {
                context.Response.Write(Load_Questions((context.Request.QueryString["Test_Questions"])));
            }
            else if (context.Request.QueryString["Add_Q_T"] != null && context.Request.QueryString["T"] != null && context.Request.QueryString["Q"] != null)
            {
                context.Response.Write(Add_Question_To_Test(context.Request.QueryString["Q"], context.Request.QueryString["T"]));
            }
            else if (context.Request.QueryString["Remove_Q_T"] != null && context.Request.QueryString["T"] != null && context.Request.QueryString["Q"] != null)
            {
                context.Response.Write(Remove_Question_To_Test(context.Request.QueryString["Q"], context.Request.QueryString["T"]));
            }
            


        }

        private string Students(string batch_name)
        {
            string data = "";
            string Batch_ID = find.Batch_Name(batch_name).Rows.Count != 0 ? find.Batch_Name(batch_name).Rows[0]["Batch_ID"].ToString() : "0";
            DataTable dt = search.Students();
            for(int i=0; i<dt.Rows.Count; i++)
            {
                int Activate = 0;
                if(dt.Rows[i]["Batch_ID"].ToString() == Batch_ID)
                {
                    Activate = 1;
                }
                    data = data + dt.Rows[i]["Name"].ToString() + "," + dt.Rows[i]["Father_Name"].ToString() + "," +
                   secure.Decrypt(dt.Rows[i]["Contact"].ToString(), "TSIE-GEHM-TAKUCF") + "," + secure.Decrypt(dt.Rows[i]["Email"].ToString(), "TSIE-GEHM-TAKUCF") + "," +
                   dt.Rows[i]["Date_Of_Join"].ToString() + "," +
                    dt.Rows[i]["Institute"].ToString().Substring(0, 10) + "," + dt.Rows[i]["Date_Of_Birth"].ToString().Substring(0, 10) + "," +
                    dt.Rows[i]["Status"].ToString() + "," + Activate.ToString() + ";";
            }
            return data;
        }

        private string Batches(string batch_name)
        {
            string data = "";
            DataTable dt = new DataTable();
            if (batch_name == "ALL")
            {
                dt = search.Batches();
                
            }
            else
            {
                dt = find.Batch_Name(batch_name);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = data + dt.Rows[i]["Title"].ToString() + "," + find.Students_Batch(dt.Rows[i]["Batch_ID"].ToString()).Rows.Count.ToString() + "," + "Students" + "," +
               "Created On" + "," + dt.Rows[i]["Created_On"].ToString().Substring(0, 10) + "," +
               "Total Assignment" + "," + find.Batch_Test_BATCHID(dt.Rows[i]["Batch_ID"].ToString()).Rows.Count.ToString() + "," + ";";
            }
            return data;
        }

        private string Add_Batch(string title, string details)
        {
            string[] args = new string[4];
            args[0] = title;
            args[1] = "0";
            args[2] = DateTime.Now.ToString();
            args[3] = details;
            insertion.Batches(args);
            return "Created Sucessfully";
        }

        private string Change_Block(string name, string email, string contact, string current)
        {
            
            string student_id = find.Check_Student(name, secure.Encrypt(email, "TSIE-GEHM-TAKUCF"), secure.Encrypt(contact, "TSIE-GEHM-TAKUCF")).Rows.Count != 0 ? find.Check_Student(name, secure.Encrypt(email, "TSIE-GEHM-TAKUCF"), secure.Encrypt(contact, "TSIE-GEHM-TAKUCF")).Rows[0]["Student_Id"].ToString() : "0";
            if(current == "0")
            {
                updaters.Student_Status(student_id, "1");
            }
            else
            {
                updaters.Student_Status(student_id, "0");
            }
            return "Changed Sucessfully";
        }

        string Change_Batch(string name, string email, string contact, string batch)
        {
            string student_id = find.Check_Student(name, secure.Encrypt(email, "TSIE-GEHM-TAKUCF"), secure.Encrypt(contact, "TSIE-GEHM-TAKUCF")).Rows.Count != 0 ? find.Check_Student(name, secure.Encrypt(email, "TSIE-GEHM-TAKUCF"), secure.Encrypt(contact, "TSIE-GEHM-TAKUCF")).Rows[0]["Student_Id"].ToString() : "0";
            if (batch != "0")
            {
                string batch_id = find.Batch_Name(batch).Rows.Count != 0 ? find.Batch_Name(batch).Rows[0]["Batch_ID"].ToString() : "0";

                updaters.Student_Batch(batch_id, student_id);
            }
            else
            {
                updaters.Student_Batch("0", student_id);
            }
            return "Changed Sucessfully";
        }

        string Questions(string question)
        {
            string data = "";
            DataTable dt = new DataTable();
            if (question == "ALL")
            {
                dt = search.Question();

            }
            else
            {
                dt = find.Question(question);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = data + dt.Rows[i]["Title"].ToString() + "," + dt.Rows[i]["Type"].ToString().Substring(0, 1).ToUpper() + "," + dt.Rows[i]["Type"].ToString() + "," +
               "Created On" + "," + dt.Rows[i]["TimeStamp"].ToString().Substring(0, 10) + "," +
               "Total Tests" + "," + find.Test_Maker_QUESTION(dt.Rows[i]["Question_ID"].ToString()).Rows.Count + "," + ";";
            }
            return data;
        }


        string  Question_Edit(string Title, string Type, string Created_On)
        {
            string ID = find.Question(Title).Rows.Count != 0 ? find.Question(Title).Rows[0]["Question_ID"].ToString() : "0";
            string Q_id = secure.Encrypt(ID, "4444-0495-253535");
            return Q_id;
        }

        string Question_Delete(string Title, string Type, string Created_On)
        {
            string ID = find.Question(Title).Rows.Count != 0 ? find.Question(Title).Rows[0]["Question_ID"].ToString() : "0";
            delete.Question(ID);
            return "True";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private string Tests(string test)
        {
            string data = "";
            DataTable dt = new DataTable();
            if (test == "ALL")
            {
                dt = search.Test();

            }
            else
            {
                dt = find.Test_NAME(test);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = data + dt.Rows[i]["Name"].ToString() + "," + find.Batch_Test(dt.Rows[i]["Test_ID"].ToString()).Rows.Count.ToString() + "," + "Assigns" + "," +
               "Created On" + "," + dt.Rows[i]["TimeStamp"].ToString().Substring(0, 10) + "," +
               "Total Questions" + "," + find.Test_Maker(dt.Rows[i]["Test_ID"].ToString()).Rows.Count.ToString() + "," + ";";
            }
            return data;
        }

        private string Load_Questions(string test_name)
        {
            string questions = "";
            string test_id = find.Test_NAME(test_name).Rows.Count!=0 ? find.Test_NAME(test_name).Rows[0]["Test_ID"].ToString() : "0";

            string q1 = "";
            string q2 = "";

            DataTable qt = search.Question();
            for (int i = 0; i < qt.Rows.Count; i++)
            {
                DataTable dt = find.Test_Maker(Convert.ToInt32(test_id), Convert.ToInt32(qt.Rows[i]["Question_ID"].ToString()));
                if (dt.Rows.Count != 0)
                {
                    q1 = q1 + qt.Rows[i]["Title"].ToString() + "," + qt.Rows[i]["Type"].ToString().Substring(0, 1).ToUpper() + "," + qt.Rows[i]["Type"].ToString() + "," +
               "Created On" + "," + qt.Rows[i]["TimeStamp"].ToString().Substring(0, 10) + "," +
               "Total Tests" + "," + find.Test_Maker_QUESTION(qt.Rows[i]["Question_ID"].ToString()).Rows.Count + "," + "1," + secure.Encrypt(qt.Rows[i]["Question_ID"].ToString(), "4444-0495-253535") + ";";
                }
                else
                {
                    q2 = q2 + qt.Rows[i]["Title"].ToString() + "," + qt.Rows[i]["Type"].ToString().Substring(0, 1).ToUpper() + "," + qt.Rows[i]["Type"].ToString() + "," +
               "Created On" + "," + qt.Rows[i]["TimeStamp"].ToString().Substring(0, 10) + "," +
               "Total Tests" + "," + find.Test_Maker_QUESTION(qt.Rows[i]["Question_ID"].ToString()).Rows.Count + "," + "0," + secure.Encrypt(qt.Rows[i]["Question_ID"].ToString(), "4444-0495-253535") + ";";
                }
            }
            questions = q1 + q2;
            return questions;
        }

        private string Add_Question_To_Test(string question_name, string test_name)
        {
            args[0] = find.Test_NAME(test_name).Rows.Count != 0 ? find.Test_NAME(test_name).Rows[0]["Test_ID"].ToString() : "0";
            args[1] = find.Question(question_name).Rows.Count != 0 ? find.Question(question_name).Rows[0]["Question_ID"].ToString() : "0";
            insertion.Test_Maker(args);
            return "Succed";
        }
        private string Remove_Question_To_Test(string question_name, string test_name)
        {
            args[0] = find.Test_NAME(test_name).Rows.Count != 0 ? find.Test_NAME(test_name).Rows[0]["Test_ID"].ToString() : "0";
            args[1] = find.Question(question_name).Rows.Count != 0 ? find.Question(question_name).Rows[0]["Question_ID"].ToString() : "0";
            delete.Test_Maker(args[0], args[1]);
            return "Succed";
        }

    }
}