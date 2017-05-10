using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataAccessLayer;
using System.Data;
using System.Drawing;

namespace LibraryManagementSysteem
{
    public partial class BookList : Page
    {
        List<Book> selectedList = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            selectedList = new List<Book>();

            if (!Page.IsPostBack)
            {
                PopulateList();
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<Book> selectedList=new List<Book> ();
           
            foreach (GridViewRow gr in grdBookList.Rows)
            {
                CheckBox chk = (CheckBox)gr.FindControl("chk");
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

            if (Session["selectedList"] != null)
            {
                List<Book> selected = new List<Book>();
                selected = (List<Book>)Session["selectedList"];

                for (int i = 0; i < selected.Count; i++)
                {
                    selectedList.Add(selected[i]);
                }
                Session["selectedList"] = selectedList;
            }
            else
            {
                Session["selectedList"] = selectedList;
            }
                Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
             Server.Transfer("~/RentBook.aspx");

        }

        private void PopulateList()
        {
            if (Session.Count > 0)
            {
                String CategorySelectedIndex = Session["CategorySeletedIndex"].ToString();
                List<Book> bookList = BAL_services.getSearchBook("", "", CategorySelectedIndex);

                if (bookList.Count > 0)
                {
                    grdBookList.DataSource = bookList;
                    grdBookList.DataBind();
                }
            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdBookList, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }


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

    }
}