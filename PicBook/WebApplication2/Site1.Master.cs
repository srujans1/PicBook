using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchResults.aspx?sid=" + TxtSearch.Text);
        }
        //protected void BtnCreateBoard_Click(object sender, EventArgs e)
        //{
        //    string mid = Session["mid"].ToString();
        //    string bname = TxtBoardName.Text.Trim();
        //    string description = TxtBoardDescription.Text.ToString();
        //    DAL.PicBookRepository.AddBoard(mid, bname, description);
        //    Response.Redirect("~/Home.aspx");
        //}
    }
}