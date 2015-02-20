using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using engine_stiri_1.code;

namespace engine_stiri_1.account
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var appuser = Session["appUser"] as AppUser;
            if (appuser == null)
                return;
            if (ValidUser.CheckLogin(appuser))
            {
               // Response.Redirect("Members.aspx");
            }
        }

        protected void ButtonCreareCont_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (ValidUser.CheckUserExist(TextBoxUsername.Text))
                {
                    error.Visible = true;
                }
                else
                {
                    if (DropDownListUtilizator.SelectedValue != "administrator")
                    {
                         AppUser user = new AppUser(TextBoxNume.Text, TextBoxPrenume.Text, TextBoxUsername.Text, Hash.GetHashKey(TextBoxParola.Text), TextBoxEmail.Text,TextBoxTelefon.Text, DropDownListUtilizator.SelectedValue,"active");
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
                        Session.Add("appUser", user);
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        AppUser user = new AppUser(TextBoxNume.Text, TextBoxPrenume.Text, TextBoxUsername.Text, Hash.GetHashKey(TextBoxParola.Text), TextBoxEmail.Text,TextBoxTelefon.Text, DropDownListUtilizator.SelectedValue,"active");
                        DbConnection.Instance.ExecuteNonQueryProcedure("InsertPendingAdmin",
                             new KeyValuePair<string, object>("username", user.UserName),
                             new KeyValuePair<string, object>("password", user.Password),
                             new KeyValuePair<string, object>("firstname", user.FirstName),
                             new KeyValuePair<string, object>("lastname", user.LastName),
                             new KeyValuePair<string, object>("email", user.Email),
                             new KeyValuePair<string, object>("phonenumber", user.PhoneNumber)
                             );
                        Session.Add("appUser", user);
                        Response.Redirect("Login.aspx");

                    }
                }
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/Search.aspx");
        }
    }
}