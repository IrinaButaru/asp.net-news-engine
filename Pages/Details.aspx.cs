using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using engine_stiri_1.code;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace engine_stiri_1.Pages
{
    public partial class Details : System.Web.UI.Page
    {
        protected News Data;
        public int NewsId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
             int id = 0;

            // Only query database in the first load and ensure the input parameter is valid.
            if (!string.IsNullOrEmpty(Request.QueryString["id"]) &&
                int.TryParse(Request.QueryString["id"], out id))
            {
                NewsId = id;
                Data = GetNews(id);
            }

            // Ensure the result is not null.
            if (Data == null)
            {
                Data = new News();
            }
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../NewsCategories/Noutati.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../NewsCategories/Finante.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("../NewsCategories/Sport.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("../NewsCategories/Lifestyle.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("../NewsCategories/Tech.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/ProposeNews.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/AddNews.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/PendingAdminRequest.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/UserRights.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Redirect("../account/ChangePassword.aspx");
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/Search.aspx");
        }

        private News GetNews(int id)
        {
            News news = new News();
            string sql =
                "SELECT title,headline,text FROM news where news_id=@id";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        news.Title = reader.GetString(0);
                        news.Headline = reader.GetString(1);
                        news.Content = reader.GetString(2);
                    }
                }
                reader.Close();
            }
            return news;
        }

        protected void Submit(object sender, EventArgs e)
        {
            if (SiteMaster.CurrentUser != null || SiteMaster.CurrentUser != string.Empty )
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                string inse = "insert into comments (text, publisher,post_date,news_id) values(@title,@publisher,@date,@newsid) ";
                SqlCommand insertcomment = new SqlCommand(inse, con);
                insertcomment.Parameters.AddWithValue("@title", TextBox5.Text);
                insertcomment.Parameters.AddWithValue("@publisher", SiteMaster.CurrentUser);
                insertcomment.Parameters.AddWithValue("@date", DateTime.Now);
                insertcomment.Parameters.AddWithValue("@newsid", NewsId);
                try
                {
                    insertcomment.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                }
            }
            else
                Label1.Visible = true;
            Response.Redirect(Request.Url.AbsolutePath + "?id=" + NewsId.ToString());
            
        
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("../account/Register.aspx");
        }
    }
}