using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class FStreamBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string fsid = HttpContext.Current.Request.QueryString["fsid"];
                LblFSBoard.Text = DAL.PicBookRepository.GetFSBoardName(fsid);
                Repeater1.DataSource = DAL.PicBookRepository.GetFSPins(fsid);
                Repeater1.DataBind();
            }
        }
    }
}