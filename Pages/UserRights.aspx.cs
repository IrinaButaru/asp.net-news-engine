using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using engine_stiri_1.code;

namespace engine_stiri_1.Pages
{
    public partial class UserRights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValidUser.CheckAdmin(SiteMaster.CurrentUser))
            {
                string username = GridView1.SelectedRow.Cells[3].Text;
                SqlConnection conn;
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand c = new SqlCommand("UPDATE users SET status = 'revoked' WHERE username = @username", conn);
                c.Parameters.Add(new SqlParameter("@username", TypeCode.String));
                c.Parameters["@username"].Value = username;
                c.ExecuteNonQuery();
                conn.Close();
            }
            else
                Label2.Visible = true;

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValidUser.CheckAdmin(SiteMaster.CurrentUser))
            {
                string username = GridView2.SelectedRow.Cells[3].Text;
                SqlConnection conn;
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand c = new SqlCommand("UPDATE users SET status = 'active' WHERE username = @username", conn);
                c.Parameters.Add(new SqlParameter("@username", TypeCode.String));
                c.Parameters["@username"].Value = username;
                c.ExecuteNonQuery();
                conn.Close();
            }
            else
                Label3.Visible = true;
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("../account/Register.aspx");
        }
 
    }
}