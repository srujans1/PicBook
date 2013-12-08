using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class Pin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pid = HttpContext.Current.Request.QueryString["pid"];
                string mid = Session["mid"].ToString();
                DAL.Pin pin = DAL.PicBookRepository.GetPin(pid);
                ImgPin.ImageUrl = pin.Url;
                LblLike.Text = DAL.PicBookRepository.GetLikes(pid).count.ToString();
                BtnLike.Text = DAL.PicBookRepository.HasLiked(mid, pid) ? "Unlike" : "Like";
                IEnumerable<DAL.Comment> comments = DAL.PicBookRepository.GetComments(pid);
                Repeater1.DataSource = comments;
                Repeater1.DataBind();
            }

        }

        protected void BtnLike_Click(object sender, EventArgs e)
        {
            string pid = HttpContext.Current.Request.QueryString["pid"];
            string mid = Session["mid"].ToString();
            Button s=(sender as Button);
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
            IEnumerable<DAL.Comment> comments = DAL.PicBookRepository.GetComments(pid);
            Repeater1.DataSource = comments;
            Repeater1.DataBind();

        }
    }
}