﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.IO;
using engine_stiri_1.code;

namespace engine_stiri_1.Pages
{
    public partial class AddNews1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            if (ValidUser.CheckPublisher(SiteMaster.CurrentUser))
                for (int i = 0; i < Repeater1.Items.Count; i++)
                {
                    var checkBox = (CheckBox)Repeater1.Items[i].FindControl("CheckBox1");
                    if (checkBox.Checked)
                    {
                        SqlConnection conn;
                        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        conn.Open();
                        SqlCommand c_add = new SqlCommand("INSERT INTO news (title,headline,text,photo,category,release_date,publisher,link,text) SELECT title,headline,text,photo,category,release_date,publisher,link,text FROM proposed where news_id=@id", conn);
                        c_add.Parameters.Add("@id", SqlDbType.Int);
                        c_add.Parameters["@id"].Value = Convert.ToInt32(checkBox.AccessKey);
                        SqlCommand c_remove = new SqlCommand("DELETE FROM proposed where news_id=@id", conn);
                        c_remove.Parameters.Add("@id", SqlDbType.Int);
                        c_remove.Parameters["@id"].Value = Convert.ToInt32(checkBox.AccessKey);
                        c_add.ExecuteNonQuery();
                        c_remove.ExecuteNonQuery();
                        conn.Close();

                    }
                }
            else
                Label1.Visible = true;
            
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            if (ValidUser.CheckPublisher(SiteMaster.CurrentUser))
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(TextBoxPoza.Text);
                HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream stream = httpWebReponse.GetResponseStream();
                byte[] photo = null;
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    photo = memoryStream.ToArray();
                }

                string link;
                if (TextBoxLink.Text == null || TextBoxLink.Text == string.Empty)
                    link = "../Pages/Details.aspx?id=" + GetNextId();
                else
                    link = TextBoxLink.Text;
                SqlConnection conn;
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand c = new SqlCommand("insert into news (title,headline,photo,category,release_date,link,publisher,text) values(@title,@headline,@photo,@category,@release_date,@link,@publisher,@text)", conn);
                c.Parameters.Add(new SqlParameter("@title", SqlDbType.NVarChar));
                c.Parameters["@title"].Value = TextBoxTitlu.Text;
                c.Parameters.Add(new SqlParameter("@headline", SqlDbType.NVarChar));
                c.Parameters["@headline"].Value = TextBoxHeadline.Text;
                c.Parameters.Add(new SqlParameter("@photo", SqlDbType.Image));
                c.Parameters["@photo"].Value = photo;
                c.Parameters.Add(new SqlParameter("@category", SqlDbType.NVarChar));
                c.Parameters["@category"].Value = DropDownListCategorie.SelectedValue;
                c.Parameters.Add(new SqlParameter("@release_date", SqlDbType.DateTime));
                c.Parameters["@release_date"].Value = DateTime.Now;
                c.Parameters.Add(new SqlParameter("@link", SqlDbType.NVarChar));
                c.Parameters["@link"].Value = link;
                string res = DbConnection.Instance.ExecuteScalarProcedure("GetUserId",
                         new KeyValuePair<string, object>("username", SiteMaster.CurrentUser));
                c.Parameters.Add(new SqlParameter("@publisher", SqlDbType.Int));
                c.Parameters["@publisher"].Value = Convert.ToInt32(res);
                c.Parameters.Add(new SqlParameter("@text", SqlDbType.NVarChar));
                c.Parameters["@text"].Value = TextBoxText.Text;
                c.ExecuteNonQuery();
                conn.Close();
            }
            else
                Label2.Visible = true;
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
        private string GetNextId()
        {
            int id = 0;
            string sql =
                "SELECT MAX(news_id) FROM news";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0) + 1;
                    }
                }
                reader.Close();
            }

            return id.ToString();

        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Response.Redirect("../account/RegisterArrayDeclaration.aspx");
        }

        
    }
}