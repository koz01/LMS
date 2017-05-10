using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataAccessLayer;
using System.IO;
using System.Drawing.Imaging;

namespace LibraryManagementSysteem
{

    public partial class AddNewBook : Page
    {
        
        Byte[] imgByte = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClearForm();
                PopulateData();
            }
        }


        //Save New Book
        protected void btnSaveNewBook_Click(object sender, EventArgs e)
        {
            if (ddlAddCategory.SelectedIndex == 0)
            {
                Common.getMessageAlert("Please Select Category Type", this, sender);
            }else if(txtBookName.Text.Trim() == "")
            {
                Common.getMessageAlert("Please Select Category Type", this, sender);
            }
            else
            {
                Book BookInfo = new Book();
                BookInfo.Author = txtAuthor.Text.Trim();
                BookInfo.BookName = txtBookName.Text.Trim();
                BookInfo.BookID = txtSerialNo.Text.Trim();
                BookInfo.Category = ddlAddCategory.SelectedIndex.ToString();
                BookInfo.ISBN = txtISBN.Text.Trim();
                //For Save Book Image
                imgByte = File.ReadAllBytes(Server.MapPath(imgBook.ImageUrl));

                BookInfo.photo = imgByte;


                if (BAL_services.SaveBook(BookInfo))
                {
                    Common.getMessageAlert("Insert New Records Successfully", this, sender);
                }
                else
                {
                    Common.getMessageAlert("Insert New Records Fail", this, sender);
                }

                ClearForm();
                PopulateData();

            }
                       
        }

        //Selected Category
        protected void ddlAddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 CategoryId = Convert.ToInt32(ddlAddCategory.SelectedValue);

            if (CategoryId == 0)
            {
                return;
            }
            else
            {
                String autoMemberID = BAL_services.generateBookID(CategoryId.ToString());
                if (autoMemberID != "0")
                {
                    txtSerialNo.Text = autoMemberID;
                }

            }
        }

        //Image Upload
        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null)
            {
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                //Save files to images folder
                if (FileName !="")
                {
                    FileUpload1.SaveAs(Server.MapPath("Images/" + FileName));
                    this.imgBook.ImageUrl = "Images/" + FileName;

                    FileUpload img = (FileUpload)FileUpload1;
                   
                    if (img.HasFile && img.PostedFile != null)
                    {
                        //To create a PostedFile
                        HttpPostedFile File = FileUpload1.PostedFile;
                        //Create byte Array with file len
                        imgByte = new Byte[File.ContentLength];
                        //force the control to load data in array
                        File.InputStream.Read(imgByte, 0, File.ContentLength);
                    }
                }
            }
        }

        //PopulateData
        private void PopulateData()
        {
            
            ddlAddCategory.DataSource = BAL_services.getCategory();
            ddlAddCategory.DataTextField = "Category_Name";
            ddlAddCategory.DataValueField = "Category_Id";
            ddlAddCategory.DataBind();
            ddlAddCategory.Items.Insert(0, new ListItem("-- Select One --", "0"));
        }

        //ClearForm
        private void ClearForm()
        {
            txtAuthor.Text = "";
            txtBookName.Text = "";
            txtSerialNo.Text = "";
            txtISBN.Text = "";
            this.imgBook.ImageUrl = "~/Images/books.jpg";
        }


  
    }
}