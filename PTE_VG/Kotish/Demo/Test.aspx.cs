using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PTE_VG.Kotish.Demo
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static object Update_Text(string text)
        {
            string data = @"{  
                'FirstName':'Jignesh',  
                'LastName':'Trivedi'  
                }";
            var details = JObject.Parse(data);
            return details;
            //Data data = new Data();
            //return data.Load();
        }
    }
}