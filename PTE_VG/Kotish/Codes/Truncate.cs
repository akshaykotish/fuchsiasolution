using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PTE_VG.Kotish;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PTE_VG.Kotish.Codes
{
    public class Truncate
    {
        Connection con = new Connection();
        public void All()
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("truncate table Batch_Test", con.con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("truncate table Batches", con.con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("truncate table Giving", con.con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("truncate table Giving_Ans", con.con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("truncate table Marking", con.con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("truncate table Marks", con.con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("truncate table MCQs", con.con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("truncate table Questions", con.con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("truncate table Students", con.con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("truncate table Test", con.con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("truncate table Test_Maker", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }
    }
}