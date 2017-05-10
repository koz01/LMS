using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAO_provider
    {

        #region Category

        //get Category
        public static List<Category> getBookCategory()
        {
            List<Category> categoryList = null;
            try
            {
                LearnEFEntities2 db=new LearnEFEntities2();
                categoryList = db.Categories.ToList();

            }catch(Exception ex)
            {
                throw ex;
            }

            return categoryList;
        }


        
        #endregion

        #region Book

        //Generate BOOK SERIAL ID
        public static String getGenerateBookSerial(String CategoryID)
        {
            String autoId = "";
            try
            {
                LearnEFEntities2 db = new LearnEFEntities2();
                int BookSerial = db.Books.Where(u => u.Category == CategoryID).Count();

                if ((BookSerial >= 0) && (BookSerial < 9))
                {
                    BookSerial = BookSerial + 1;
                    autoId = "C00" + BookSerial;
                }
                else if ((BookSerial >= 9) && (BookSerial < 100))
                {
                    BookSerial = BookSerial + 1;
                    autoId = "C0" + BookSerial;
                }
                else if (BookSerial >= 99)
                {
                    BookSerial = BookSerial + 1;
                    autoId = "C" + BookSerial;
                }

            }
            catch (Exception ex)
            {
                return "0";
                throw ex;
            }

            return autoId;
        }

        //SEARCH BOOKS
        public static List<Book> getSearchBook(String name, String author , String categroy_id)
        {
            List<Book> bookList = null;
            try
            {
                LearnEFEntities2 db = new LearnEFEntities2();

                var bookName = new SqlParameter("@BookName", name.Trim());
                var Author = new SqlParameter("@Author", author.Trim());
                var category = new SqlParameter("@Category",  categroy_id);

               bookList = db.Database
                    .SqlQuery<Book>("SearchBook @BookName , @Author, @Category ", bookName, Author, category)
                    .ToList();
               
            }catch(Exception ex)
            {
                throw ex;
            }
            return bookList;
        }

        //INSERT NEW BOOK
        public static bool SaveNewBook_DAO(Book BookObj)
        {
            try
            {

                LearnEFEntities2 db = new LearnEFEntities2();
                db.Books.Add(BookObj);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;

            }
        }


        #endregion
        
        #region Member

        //Generate Member ID
        public static String getGenerateMemberID()
        {
            String autoId = "";
            try
            {
                LearnEFEntities2 db = new LearnEFEntities2();
                int objEmpId = db.members.Count();

                if ((objEmpId >= 0) && (objEmpId < 9))
                {
                    objEmpId = objEmpId + 1;
                    autoId = "C00" + objEmpId;
                }
                else if ((objEmpId >= 9) && (objEmpId < 100))
                {
                    objEmpId = objEmpId + 1;
                    autoId = "C0" + objEmpId;
                }
                else if (objEmpId >= 99)
                {
                    objEmpId = objEmpId + 1;
                    autoId = "C" + objEmpId;
                }

            }
            catch (Exception ex)
            {
                return "0";
                throw ex;
            }

            return autoId;
        }

        //SEARCH USER ROLE
        public static List<UserRole> getUserRole()
        {
            List<UserRole> roleList = new List<UserRole>();
            try
            {
                LearnEFEntities2 db = new LearnEFEntities2();
                roleList = db.UserRoles.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return roleList;
        }

        //SEARACH MEMBER LIST
        public static List<member> GetAllUsers(String FirstName, String l_city)
        {

            LearnEFEntities2 db = new LearnEFEntities2();

            var empQuery = from mem in db.members
                           select mem;

            var firstName = new SqlParameter("@FirstName", FirstName.Trim());
            var city = new SqlParameter("@City", l_city.Trim());

            var memberList = db.Database
                .SqlQuery<member>("SearchMember @FirstName , @City", firstName, city)
                .ToList();

            return memberList;
        }

        //INSERT
        public static bool SaveDAO(member memberObj)
        {
            try
            {

                LearnEFEntities2 db = new LearnEFEntities2();
                db.members.Add(memberObj);
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
                throw ex;
             
            }
        }

        //UPDATE
        public static bool UpdateDAO(member memberObj)
        {
            LearnEFEntities2 db = new LearnEFEntities2();

            try
            {
                var memQuery = (from mem in db.members
                                where mem.autokey == memberObj.autokey
                                select mem).FirstOrDefault() ;
                member Obj = memQuery;

                Obj.MemberId = memberObj.MemberId;
                Obj.MemberName = memberObj.MemberName;
                Obj.Phone = memberObj.Phone;
                Obj.email = memberObj.email;
                Obj.Active = memberObj.Active;
                Obj.password = memberObj.password;
                Obj.Address = memberObj.Address;
                Obj.City = memberObj.City;
                db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
                throw ex;
            }
        }
       
        //SEARCH MEMEBER BY NAME
        public static member getMemberByName(String memberName)
        {
            member objEmp = new member();
            try
            {
                LearnEFEntities2 db = new LearnEFEntities2();

                var memQuery = from mem in db.members
                               where mem.MemberName == memberName
                               select mem;
                objEmp = memQuery.Single();
            }
            catch (Exception ex)
            {
                return objEmp = null;
                throw ex;
            }

            return objEmp;
        }

        //SEARCH MEMEBER BY NAME
        public static member getMemberByEmail(String mail)
        {
            member Obj = new member();
            try
            {
                LearnEFEntities2 db = new LearnEFEntities2();

                var memQuery = from mem in db.members
                               where mem.email == mail
                               select mem;
                Obj = memQuery.Single();
            }
            catch (Exception ex)
            {
                return Obj = null;
                throw ex;
            }

            return Obj;
        }

        public static member getEmployee(int memberId)
        {
            member Obj = new member();
            try
            {
                LearnEFEntities2 db = new LearnEFEntities2();

                var memQuery = from emp in db.members
                               where emp.autokey == memberId
                               select emp;
                Obj = memQuery.Single();
            }catch(Exception ex)
            {
                throw ex;
            }

            return Obj;
        }
     

        //DELETE EMPLOYEE
        public static bool removeMember(String MemberId)
        {
            try
            {
                LearnEFEntities2 db = new LearnEFEntities2();

                member Obj = new member() { MemberId = MemberId };
                db.members.Attach(Obj);
                db.members.Remove(Obj);
                db.SaveChanges();
                return true;

            }catch(Exception ex)
            {
                return false;
                throw ex;
            }
        }

        #endregion

        #region Rent Book
        //INSERT
        public static bool SaveRentBook_DAO(BookRent rentObj)
        {
            try
            {
                LearnEFEntities2 db = new LearnEFEntities2();
                db.BookRents.Add(rentObj);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;

            }
        }

        //Restore Rent Book
        public static bool RestoreRentDAO(long id)
        {
            LearnEFEntities2 db = new LearnEFEntities2();

            try
            {
                var empQuery = from emp in db.BookRents
                               where emp.AutoKey == id
                               select emp;
                BookRent objEmp = empQuery.Single();


                objEmp.MemberId = objEmp.MemberId;
                objEmp.StartDate = objEmp.StartDate;
                objEmp.IssueDate = objEmp.IssueDate;
                objEmp.BookId = objEmp.BookId;
                objEmp.CategoryId = objEmp.CategoryId;
                objEmp.NumberOfDay = objEmp.NumberOfDay;
                objEmp.status = 0;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        //Search Rent Book
        public static List<BookRent> getSearchRentBook(String BookName, String MemberName, String categroy_id,
            String IsIssue, String IsRent)
        {
            List<BookRent> bookList = null;
            try
            {
                LearnEFEntities2 db = new LearnEFEntities2();

                var bookName = new SqlParameter("@BookName", BookName.Trim());
                var Author = new SqlParameter("@MemberName", MemberName.Trim());
                var category = new SqlParameter("@Category", categroy_id);
                var Issue = new SqlParameter("@IsIssueBook", IsIssue);
                var Rent = new SqlParameter("@IsRentBook", IsRent);

                bookList = db.Database
                     .SqlQuery<BookRent>("SearchRentBook @BookName , @MemberName, @Category,@IsIssueBook,@IsRentBook "
                     , bookName, Author, category,Issue,Rent)
                     .ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return bookList;
        }

        #endregion
    }
}
