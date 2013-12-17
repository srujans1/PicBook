using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class Friends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string mid = "1";
            if (!IsPostBack)
            {
                string mid = (string)Session["mid"];
                refresh(mid);
            }
        }

        private void refresh(string mid)
        {
            Repeater1.DataSource = DAL.PicBookRepository.GetFriends(mid);
            //Repeater1.DataSource = DAL.ProductRepository.GetPins("1");
            Repeater1.DataBind();
        }

 
        protected void BtnDeleteFriend_Command(object sender, CommandEventArgs e)
        {
            DAL.PicBookRepository.DeleteFriend(Session["mid"].ToString(), e.CommandName);
            refresh(Session["mid"].ToString());
        }


        


    }
}