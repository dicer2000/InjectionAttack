using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InjectionAttack2
{
    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {

        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {

            // Validate the user password
            string strValidatedUser = String.Empty;
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                string strCommand = "SELECT * FROM Users WHERE UserName = '" + txtUsername.Text + "' " +
                    "AND Password='" + txtPassword.Text + "'";

                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(strCommand, connection))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        connection.Open();
                        object objVal = sqlCommand.ExecuteScalar();

                        strValidatedUser = (string)objVal;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Invalid username or password: " + ex.Message;
                lblError.Visible = true;
                return;
            }



            if (strValidatedUser != null)
            {
                Session.Add("User", strValidatedUser);
                Response.Redirect("Customers/LoginArea.aspx");
                // Some successful sign-in
                // IdentityHelper.SignIn(manager, user, RememberMe.Checked);
//                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                lblError.Text = "Invalid username or password " + strValidatedUser;
                lblError.Visible = true;
            }
        }


        protected void cmdLoginSanitized_Click(object sender, EventArgs e)
        {
            string strUsername = String.Empty;
            string strPassword = String.Empty;
            // Check for Valid Username and Password fields
            try
            {
                strUsername = AntiSqlInjection.ValidateSqlValue(txtUsername.Text);
                strPassword = AntiSqlInjection.ValidateSqlValue(txtPassword.Text);
            }
            catch (Exception ex)
            {
                lblError.Text = "Invalid username or password: " + ex.Message;
                lblError.Visible = true;
                return;
            }

            // Validate the user password
            string strValidatedUser = String.Empty;
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                //string strCommand = "SELECT * FROM Users WHERE UserName = '" + txtUsername.Text + "' " +
                //            "AND Password='" + txtPassword.Text + "'";

                string strCommand = "SELECT * FROM Users WHERE UserName = '" + strUsername + "' " +
                    "AND Password='" + strPassword + "'";

                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(strCommand, connection))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        connection.Open();
                        object objVal = sqlCommand.ExecuteScalar();

                        strValidatedUser = (string)objVal;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Invalid username or password: " + ex.Message;
                lblError.Visible = true;
                return;
            }



            if (strValidatedUser != null)
            {
                Session.Add("User", strValidatedUser);
                Response.Redirect("Customers/LoginArea.aspx");
                // Some successful sign-in
                // IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                //                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                lblError.Text = "Invalid username or password " + strValidatedUser;
                lblError.Visible = true;
            }
        }

        protected void cmdParamLogin_Click(object sender, EventArgs e)
        {

            // Validate the user password
            string strValidatedUser = String.Empty;
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                string strCommand = "LoginUser";

                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(strCommand, connection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@Username", txtUsername.Text));
                        sqlCommand.Parameters.Add(new SqlParameter("@Password", txtPassword.Text));
                        connection.Open();
                        object objVal = sqlCommand.ExecuteScalar();

                        strValidatedUser = (string)objVal;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Invalid username or password: " + ex.Message;
                lblError.Visible = true;
                return;
            }

            if (strValidatedUser != null)
            {
                Session.Add("User", strValidatedUser);
                Response.Redirect("Customers/LoginArea.aspx");
                // Some successful sign-in
                // IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                //                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                lblError.Text = "Invalid username or password " + strValidatedUser;
                lblError.Visible = true;
            }
        }

    }
}