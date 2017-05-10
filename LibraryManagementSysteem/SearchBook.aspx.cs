using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataAccessLayer;
using System.IO;

namespace LibraryManagementSysteem
{



    public partial class SearchBook : Page
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


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            seleted_id = Convert.ToString(ddlCategory.SelectedValue);
            List<Book> bookList = BAL_services.getSearchBook(txtBookName.Text.Trim(), txtAuthor.Text.Trim(), seleted_id);

            if (bookList.Count > 0)
            {
                imgBtnExport.Visible = true;
                grdBookList.DataSource = bookList;
                grdBookList.DataBind();
            }
            else
            {
                grdBookList.DataSource = null;
                grdBookList.DataBind();
            }
        }

        protected void BindGridview()
        {
            grdBookList.DataSourceID = "dsdetails";
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void imgBtnExport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Books.xls"));
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