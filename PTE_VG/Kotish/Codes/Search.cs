using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PTE_VG.Kotish.Codes
{
    public class Search
    {
        Connection con = new Connection();

        public DataTable Question()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Questions", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Batches()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Batches", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Test()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Test", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Batch_Test()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Batch_Test", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Students()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Students", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Admins()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Admins", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
        public DataTable Test_Maker()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Test_Maker", con.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}