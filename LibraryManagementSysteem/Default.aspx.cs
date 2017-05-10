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
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Abandon();
                txtPWD.Attributes["type"] = "password";
                Session.RemoveAll();
            }
        }

        protected void btnsingUp_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/SignUp.aspx");
        }

        protected void btnForgetPasword_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
            Server.Transfer("~/SendEmail.aspx");
        }

        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            String userName = txtUserName.Text.Trim();
            String pwd = txtPWD.Text.Trim();
            member UserObj = new member();
            UserObj = BAL_services.getMemberByName(userName);
            if (UserObj != null)
            {
                string DecryptPass = CryptorEngine.Decrypt(UserObj.password, true);
                Session["Role"] = UserObj.RoleId;
                Session["Password"] = DecryptPass;
                Session["User"] = UserObj.MemberName;

                if (pwd == DecryptPass)
                {
                    Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
                    Server.Transfer("~/SearchBook.aspx");
                }
                else
                {

                    rfvPWD.IsValid = false;
                    rfvPWD.ErrorMessage = "Invalid Password";
                    this.Page.Validators.Add(rfvPWD);


                }
            }
            else
            {

                rfvUser.IsValid = false;
                rfvUser.ErrorMessage = "Invalid Username!";
                this.Page.Validators.Add(rfvUser);
            }

        }
    }
}