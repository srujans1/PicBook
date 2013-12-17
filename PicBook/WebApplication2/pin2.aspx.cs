using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class pin2 : System.Web.UI.Page
    {
        string pid = HttpContext.Current.Request.QueryString["pid"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string mid = Session["mid"].ToString();
                PicBook.Models.Pin pin = DAL.PicBookRepository.GetPin(pid);
                if (pin.Url == null)
                {
                    return;
                }
                ImgPin.ImageUrl = pin.Url;
                ImgRepin.ImageUrl = pin.Url;
                CbBoards.DataSource = DAL.PicBookRepository.GetBoards(mid);
                CbBoards.DataTextField = "bname";
                CbBoards.DataValueField = "bid";
                CbBoards.DataBind();
                LblHashtags.Text = pin.Hashtag;
                LblLike.Text = DAL.PicBookRepository.GetLikes(pid).count.ToString();
                BtnLike.Text = DAL.PicBookRepository.HasLiked(mid, pid) ? "Unlike" : "Like";
                IEnumerable<PicBook.Models.Comment> comments = DAL.PicBookRepository.GetComments(pid);
                Repeater1.DataSource = comments;
                Repeater1.DataBind();
                if (!DAL.PicBookRepository.IsOwnerOfPin(mid, pid))
                {
                    BtnDeletePin.Visible = false;
                }
            }

        }

        protected void BtnLike_Click(object sender, EventArgs e)
        {
            string pid = HttpContext.Current.Request.QueryString["pid"];
            string mid = Session["mid"].ToString();
            Button s = (sender as Button);
            if (s.Text.Equals("Like"))
            {
                DAL.PicBookRepository.ModifyLike(mid, pid, "like");
                LblLike.Text = DAL.PicBookRepository.GetLikes(pid).count.ToString();
                BtnLike.Text = "Unlike";
            }
            else if (s.Text.Equals("Unlike"))
            {
                DAL.PicBookRepository.ModifyLike(mid, pid, "unlike");
                LblLike.Text = DAL.PicBookRepository.GetLikes(pid).count.ToString();
                BtnLike.Text = "Like";
            }
        }

        protected void BtnComment_Click(object sender, EventArgs e)
        {

            string pid = HttpContext.Current.Request.QueryString["pid"];
            string mid = Session["mid"].ToString();
            string comment = TxtBxComment.Text;
            if ("".Equals(comment))
            {
                return;
            }
            DAL.PicBookRepository.AddComment(mid, pid, comment);
            IEnumerable<PicBook.Models.Comment> comments = DAL.PicBookRepository.GetComments(pid);
            Repeater1.DataSource = comments;
            Repeater1.DataBind();
            TxtBxComment.Text = "";
           

        }

        protected void BtnRepin_Click(object sender, EventArgs e)
        {
            
            DAL.PicBookRepository.RepinPicture(CbBoards.Text.ToString(), pid, TxtRepinDescp.Text);
        }

        protected void BtnDeletePin_Click(object sender, EventArgs e)
        {
            DAL.PicBookRepository.DeletePin(Session["mid"].ToString(), pid);
            Response.Redirect("~/allBoards.aspx");
        }


    }
}