﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PicBook
{
    public partial class CreateBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCreateBoard_Click(object sender, EventArgs e)
        {
            string mid= Session["mid"].ToString();
            string bname = TxtBoardName.Text.Trim();
            string description = TxtBoardDescription.Text.ToString();
            DAL.PicBookRepository.AddBoard(mid, bname, description,DropDownList1.SelectedValue.ToString());
            Response.Redirect("~/allBoards.aspx");
        }
    }
}