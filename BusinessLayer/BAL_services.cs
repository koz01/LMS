using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
   public class BAL_services
   {

       #region Book Category

       //get Category
       public static List<Category> getCategory()
       {
           return DAO_provider.getBookCategory();
       }

       #endregion


       #region BOOk

       //Get Member auto ID
       public static String generateBookID(String categoryID)
       {
           return DAO_provider.getGenerateBookSerial(categoryID);
       }


       public static List<Book> getSearchBook(String bookName, String author, String category_id)
       {
           return DAO_provider.getSearchBook(bookName, author, category_id);
       }

       public static bool SaveBook(Book BookObj)
       {
           return DAO_provider.SaveNewBook_DAO(BookObj);
       }

       #endregion


       #region Member

       //Get Member auto ID
       public static String generateMemberID()
       {
           return DAO_provider.getGenerateMemberID();
       }

             //get User Role
       public static List<UserRole> getRole()
       {
           return DAO_provider.getUserRole();
       }

        public static List<member> GetAllUsers(String firstName, String city)
       {
           return DAO_provider.GetAllUsers(firstName, city);
       }

       public static bool SaveServices(member memberObj)
       {
           return DAO_provider.SaveDAO(memberObj);
       }

       public static bool UpdateServices(member memberObj)
       {
           return DAO_provider.UpdateDAO(memberObj);
       }

       public static member getEmpoyeeRecords(int memberId)
       {
           return DAO_provider.getEmployee(memberId);
       }

       public static member getMemberByName(String member)
       {
           return DAO_provider.getMemberByName(member);
       }

       public static member getMemberByMail(String mail)
       {
           return DAO_provider.getMemberByEmail(mail);
       }

       public static bool removeMember(String memberId)
       {
           return DAO_provider.removeMember(memberId);
       }

       #endregion


       #region Book Rent

       public static bool SaveRentBookServices(BookRent RentObj)
       {
           return DAO_provider.SaveRentBook_DAO(RentObj);
       }

       public static List<BookRent> getSearchRentBook(String bookName, String member, String category_id, String IsIssue, String IsRent)
       {
           return DAO_provider.getSearchRentBook(bookName, member, category_id, IsIssue, IsRent);
       }

       //Restore Rent Book
       public static bool RestoreRentBook(long id)
       {
           return DAO_provider.RestoreRentDAO(id);
       }
       #endregion
   }
}
