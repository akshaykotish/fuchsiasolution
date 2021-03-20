using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace PTE_VG.Kotish.Codes
{
    public class Delete
    {
        Connection con = new Connection();


        public void Question(string Ques_ID)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("delete from Questions where Question_ID = '" + Ques_ID + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }


        public void Test_Maker(string Test_Id, string Ques_ID)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("delete from Test_Maker where Test_ID = '"+ Test_Id +"' and Question_ID = '"+ Ques_ID +"'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Batch_Test(int Batch_ID, int Test_Id)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("delete from Batch_Test where Batch_ID = '" + Batch_ID + "' and Test_ID = '" + Test_Id + "'", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }
    }
}