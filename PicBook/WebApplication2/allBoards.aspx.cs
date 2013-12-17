using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class allBoards : System.Web.UI.Page
    {
        [WebMethod]
        public static IEnumerable<PicBook.Models.Pin> GetPins(string mid)
        {

            return DAL.PicBookRepository.GetPins(mid);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string mid = "1";
                string mid = (string)Session["mid"];
                LblUserName.Text = DAL.PicBookRepository.GetUserName(mid);

                Repeater1.DataSource = DAL.PicBookRepository.GetBoards(mid);
                //Repeater1.DataSource = DAL.ProductRepository.GetPins("1");
                Repeater1.DataBind();

                lblFBoards.Text = LblUserName.Text;

                Repeater2.DataSource = DAL.PicBookRepository.GetFollowingBoards(mid);
                //Repeater1.DataSource = DAL.ProductRepository.GetPins("1");
                Repeater2.DataBind();
            }
        }

    }
}