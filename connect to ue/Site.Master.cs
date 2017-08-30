using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace connect_to_ue
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        //private string _antiXsrfTokenValue;

        public string UserEmail
        {
            get {
                if (Session["user"] == null)
                    return string.Empty;
                else return ((User)Session["user"]).Email;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
           Page.PreLoad += master_Page_PreLoad;
            link_logout.ServerClick += Link_logout_ServerClick;
        }

        private void Link_logout_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;

            Response.Redirect("logare.aspx");
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)

        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                div_anonim.Visible = false;
                div_logat.Visible = true;
            }
            else
            {
                div_logat.Visible = false;
                div_anonim.Visible = true;
            }

        }
        protected void logout_Click (object sender, EventArgs e)
        {
            Session["user"] = null;

            Response.Redirect("logare.aspx");
        }
              
    }

}