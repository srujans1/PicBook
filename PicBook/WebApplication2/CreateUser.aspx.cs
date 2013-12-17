using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
              if(Request.QueryString["Q"]!=null)
                  LblSuccess.Text="Successfully created User";
              else
                  LblSuccess.Text = "";
                
            }
        }

      

 
        protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            string name = CreateUserWizard1.UserName;
            string pwd = CreateUserWizard1.Password;
            bool success=!DAL.PicBookRepository.CreateUser(CreateUserWizard1.UserName, "", "", "", CreateUserWizard1.Password, CreateUserWizard1.Email);
            e.Cancel = success;
            Response.Redirect(Request.Url.ToString()+"?Q=success", true);
            if (success)
                LblSuccess.Text = "user created successfully";
        }
    }
}