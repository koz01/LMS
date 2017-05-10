using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using BusinessLayer;
using EnCryptDecrypt;

namespace LibraryManagementSysteem
{
    public partial class SignUp : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClearForm();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                String autoMemberID = BAL_services.generateMemberID();

                member ObjUser = new member();
                ObjUser.MemberName = txtMemberName.Text.Trim();
                ObjUser.Phone = txtPhone.Text.Trim();
                ObjUser.Address = txtAddress.Text.Trim();
                ObjUser.City = txtCity.Text.Trim();
                ObjUser.email = txtEmail.Text.Trim();
                ObjUser.MemberId = autoMemberID;
                string getPass = txtPassword.Text.Trim();
                string encryptPass = CryptorEngine.Encrypt(getPass, true);
                ObjUser.password = encryptPass;
                ObjUser.RoleId = "2";
                ObjUser.Active = "1";

                if (BAL_services.SaveServices(ObjUser))
                {
                    Common.getMessageAlert("Congradulation! Now you are member.", this, sender);
                    Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
                    Server.Transfer("~/Default.aspx");
                }
                else
                {
                    Common.getMessageAlert("Record Inserted Successfully", this, sender);
                }


            }catch(Exception ex)
            {
                throw ex;
            }
        }


        //Clear Form
        private void ClearForm()
        {
            txtEmail.Text = "";
            txtMemberName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtPassword.Text = "";
        }
    }
}