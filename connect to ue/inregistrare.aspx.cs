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
    public partial class inregistrare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_errors.Visible = false;

            if (!IsPostBack)
            {
                DataTable dt = SQLHelper.GetChannels();
                foreach (DataRow row in dt.Rows)
                {
                    ListItem item = new ListItem(row["Nume"].ToString(), row["ID"].ToString());
                    checkboxlist_channels.Items.Add(item);
                }
            }
            lbl_errors.Text = "";
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            if (txt_confirm_password.Text != txt_password.Text)
            {
                lbl_errors.Text = lbl_errors.Text + "Passwords do not match. " + Environment.NewLine;
                lbl_errors.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_password.Text))
            {
                lbl_errors.Text = lbl_errors.Text + "Password field is mandaory!" + Environment.NewLine;
                lbl_errors.Visible = true;
            }
            if (string.IsNullOrEmpty(txt_confirm_password.Text))
            {
                lbl_errors.Text = lbl_errors.Text + "Password confirmation is mandatory!" + Environment.NewLine;
                lbl_errors.Visible = true;
            }
            if (txt_password.Text.Length < 6)
            {
                lbl_errors.Text = lbl_errors.Text + "Password is too short!" + Environment.NewLine;
                lbl_errors.Visible = true;
            }
            if (lbl_errors.Text.Length == 0)
            {
                DataTable dt = SQLHelper.InsertUser(txt_email.Text, txt_password.Text, SQLHelper.giveTipUtilizatorgetID("Standard"));
                int Utilizator_ID =Convert.ToInt32(dt.Rows[0]["Utilizator_ID"]);

                foreach (ListItem item in checkboxlist_channels.Items)
                {
                    if (item.Selected)
                        SQLHelper.InsertPreferences(Utilizator_ID, Convert.ToInt32(item.Value));
                }

                User registered_user = new User();
                registered_user.Id =Convert.ToInt32 (dt.Rows[0][0]);
                registered_user.Email = txt_email.Text;
                registered_user.Password = txt_password.Text;
                registered_user.User_type =1;

                Session["user"] = registered_user;

                Response.Redirect("Default.aspx");
            }
        }

    }
}