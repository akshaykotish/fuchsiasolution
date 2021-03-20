using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTE_VG.Kotish.Codes;

namespace PTE_VG
{
    public partial class Truncate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PTE_VG.Kotish.Codes.Truncate truncate = new Kotish.Codes.Truncate();
            truncate.All();
        }
    }
}