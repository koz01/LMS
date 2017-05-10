using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataAccessLayer;
using EnCryptDecrypt;

namespace LibraryManagementSysteem
{
    public partial class AddNewMember : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                chkActive.Checked = true;
                ClearEmpForm();
                PopulateEmpList();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 empId = Convert.ToInt32(btnSave.CommandArgument);

            if (empId == 0)
            {
                if(txtMemberId.Text.Trim() =="")
                {
                    Common.getMessageAlert("Invalid Register No", this, sender);
                    return;
                }else if(txtMemberName.Text.Trim() == "")
                {
                    Common.getMessageAlert("Invalid Register Name", this, sender);
                    return;
                }else if(txtPhone.Text.Trim()=="")
                {
                    Common.getMessageAlert("Invalid Phone No", this, sender);
                    return;
                }
                else if (txtAddress.Text.Trim() == "")
                {
                    Common.getMessageAlert("Invalid Address", this, sender);
                    return;
                }else if(txtEmail.Text.Trim() =="")
                {
                    Common.getMessageAlert("Invalid Email", this, sender);
                    return;
                }
                else
                {
                    //INSERT
                    member objEmp = new member();
                    objEmp.MemberId = txtMemberId.Text.Trim();
                    objEmp.MemberName = txtMemberName.Text.Trim();
                    objEmp.Phone = txtPhone.Text.Trim();
                    objEmp.Address = txtAddress.Text.Trim();
                    objEmp.City = txtCity.Text.Trim();
                    objEmp.email = txtEmail.Text.Trim();
                    objEmp.RoleId = ddlUserRole.SelectedValue;

                    objEmp.password = CryptorEngine.Encrypt(txtPassword.Text.Trim(), true);

                    if (chkActive.Checked)
                    {
                        objEmp.Active = "1";
                    }
                    else
                    {
                        objEmp.Active = "0";
                    }


                    if (BAL_services.SaveServices(objEmp))
                    {
                        Common.getMessageAlert("Record Inserted Successfully",this, sender);
                    }
                    else
                    {
                        Common.getMessageAlert("Record Inserted Fail", this, sender);

                    }

                }
            }
            else
            {
                //UPDATE

                member objEmp = new member();

                objEmp.autokey = empId;
                objEmp.MemberId = txtMemberId.Text.Trim(); ;
                objEmp.MemberName = txtMemberName.Text.Trim(); ;
                objEmp.Phone = txtPhone.Text.Trim(); ;
                objEmp.Address = txtAddress.Text.Trim(); ;
                objEmp.City = txtCity.Text.Trim(); ;
                objEmp.email = txtEmail.Text.Trim();
                objEmp.password = CryptorEngine.Encrypt(txtPassword.Text.Trim(), true);
                if (chkActive.Checked)
                {
                    objEmp.Active = "1";
                }
                else
                {
                    objEmp.Active = "0";
                }

                if (BAL_services.UpdateServices(objEmp))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Fail')", true);
                }

            }

            ClearEmpForm();
            PopulateEmpList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateEmpList();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 empId = Convert.ToInt32(btnSave.CommandArgument);
            if (empId != 0)
            {
                if (BAL_services.removeMember(empId.ToString()))
                {
                    ////reset the form and grid
                    ClearEmpForm();
                    PopulateEmpList();
                }
            }
        }

        //Selected Member
        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 empId = Convert.ToInt32(ddlEmployee.SelectedValue);

            if (empId == 0)
            {
                ClearEmpForm();
                return;
            }

            btnSave.CommandArgument = empId.ToString();
            btnSave.Text = "Update";
            btnDelete.CommandArgument = empId.ToString();

            member objEmp = BAL_services.getEmpoyeeRecords(empId);

            txtMemberId.Text = objEmp.MemberId;
            txtMemberName.Text = objEmp.MemberName;
            txtPhone.Text = objEmp.Phone;
            txtAddress.Text = objEmp.Address;
            txtCity.Text = objEmp.City;
            txtEmail.Text = objEmp.email;
            ddlUserRole.SelectedIndex = Convert.ToInt16(objEmp.RoleId);
            txtPassword.Text = CryptorEngine.Decrypt(objEmp.password, true);
            if(objEmp.Active == "1")
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;
            }
        }

        //Selected User Role
        protected void ddlUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 empId = Convert.ToInt32(ddlUserRole.SelectedValue);

            if (empId == 0)
            {
                ClearEmpForm();
                return;
            }
            else
            {
                String autoMemberID = BAL_services.generateMemberID();
                if(autoMemberID != "0")
                {
                    txtMemberId.Text = autoMemberID;
                }

            }
        }

        //Populate Data
        private void PopulateEmpList()
        {

            List<UserRole> userRoleList = BAL_services.getRole();
            ddlUserRole.DataSource = userRoleList;
            ddlUserRole.DataValueField = "AutoKey";
            ddlUserRole.DataTextField = "RoleName";
            ddlUserRole.DataBind();
            ddlUserRole.Items.Insert(0, new ListItem("-- Select One --", "0"));

            List<member> empList = BAL_services.GetAllUsers(txtSrchFirstName.Text, txtSrchCity.Text).ToList();

            ddlEmployee.DataSource = empList;
            ddlEmployee.DataValueField = "AutoKey";
            ddlEmployee.DataTextField = "MemberName";
            ddlEmployee.DataBind();

            ddlEmployee.Items.Insert(0, new ListItem("-- Add New --", "0"));

            //bind grid
            GridView1.DataSource = empList;
            GridView1.DataBind();
        }

        private void ClearEmpForm()
        {
            txtMemberId.Text = "";
            txtMemberName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            chkActive.Checked = true;
            btnSave.CommandArgument = "0";
            btnSave.Text = "Sumbit";
        }
    }
}