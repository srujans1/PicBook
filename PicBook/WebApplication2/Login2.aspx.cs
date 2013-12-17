using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class Login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void PicLogin_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string mid = DAL.PicBookRepository.GetPid(PicLogin.UserName.ToString().Trim(), PicLogin.Password.ToString().Trim());
            if (!mid.Equals(""))
            {
                Session["mid"] = mid;
                e.Authenticated = true;
            }
            else
                e.Authenticated = false;

        }
    }
}