using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class FStream : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string mid = "1";
                string mid = (string)Session["mid"];


                RefreshPage(mid);

                string username = DAL.PicBookRepository.GetUserName(mid);
                LblFSBoard.Text = username + "'s Follow Streams";


            }

        }

        private void RefreshPage(string mid)
        {
            Repeater1.DataSource = DAL.PicBookRepository.GetFollowStreams(mid);
            //Repeater1.DataSource = DAL.ProductRepository.GetPins("1");
            Repeater1.DataBind();
        }



        protected void BtnFsCreate_Click(object sender, EventArgs e)
        {
            DAL.PicBookRepository.CreateFollowStreamBoard(Session["mid"].ToString(), TxtFSName.Text);
            RefreshPage(Session["mid"].ToString());
        }


       

        protected void BtnAddToStream_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("AddToStream.aspx?fsid=" + e.CommandName);
    
        }
    }
}