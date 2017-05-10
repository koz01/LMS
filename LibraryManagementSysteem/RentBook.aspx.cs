using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;

namespace LibraryManagementSysteem
{
    public partial class RentBook : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClearForm();
                PopulateData();
             
                if (Session.Count > 0)
                {
                    if (Session["MemberName"] != null)
                    {
                        string username = Session["MemberName"].ToString();
                        txtMemberName.Text = username;
                    }

                    if (Session["StartDate"] != null)
                    {
                        txtSartDate.Text = Session["StartDate"].ToString();
                    }
                    if (Session["IssueDate"] != null)
                    {
                        txtIssueDate.Text = Session["IssueDate"].ToString();
                    }
                    if (Session["CategorySeletedIndex"] != null)
                    {
                        ddlCategory.SelectedIndex = Convert.ToInt16(Session["CategorySeletedIndex"]);
                    }

                    List<Book> selectedList = (List<Book>)Session["selectedList"];

                    grdRentBookList.DataSource = selectedList;
                    grdRentBookList.DataBind();

                   

                }
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            member Member = new member();
            Category cat = new Category();
            List<Book> selectedList = (List<Book>)Session["selectedList"];
            Member = BAL_services.getMemberByName(txtMemberName.Text.Trim());

            if (txtMemberName.Text.Trim() == "" || Member == null)
            {
                Common.getMessageAlert("Invalid Member. Register first!!!", this, sender);
                return;
            }
            else if (selectedList.Count == 0)
            {
                Common.getMessageAlert("Invalid Book Name.", this, sender);
                return;
            }
            else if (txtSartDate.Text.Trim() == "" || txtIssueDate.Text.Trim() == "")
            {
                Common.getMessageAlert("Invalid Rent Date.", this, sender);
                return;
            }
            else if (ddlCategory.SelectedIndex == 0)
            {
                Common.getMessageAlert("Please Select Book Category.", this, sender);
                return;

            }
            else
            {
                int numberttoDay = Common.NumberOfDay(txtSartDate.Text.ToString(), txtIssueDate.Text.ToString());

                for (int i = 0; i < selectedList.Count; i++)
                {
                    BookRent rentObj = new BookRent();

                    rentObj.CategoryId = ddlCategory.SelectedIndex.ToString();
                    rentObj.MemberId = Member.autokey.ToString();
                    rentObj.StartDate = Common.convertStringToDateTime(txtSartDate.Text.Trim());
                    rentObj.IssueDate = Common.convertStringToDateTime(txtIssueDate.Text.Trim());
                    rentObj.NumberOfDay = numberttoDay;
                    rentObj.BookId = selectedList[i].autokey.ToString();
                    rentObj.status = 1;
                    BAL_services.SaveRentBookServices(rentObj);

                }

                Common.getMessageAlert("Records Insert Successfully.", this, sender);
            }

            ClearForm();
            PopulateData();
        }

        protected void btnStartDate_Click(object sender, EventArgs e)
        {
            DateTime dob = DateTime.Parse(Request.Form[txtSartDate.UniqueID]);
        }

        protected void btnIssueDate_Click(object sender, EventArgs e)
        {
            DateTime dob = DateTime.Parse(Request.Form[txtIssueDate.UniqueID]);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateData();
        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            string MemberName, StartDate, IssueDate;
            MemberName = txtMemberName.Text;
            int CategoryIndex = ddlCategory.SelectedIndex;
            StartDate = txtSartDate.Text.Trim();
            IssueDate = txtIssueDate.Text.Trim();

            Session["MemberName"] = MemberName;
            Session["StartDate"] = StartDate;
            Session["IssueDate"] = IssueDate;
            Session["CategorySeletedIndex"] = CategoryIndex;

            Server.Transfer("~/BookList.aspx");

        }

   
        protected void btnNewMember_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/AddNewMember.aspx");
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 empId = Convert.ToInt32(ddlCategory.SelectedValue);


        }

        //PopulateData
        private void PopulateData()
        {

            ddlCategory.DataSource = BAL_services.getCategory();
            ddlCategory.DataTextField = "Category_Name";
            ddlCategory.DataValueField = "Category_Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- Select One --", "0"));
        }


        private void ClearForm()
        {
            txtSartDate.Text = "";
            txtIssueDate.Text = "";
            grdRentBookList.DataSource = null;
            grdRentBookList.DataBind();
            txtMemberName.Text = "";

        }


    }
}