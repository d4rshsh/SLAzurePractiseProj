using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLAzurePractiseProj
{
    public partial class Login : System.Web.UI.Page
    {
        protected void onclick(object sender, EventArgs e)
        {
            try
            {
                string uname = un.Text.ToString();
                string password = pass.Text.ToString();
               
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Login"].ConnectionString);

                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Userdetails where Userid='" + uname
                    + "' and Password='" + password + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Response.Write("Login Success!!");

                   // Response.Redirect("Default");
                }
                else
                {
                    Response.Redirect("Contact");
                }
                con.Close();
                con.Dispose();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                Response.Write(ex.StackTrace);
            }
        }
    }
}