using EnCryptDecrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using BusinessLayer;
using System.Net.Mail;
using System.Net;

namespace LibraryManagementSysteem
{
    public partial class SendEmail :Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
             
            }
        }



        protected void btnSend_Click(object sender, EventArgs e)
        {
            String password = "";
            String user = "";
            if (Session.Count > 0)
            {
                password = Session["Password"].ToString();
                user = Session["User"].ToString();
            }
            else
            {
                member UserObj = new member();
                UserObj = BAL_services.getMemberByMail(txtEmail.Text.Trim());
                if (UserObj != null)
                {
                    password = CryptorEngine.Decrypt(UserObj.password, true);
                    user = UserObj.MemberName;
                }
                Common.SendEmail(this, sender, txtEmail.Text.Trim(), user, password);
                Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
                Server.Transfer("~/Default.aspx");

            }
        }
        
    }
}