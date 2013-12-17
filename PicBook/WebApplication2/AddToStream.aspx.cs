using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class AddToStream : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LstBoards.DataSource = DAL.PicBookRepository.GetFBoards(Session["mid"].ToString());
                LstBoards.DataTextField = "bname";
                LstBoards.DataValueField = "bid";
                LstBoards.DataBind();
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            foreach (ListItem l in LstBoards.Items)
            {
                if(l.Selected)
                  DAL.PicBookRepository.AddToFollowStream(HttpContext.Current.Request.QueryString["fsid"].ToString(), l.Value.ToString());
            
            }
        }
    }
}