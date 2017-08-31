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

                string savedPasswordHash = SQLHelper.GetHasedPasswdForUser(txt_email.Text);

                if (savedPasswordHash == null)
                    lbl_Message.Text = "Nu exista acest nume de utilizator";
                else
                {
                    //turn it into bytes
                    byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                    //take the salt out of the string
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    //hash the user inputted PW with the salt
                    var pbkdf2 = new Rfc2898DeriveBytes(txt_password.Text, salt, 1000);
                    //put the damn thing in a byte vector.. instead of a string. why? why is this necessary?
                    //who am i to judge cryptography standards i guess
                    byte[] hash = pbkdf2.GetBytes(20);
                    //oh, this is why
                    //compare results! letter by letter!
                    //starting from 17 cause 0-16 are the salt
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
                        //if wrong password, show
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