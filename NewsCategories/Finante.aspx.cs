using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace engine_stiri_1.NewsCategories
{
    public partial class Finante : System.Web.UI.Page
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
     
        protected void Sort(object sender, EventArgs e)
        {
            var sort = DropDownList1.SelectedItem.ToString();
            if (sort == "Date(ascending)") SqlDataSource1.SelectCommand += "ORDER BY [release_date] ASC";
            else if (sort == "Date(descending)") SqlDataSource1.SelectCommand += "ORDER BY [release_date] DESC";
            else if (sort == "Title(ascending)") SqlDataSource1.SelectCommand += "ORDER BY [title] ASC";
            else if (sort == "Title(descending)") SqlDataSource1.SelectCommand += "ORDER BY [title] DESC";

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("../account/Register.aspx");
        }
    }
}