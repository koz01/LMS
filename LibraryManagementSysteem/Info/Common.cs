using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using DataAccessLayer;
using BusinessLayer;
using System.Security.Cryptography;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace LibraryManagementSysteem
{
    public static class Common
    {
        private static Hashtable m_executingPages = new Hashtable();

        public static void getMessageAlert(String sMessage, Page pg, Object obj)
        {
            // If this is the first time a page has called this method then
            if (!m_executingPages.Contains(HttpContext.Current.Handler))
            {
                // Attempt to cast HttpHandler as a Page.
                Page executingPage = HttpContext.Current.Handler as Page;

                if (executingPage != null)
                {
                    // Create a Queue to hold one or more messages.
                    Queue messageQueue = new Queue();

                    // Add our message to the Queue
                    messageQueue.Enqueue(sMessage);

                    // Add our message queue to the hash table. Use our page reference
                    // (IHttpHandler) as the key.
                    m_executingPages.Add(HttpContext.Current.Handler, messageQueue);

                    // Wire up Unload event so that we can inject some JavaScript for the alerts.
                    executingPage.Unload += ExecutingPage_Unload;
                }
            }
            else
            {
                // If were here then the method has allready been called from the executing Page.
                // We have allready created a message queue and stored a reference to it in our hastable.
                Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];

                // Add our message to the Queue
                queue.Enqueue(sMessage);
            }
        }

        private static void ExecutingPage_Unload(object sender, EventArgs e)
        {
            // Get our message queue from the hashtable
            Queue queue = (Queue)m_executingPages[HttpContext.Current.Handler];

            if (queue != null)
            {
                StringBuilder sb = new StringBuilder();

                // How many messages have been registered?
                int iMsgCount = queue.Count;

                // Use StringBuilder to build up our client slide JavaScript.
                sb.Append("<script language='javascript'>");

                // Loop round registered messages
                string sMsg = null;
                while (System.Math.Max(System.Threading.Interlocked.Decrement(ref iMsgCount), iMsgCount + 1) > 0)
                {
                    sMsg = (string)queue.Dequeue();
                    sMsg = sMsg.Replace("\n", "\\n");
                    sMsg = sMsg.Replace("\"", "'");

                    sb.Append("alert( \"" + sMsg + "\" );");
                }

                // Close our JS
                sb.Append("</script>");

                // Were done, so remove our page reference from the hashtable
                m_executingPages.Remove(HttpContext.Current.Handler);

                // Write the JavaScript to the end of the response stream.
                HttpContext.Current.Response.Write(sb.ToString());
            }
        }

        public static byte[] imageToByteArray(Image imageIn)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(imageIn, typeof(byte[]));
            return xByte;
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static DateTime convertStringToDateTime(String date)
        {
            // String to DateTime
            String MyString;
            MyString = date;
            //MyString = "1999-09-01 21:34 p.m.";  //Depends on your regional settings

            DateTime MyDateTime;
            MyDateTime = new DateTime();
            MyDateTime = DateTime.ParseExact(MyString, "dd/MM/yyyy HH:mm",
                                             null);
            return MyDateTime;
        }

        public static int NumberOfDay(String startDate, String endDate)
        {
            DateTime StartDate = convertStringToDateTime(startDate);
            DateTime EndDate = convertStringToDateTime(endDate);
            int total_days = Convert.ToInt16((EndDate - StartDate).TotalDays);
            return total_days;
        }

        #region Password Entryption

        public static byte[] getEncryptData(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        public static byte[] getDecryptData(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt
                        (Data, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }

        #endregion

        //Sending Email
        public static void SendEmail(Page pg, object sender, String ToEmail, string user, String forgetPwd)
        {
            String FromEmail = ConfigurationManager.AppSettings["FromMail"];
            String password = ConfigurationManager.AppSettings["Password"];
            String Host = ConfigurationManager.AppSettings["Host"];
            try
            {
                using (MailMessage mm = new MailMessage(FromEmail, ToEmail))
                {
                    mm.Subject = "Library Management System Account";
                    mm.Body = " Hi " + user + ", \n" +
                              " Someone recently requested a password change for your account. If this was you, you can set a new password here:\n " +
                                "Password : " + forgetPwd + "\n" +
                            "   If you don't want to change your password or didn't request this, just ignore and delete this message.\n" +
                            "   To keep your account secure, please don't forward this email to anyone. See our Help Center for more security tips.\n" +
                            "   Have a nice day!";

                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = Host;
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(FromEmail, password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    getMessageAlert("Email Send Successfully", pg, sender);
                }
            }
            catch (Exception ex)
            {
                return;
                throw ex;
            }

        }
    }

}