using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                string searchStr = HttpContext.Current.Request.QueryString["sid"].ToString();
                if ("".Equals(searchStr))
                {
                    return;
                }
                else
                {
                    Repeater3.DataSource = DAL.PicBookRepository.GetMemberSearchResult(searchStr);
                    Repeater3.DataBind();
                    Repeater2.DataSource = DAL.PicBookRepository.GetBoardSearchResult(searchStr);
                    Repeater2.DataBind();
                    Repeater1.DataSource = DAL.PicBookRepository.GetPinSearchResult(searchStr);
                    Repeater1.DataBind();
                }
                

            
            
            }
        }
    }
}