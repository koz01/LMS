using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataAccessLayer;
using System.IO;
using System.Drawing;

namespace LibraryManagementSysteem
{
    public partial class IssueBook : Page
    {
        String seleted_id = "";
      
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {
                imgBtnExport.Visible = false;
                PopulateList();
            }
        }

        //Search Rent Book
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String isIssue = "0", isRent = "0";
            if (chkIssue.Checked)
            {
                isIssue = "1";
            }
            if (chkRent.Checked)
            {
                isRent = "1";
            }
            seleted_id = Convert.ToString(ddlCategory.SelectedValue);
            List<BookRent> bookList = BAL_services.getSearchRentBook(txtBookName.Text.Trim(), txtAuthor.Text.Trim(), seleted_id, isIssue, isRent);

            if (bookList.Count > 0)
            {
                imgBtnExport.Visible = true;
                grdBookList.DataSource = bookList;
                grdBookList.DataBind();
            }
        }

        protected void imgBtnExport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "RentBooks.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdBookList.AllowPaging = false;
            BindGridview();
            //Change the Header Row back to white color
            grdBookList.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells
            for (int i = 0; i < grdBookList.HeaderRow.Cells.Count; i++)
            {
                grdBookList.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
            }
            grdBookList.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }

        protected void BindGridview()
        {
            grdBookList.DataSourceID = "dsdetails";
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdBookList, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }


        //Select Book in Rent Book Grid View
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdBookList.Rows)
            {
                if (row.RowIndex == grdBookList.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                   
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
               
            }

        }

        //Restore Rent Book
        protected void btnRestore_Click(object sender, EventArgs e)
        {

            List<Book> selectedList = new List<Book>();
            foreach (GridViewRow gr in grdBookList.Rows)
            {
                CheckBox chk = (CheckBox)gr.FindControl("chkSelect");
                if (chk.Checked)
                {
                    Book bookObj = new Book();
                    bookObj.BookID = gr.Cells[1].Text;
                    bookObj.BookName = gr.Cells[2].Text;
                    bookObj.Author = gr.Cells[3].Text;
                    bookObj.Category = gr.Cells[4].Text;
                    bookObj.ISBN = gr.Cells[5].Text;
                    bookObj.autokey = Convert.ToInt64(gr.Cells[6].Text);
                    selectedList.Add(bookObj);
                }
            }
         
            if (selectedList.Count > 0)
            {
                for (int i = 0; i < selectedList.Count; i++)
                {
                    BAL_services.RestoreRentBook(selectedList[i].autokey);
                }

                Common.getMessageAlert("Record restore Successfully", this, sender);
                btnSearch_Click(sender, e);
            }
        }

        private void PopulateList()
        {
            ddlCategory.DataSource = BAL_services.getCategory();
            ddlCategory.DataTextField = "Category_Name";
            ddlCategory.DataValueField = "Category_Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- Select One --", "0"));
        }
    }
}