using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace engine_stiri_1.code
{
    /// <summary>
    /// Summary description for getImageFromProposed
    /// </summary>
    public class getImageFromProposed : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();

            if (!String.IsNullOrEmpty(context.Request.QueryString["news_id"]))
            {
                int id = Int32.Parse(context.Request.QueryString["news_id"]);

                Image image = GetImage(id);

                context.Response.ContentType = "image/jpeg";
                image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            }
            else
            {
                context.Response.ContentType = "text/html";
                context.Response.Write("<p>Need a valid id</p>");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private Image GetImage(int id)
        {

            MemoryStream memoryStream = new MemoryStream();
            //Retrieve image from Database to a memory stream.
            // If you are using a different method, use it and assign
            // the data to the 'memoryStream' variable.

            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("select photo from proposed where news_id=" + id, sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        sqlDataReader.Read();
                        byte[] btImage = (byte[])sqlDataReader["photo"];

                        memoryStream = new MemoryStream(btImage, false);
                    }
                }
                sqlConnection.Close();
            }
            return Image.FromStream(memoryStream);
        }

    }
}