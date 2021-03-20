using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class AddAdmin : System.Web.UI.Page
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
            

        }

        protected void Add_Admin_Click(object sender, EventArgs e)
        {
            args[0] = Admin_Name_box.Text;
            args[1] = secure.Encrypt(Contact.Text, "TSIE-GEHM-TAKUCF");
            args[2] = secure.Encrypt(Email.Text, "TSIE-GEHM-TAKUCF");
            args[3] = secure.Encrypt("Admin", "TSIE-GEHM-TAKUCF"); 
            args[4] = Institute.SelectedValue; 
            args[5] = "1";

            if (find.Check_Admin(args[1]).Rows.Count == 0 && find.Check_Admin(args[2]).Rows.Count == 0)
            {
                insertion.Admins(args);
            }
            else
            {

            }
        }
    }
}