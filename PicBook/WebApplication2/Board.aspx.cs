using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class Board : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string bid = HttpContext.Current.Request.QueryString["bid"];
            Repeater1.DataSource = DAL.PicBookRepository.GetPins(bid);
            //Repeater1.DataSource = DAL.ProductRepository.GetPins("1");
            Repeater1.DataBind();
        }
    }
}