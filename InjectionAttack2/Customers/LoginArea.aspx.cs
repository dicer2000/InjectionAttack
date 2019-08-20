using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InjectionAttack2
{
    public partial class LoginArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/default.aspx");
                return;
            }
            if (!Page.IsPostBack)
            {
                txtName.Text = Session["User"].ToString();
            }
        }

        protected void cmdLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~");
        }
    }
}