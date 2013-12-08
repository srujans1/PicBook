using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class Home : System.Web.UI.Page
    {

        [WebMethod]
        public static IEnumerable<DAL.Pin> GetPins(string mid)
        {
            
            return DAL.PicBookRepository.GetPins(mid);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //string mid = "1";
            string mid = (string)Session["mid"];
            Repeater1.DataSource = DAL.PicBookRepository.GetBoards(mid);
            //Repeater1.DataSource = DAL.ProductRepository.GetPins("1");
            Repeater1.DataBind();

        }

      
    }
}