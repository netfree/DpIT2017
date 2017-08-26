using ConnectToUE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace connect_to_ue
{
    public partial class logare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            //if (txt_password.Text.Length < 6)
            //{
            //    //CustomValidator1.ErrorMessage = " prea putin";
            //    lblMessage.Text = " e32324n";
            //}

            // Response.Redirect("pag2.aspx");

            if (txt_email.Text == "" || txt_password.Text == "")
                lbl_Message.Text = lbl_Message.Text = "Parola si email-ul sunt necesare!";
            else
            {
                DataSet ds = SQLHelper.VerifyUser(txt_email.Text, txt_password.Text);

                lbl_Message.Text = ds.Tables[0].Rows[0][0].ToString();



                if (ds.Tables[1].Rows.Count != 0)
                {
                    DataTable dt_user = ds.Tables[1];

                    User logged_user = new User();
                    logged_user.Id = Convert.ToInt32(dt_user.Rows[0]["ID"]);
                    logged_user.Email = (dt_user.Rows[0]["email"]).ToString();
                    logged_user.Password = (dt_user.Rows[0]["parola"]).ToString();
                    logged_user.User_type = Convert.ToInt32(dt_user.Rows[0]["tiputilizatorid"]);

                    Session["user"] = logged_user;


                    Response.Redirect("articles_page.aspx");
                }
            }

        }
        protected void link_account_Click(object sender, EventArgs e)
        {
            Response.Redirect("inregistrare.aspx");
        }

      
    }
}