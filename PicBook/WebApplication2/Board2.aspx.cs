using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class Board2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bid = HttpContext.Current.Request.QueryString["bid"];
                refresh(bid);
                BtnDeleteBoard.Visible = false;
                UpdateFollowButton(bid);
               
            }
        }

        private void refresh(string bid)
        {
            LblBoard.Text = DAL.PicBookRepository.GetBoardName(bid);
            if (LblBoard.Text.Equals(""))
            {
                BtnFollow.Visible = false;
            }
            Repeater1.DataSource = DAL.PicBookRepository.GetPins(bid);
            Repeater1.DataBind();
        }

        private void UpdateFollowButton(string bid)
        {
            if (DAL.PicBookRepository.IsOwnerOfBoard(Session["mid"].ToString(), bid))
            {
                BtnFollow.Visible = false;
                BtnDeleteBoard.Visible = true;
            }
            else
            {
                BtnFollow.Text = DAL.PicBookRepository.IsFollowingBoard(Session["mid"].ToString(), bid) == true ? "Unfollow" : "Follow";
            }
        }

        protected void BtnFollow_Click(object sender, EventArgs e)
        {
            string bid=HttpContext.Current.Request.QueryString["bid"];
            DAL.PicBookRepository.FollowBoard(Session["mid"].ToString(), bid,BtnFollow.Text);
            UpdateFollowButton(bid);
        }

        protected void BtnDeleteBoard_Click(object sender, EventArgs e)
        {
            string bid = HttpContext.Current.Request.QueryString["bid"];
            DAL.PicBookRepository.DeleteBoard(Session["mid"].ToString(), bid);
            refresh(bid);
        }
    }
}