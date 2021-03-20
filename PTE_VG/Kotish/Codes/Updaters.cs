using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PTE_VG.Kotish.Codes
{
    public class Updaters
    {
        Connection con = new Connection();
        public void Question_Title(string text, int id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Questions set Title = '"+ text +"' where Question_ID = '"+ id +"'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Question_Duration(string text, int id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Questions set Duration = '" + text + "' where Question_ID = '" + id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Question_Accept_Text(string text, int id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Questions set Accept_Text = '" + text + "' where Question_ID = '" + id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Question_Type(string text, int id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Questions set Type = '" + text + "' where Question_ID = '" + id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Question_Text(string text, int id)
        {

            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Questions set Text = '" + text + "' where Question_ID = '" + id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Question_Image(string text, int id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Questions set Image = '" + text + "' where Question_ID = '" + id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Question_Audio(string text, int id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Questions set Audio = '" + text + "' where Question_ID = '" + id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Question_PDF(string text, int id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Questions set PDF = '" + text + "' where Question_ID = '" + id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Question_Fill_Ups(string text, int id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Questions set Fill_Ups = '" + text + "' where Question_ID = '" + id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }


        public void Question_Audio_Ans(string text, int id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Questions set Audio_Ans = '" + text + "' where Question_ID = '" + id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Giving_Ans(string[] args, string id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Giving_Ans set Giving_ID = '" + args[0] + "',Question_ID = '" + args[1] + "', Time_Taken = '"+ args[2] +"', Ans_Text = '"+ args[3] + "', Ans_Audio = '" + args[4] + "', Ans_MCQ_ID = '" + args[5] + "', Ans_Fill_Ups = '" + args[6] + "', Time_Stamp = '" + args[7] + "' where Giving_Ans_ID = '" + id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Giving_Ans_for_audio(string[] args, string id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Giving_Ans set Time_Taken = '" + args[2] + "', Ans_Text = '" + args[3] + "', Ans_MCQ_ID = '" + args[5] + "', Ans_Fill_Ups = '" + args[6] + "', Time_Stamp = '" + args[7] + "' where Giving_Ans_ID = '" + id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Student_Batch(string batch_id, string student_id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Students set Batch_ID = '" + batch_id + "' where Student_Id = '" + student_id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Student_Status(string contact, string email, string name, string status)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Students set Status = '"+ status + "' where Contact = '" + contact + "' and Email = '" + email + "'", con.con);
            cmd.ExecuteNonQuery(); 
            con.con.Close(); 
        }
        public void Student_Status(string Student_ID, string status)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Students set Status = '" + status + "' where Student_Id = '" + Student_ID + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Admin_Status(string Admin_ID, string status)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Admins set Status = '" + status + "' where Admin_Id = '" + Admin_ID + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Student(string[] args, string Student_ID)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Students set Name = '" + args[0] + "', Father_Name = '" + args[1] + "',Contact = '" + args[2] + "',Email = '" + args[3] + "',Batch_ID = '" + args[4] + "',Date_Of_Join = '" + args[5] + "',Institute = '" + args[6] + "',Date_of_Birth = '" + args[7] + "',Status = '" + args[8] + "',Password = '" + args[9] + "' where Student_Id = '" + Student_ID + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Admin(string[] args, string Admin_ID)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("update Admins set Name = '" + args[0] + "', Contact = '" + args[1] + "', Email = '" + args[2] + "', Password = '" + args[3] + "', Institute = '" + args[4] + "', Status = '" + args[5] + "' where Admin_Id = '" + Admin_ID + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }
    }

}