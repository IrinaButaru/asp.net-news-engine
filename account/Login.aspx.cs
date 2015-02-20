using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using engine_stiri_1.code;
using System.Data.SqlClient;
using System.Configuration;

namespace engine_stiri_1.account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //un utilizator deja logat ar trebuii redirectat catre pagina corespunzatoare
            var appuser = Session["appUser"] as AppUser;
            if (appuser == null)
                return;
            if (ValidUser.CheckLogin(Session["appUser"] as AppUser) )
            {
                Response.Redirect("../NewsCategories/Noutati.aspx");
            }
           
        }

         protected void Button6_Click(object sender, EventArgs e)
         {
             if (Page.IsValid)
             {
                 string pass = Hash.GetHashKey(TextBox2.Text);
                 //salvam noile date de login in sessiune
                 try
                 {
                     Session["appUser"] = new AppUser("", "", TextBox1.Text, pass, "", "", "","");

                     if (ValidUser.CheckLogin(Session["appUser"] as AppUser) )
                     {
                         SiteMaster.CurrentUser = TextBox1.Text;
                         Response.Redirect("../NewsCategories/Noutati.aspx");
                     }
                    
                      else
                      {
                          error.Visible = true;
                      }

                 }
                 catch
                 {
                     error.Visible = true;
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