using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace PTE_VG.Kotish.Codes
{
    public class Find
    {
        Connection con = new Connection();

        public DataTable Question(int Id)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Questions where Question_ID = '"+ Id +"'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Question(string keyword)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Questions where Title like '%"+ keyword +"%' or Text like '%"+ keyword +"%' or Image like '%"+ keyword +"%' or Audio like '%"+ keyword +"%' or PDF like '%"+ keyword + "%' or Fill_Ups like '%" + keyword + "%' or Type like '%" + keyword + "%'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        
        public DataTable Test_Maker(string keyword)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Test_Maker where Test_ID = '" + keyword + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Test_Maker_QUESTION(string keyword)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Test_Maker where Question_ID = '" + keyword + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Test_Maker(int Test_ID, int Question_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Test_Maker where Test_ID = '" + Test_ID + "' and Question_ID = '"+ Question_ID +"'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Batch_Name(string Batch_Name)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Batches where Title like '%" + Batch_Name + "%'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Batches(string Batch_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Batches where Batch_ID = '" + Batch_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Batch_Test(string Batch_Test_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Batch_Test where  Batch_Test_ID = '" + Batch_Test_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Batch_Test(string Batch_ID, string Test_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Batch_Test where  Batch_ID = '" + Batch_ID + "' and Test_ID = '" + Test_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Batch_Test_BATCHID(string Batch_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Batch_Test where  Batch_ID = '" + Batch_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public DataTable Batch_Test_TestID(string Test_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Batch_Test where  Test_ID = '" + Test_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Batch_Test(string Batch_ID, string Test_ID, string TimeStamp)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Batch_Test where  Batch_ID = '" + Batch_ID + "' and Test_ID = '" + Test_ID + "' and TimeStamp = '" + TimeStamp + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Test(string Test_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Test where Test_ID = '" + Test_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Test(string Test_ID, string keyword)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Test where Test_ID = '" + Test_ID + "' and Name like '%" + keyword + "%'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Test_NAME(string Name)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Test where Name like '%" + Name + "%'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Giving(string Batch_Test_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Giving where Batch_Test_ID = '" + Batch_Test_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Giving_BATCH(string Batch_Test_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Giving where Batch_Test_ID = '" + Batch_Test_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Giving(string Student_ID, string Batch_Test_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Giving where Student_ID = '" + Student_ID + "' and Batch_Test_ID = '"+ Batch_Test_ID +"'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Giving_Ans(string Giving_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Giving_Ans where Giving_ID = '" + Giving_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Giving_Ans(string Giving_ID, string Ques_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Giving_Ans where Giving_ID = '" + Giving_ID + "' and Question_ID = '"+ Ques_ID +"'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable MCQs(string Ques_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from MCQs where Question_ID = '" + Ques_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable MCQs(int MCQ_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from MCQs where MCQ_ID = '" + MCQ_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Marks(string Question_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Marks where Question_ID = '" + Question_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Marks(int Marks_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Marks where Marks_ID = '" + Marks_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Admin(string Admin_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Admins where Admin_ID = '" + Admin_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Admin(string User_ID, string Password)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Admins where (Email = '" + User_ID + "' or Contact = '" + User_ID + "') and Password = '" + Password + "' ", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Students(string Student_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Students where Student_ID = '" + Student_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Students(string User_ID, string Password)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Students where (Email = '" + User_ID + "' or Contact = '" + User_ID + "') and Password = '"+ Password +"' ", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Student_All(string keyword)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Students where Name like '%" + keyword + "%' or Father_Name like '%"+ keyword +"%' or Contact like '%"+ keyword +"%' or Email like '%"+ keyword  +"%'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Check_Student(string name, string email, string contact)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Students where Name = '"+ name +"' and Contact = '" + contact + "' and Email = '" + email + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Check_Student(string keyword)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Students where  Contact = '" + keyword + "' or Email = '" + keyword + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Admin_All(string keyword)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Admins where Name like '%" + keyword + "%' or Contact like '%" + keyword + "%' or Email like '%" + keyword + "%'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Check_Admin(string keyword)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Admins where Contact = '" + keyword + "' or Email = '" + keyword + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Student_Name(string Student_Name)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Students where Name like '%" + Student_Name + "%'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Students_Batch(string Batch_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Students where Batch_ID = '" + Batch_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Marking(string Giving_Ans_ID, string Marks_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Marking where Giving_Ans_ID = '" + Giving_Ans_ID + "' and Marks_ID = '"+ Marks_ID +"'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Marking(string Giving_Ans_ID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Marking where Giving_Ans_ID = '" + Giving_Ans_ID + "'", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

    }
}