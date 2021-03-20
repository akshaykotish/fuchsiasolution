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
    public class Insertion
    {
        Connection con = new Connection();
        public void Batches(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into Batches values ('"+ args[0] + "', '" + args[1] + "', '" + args[2] + "','" + args[3] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }
        public void Marks(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into Marks values ('" + args[0] + "', '" + args[1] + "', '" + args[2] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }
        public void MCQs(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into MCQs values ('" + args[0] + "', '" + args[1] + "', '" + args[2] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }
        public void Questions(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into Questions values ('" + args[0] + "', '" + args[1] + "', '" + args[2] + "','" + args[3] + "','" + args[4] + "','" + args[5] + "','" + args[6] + "','" + args[7] + "', '" + args[8] + "', '" + args[9] + "', '" + args[10] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Test(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into Test values ('" + args[0] + "', '" + args[1] + "', '" + args[2] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }



        public void Test_Maker(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into Test_Maker values ('" + args[0] + "', '" + args[1] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Batch_Test(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into Batch_Test values ('" + args[0] + "', '" + args[1] + "', '" + args[2] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }
        public void Giving(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into Giving values ('" + args[0] + "', '" + args[1] + "', '" + args[2] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Giving_Ans(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into Giving_Ans values ('" + args[0] + "', '" + args[1] + "', '" + args[2] + "', '" + args[3] + "', '" + args[4] + "', '" + args[5] + "', '" + args[6] + "', '" + args[7] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Marking(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into Marking values ('" + args[0] + "', '" + args[1] + "', '" + args[2] + "', '" + args[3] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }
        public void Students(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into Students values ('" + args[0] + "', '" + args[1] + "', '" + args[2] + "', '" + args[3] + "', '" + args[4] + "', '" + args[5] + "', '" + args[6] + "', '" + args[7] + "', '" + args[8] + "', '" + args[9] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }

        public void Admins(string[] args)
        {
            con.con.Open();
            SqlCommand cmd = new SqlCommand("insert into Admins values ('" + args[0] + "', '" + args[1] + "', '" + args[2] + "', '" + args[3] + "', '" + args[4] + "', '" + args[5] + "')", con.con);
            cmd.ExecuteNonQuery();
            con.con.Close();
        }
    }
}