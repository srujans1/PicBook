using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string mid = "1";
            string mid = HttpContext.Current.Request.QueryString["mid"];
            LblUserName.Text = DAL.PicBookRepository.GetUserName(mid);

            Repeater1.DataSource = DAL.PicBookRepository.GetBoards(mid);
            //Repeater1.DataSource = DAL.ProductRepository.GetPins("1");
            Repeater1.DataBind();
        }
    }
}