using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using engine_stiri_1.code;
using System.Data.SqlClient;
using System.Configuration;

namespace engine_stiri_1.Pages
{
    public partial class PendingAdminRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValidUser.CheckAdmin(SiteMaster.CurrentUser))
            {
                string lastname = GridView1.SelectedRow.Cells[1].Text;
                string firstname = GridView1.SelectedRow.Cells[2].Text;
                string username = GridView1.SelectedRow.Cells[3].Text;
                string email = GridView1.SelectedRow.Cells[4].Text;
                string phone = GridView1.SelectedRow.Cells[5].Text;
                string password = GridView1.SelectedRow.Cells[6].Text;

                AppUser user = new AppUser(lastname, firstname, username, password, email, phone, "administrator", "active");
                DbConnection.Instance.ExecuteNonQueryProcedure("InsertUser",
                                new KeyValuePair<string, object>("username", user.UserName),
                                new KeyValuePair<string, object>("password", user.Password),
                                new KeyValuePair<string, object>("firstname", user.FirstName),
                                new KeyValuePair<string, object>("lastname", user.LastName),
                                new KeyValuePair<string, object>("email", user.Email),
                                new KeyValuePair<string, object>("phonenumber", user.PhoneNumber),
                                new KeyValuePair<string, object>("usertype", user.UserType),
                                new KeyValuePair<string, object>("status", user.Status)
                                );
                SqlConnection conn;
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand c = new SqlCommand("delete from pending where username = " + "'" + username + "'", conn);
                c.ExecuteNonQuery();
                conn.Close();

            }
            else
                Label1.Visible = true;

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

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("../account/Register.aspx");
        }
       

       

       
    }
}