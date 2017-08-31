using ConnectToUE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace connect_to_ue
{
    public partial class logare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_email.Text == "" || txt_password.Text == "")
                lbl_Message.Text = lbl_Message.Text = "Parola si email-ul sunt necesare!";
            else
            {

                string savedPasswordHash = SQLHelper.GetHasedPasswdForUser(txt_email.Text);

                if (savedPasswordHash == null)
                    lbl_Message.Text = "Nu exista acest nume de utilizator";
                else
                {
                    
                    byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                    
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    
                    var pbkdf2 = new Rfc2898DeriveBytes(txt_password.Text, salt, 1000);
                    
                    byte[] hash = pbkdf2.GetBytes(20);
                   
                    int ok = 1;
                    for (int i = 0; i < 20; i++)
                        if (hashBytes[i + 16] != hash[i])
                            ok = 0;
                    if (ok == 1)
                    {
                        DataTable dt_user = SQLHelper.GetAllDataForUser(txt_email.Text);
                        User logged_user = new User();
                        logged_user.Id = Convert.ToInt32(dt_user.Rows[0]["ID"]);
                        logged_user.Email = (dt_user.Rows[0]["email"]).ToString();
                        logged_user.Password = (dt_user.Rows[0]["parola"]).ToString();
                        logged_user.User_type = Convert.ToInt32(dt_user.Rows[0]["tiputilizatorid"]);

                        Session["user"] = logged_user;


                        Response.Redirect("articles_page.aspx");
                    }
                    else
                    {
                        
                        lbl_Message.Text = "Inncorect username or password.";
                    }
                }

            }

        }
        protected void link_account_Click(object sender, EventArgs e)
        {
            Response.Redirect("inregistrare.aspx");
        }

      
    }
}