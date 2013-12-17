using PicBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Member user = DAL.PicBookRepository.GetUserProfile(Session["mid"].ToString());
                TxtFName.Text = user.fname;
                TxtLName.Text = user.lname;
                TxtMName.Text = user.mname;
                TxtConPass.Attributes.Add("value", user.pswd);
                TxtPassword.Attributes.Add("value", user.pswd);
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string fname = TxtFName.Text;
            string mname = TxtMName.Text;
            string lname = TxtLName.Text;
            string pswd = TxtPassword.Text;
            DAL.PicBookRepository.UpdateProfile(Session["mid"].ToString(),fname,mname,lname,pswd);
        }

      
    }
}