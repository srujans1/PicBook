using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class CreatePin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string mid = Session["mid"].ToString();
                CbBoard.DataSource = DAL.PicBookRepository.GetBoards(mid);
                CbBoard.DataTextField = "bname";
                CbBoard.DataValueField = "bid";
               // ImgFileUpload.Enabled = false;
                CbBoard.DataBind();
            }
        }

        protected void BtnPin_Click(object sender, EventArgs e)
        {
            string source_url = TxtSourceUrl.Text;
            string url = "";
            if (rbUrl.Checked)
            {

                url = PicBookUtitilies.Utilities.DownloadImage(TxtUrl.Text, Session["mid"].ToString(), Server);
                if (url == null)
                {
                    return;
                }
            }
            else 
            {
                if (ImgFileUpload.HasFile)
                {
                    string hashcode = ImgFileUpload.FileName.GetHashCode().ToString();
                    string mid = Session["mid"].ToString();
                    string path = "Images/" + mid + "_" + hashcode + ".jpg";
                    int i = 1;
                    while (File.Exists(Server.MapPath(path)))
                    {
                        i++;
                        path = "Images/" + mid + "_" + hashcode + i + ".jpg";
                    }
                    url = path;
                    ImgFileUpload.SaveAs(Server.MapPath(path));
                    lblError.Text = "Uploaded successfully";
                }
                else
                {
                    lblError.Text = "Please Select a File";
                    return;
                }
            
            
            }
            string pid=DAL.PicBookRepository.AddPin(Session["mid"].ToString(), CbBoard.SelectedValue, url,source_url, TxtDescription.Text,Server);
            string[] hashtags = TxtHashTag.Text.Split(' ');
            foreach (string s in hashtags)
            {
                DAL.PicBookRepository.PinTag(pid, s);
            }

        
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}