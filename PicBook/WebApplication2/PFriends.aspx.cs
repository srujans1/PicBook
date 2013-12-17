using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class PFriends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshFRequests();
            }
        }

        private void RefreshFRequests()
        {
            string mid = (string)Session["mid"];
            Repeater1.DataSource = DAL.PicBookRepository.GetPFriends(mid);
            //Repeater1.DataSource = DAL.ProductRepository.GetPins("1");
            Repeater1.DataBind();
        }

        protected void BtnReject_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {

                case "accept":
                    DAL.PicBookRepository.UpdateFriendRequest(Session["mid"].ToString(), e.CommandArgument.ToString(), "y");
                    RefreshFRequests();
                    break;

                case "reject":
                    DAL.PicBookRepository.UpdateFriendRequest(Session["mid"].ToString(), e.CommandArgument.ToString(), "n");
                    RefreshFRequests();
                    break;


                    // Test whether the command argument is an empty string ("").

                    break;

                default:


                    break;

            }

        }

    }
}