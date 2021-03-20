using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class AddStudents : System.Web.UI.Page
    {
        Search search = new Search();
        Find find = new Find();
        Insertion insertion = new Insertion();
        Delete delete = new Delete();
        Secure secure = new Secure();
        static Updaters updaters = new Updaters();
        string[] args = new string[10];
        protected void Page_Load(object sender, EventArgs e)
        {
            ListItem listItem = new ListItem();
            listItem.Text = "Right Directions";
            listItem.Value = "Right Directions";
            Institute.Items.Add(listItem);

            for (int i = 0; i < search.Batches().Rows.Count; i++)
            {
                listItem = new ListItem();
                listItem.Text = search.Batches().Rows[i]["Title"].ToString();
                listItem.Value = search.Batches().Rows[i]["Batch_ID"].ToString();
                Batch.Items.Add(listItem);
            }
        }

        protected void Add_Student_Click(object sender, EventArgs e)
        {
            args[0] = Student_Name_box.Text;
            args[1] = Father_Name_box.Text;
            args[2] = secure.Encrypt(Contact.Text, "TSIE-GEHM-TAKUCF");
            args[3] = secure.Encrypt(Email.Text, "TSIE-GEHM-TAKUCF");
            args[4] = Batch.SelectedValue;
            args[5] = Date_Of_Join.Text;
            args[6] = Institute.SelectedValue;
            args[7] = Date_Of_Birth.Text;
            args[8] = "1";
            args[9] = secure.Encrypt("User", "TSIE-GEHM-TAKUCF");

            if (find.Check_Student(args[2]).Rows.Count == 0 && find.Check_Student(args[3]).Rows.Count == 0)
            {
                insertion.Students(args);
            }
            else
            {

            }
        }
    }
}