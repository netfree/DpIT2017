using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ConnectToUE;

namespace connect_to_ue
{
    public partial class editare_articol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = SQLHelper.GetChannels();
                foreach (DataRow row in dt.Rows)
                {
                    ListItem item = new ListItem(row["Nume"].ToString(), row["ID"].ToString());
                    checkboxlist_channels.Items.Add(item);
                }
            }

            System.Diagnostics.Debug.WriteLine(Request.QueryString["articol"]);
        }

        protected bool ValidRequest()
        {
            if (Request.QueryString["articol"] != "" && ((User)Session["user"]).isAdmin())
                return true;
          
            return false;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (ValidRequest())
            {
                int request_article = Convert.ToInt32(Request.QueryString["articol"]);
                int Utilizator_ID = SQLHelper.giveEmailgetID(((User)Session["user"]).Email.ToString());

                SQLHelper.deleteAllChannelsFromArticle(request_article);

                foreach (ListItem item in checkboxlist_channels.Items)
                {
                    if (item.Selected)
                        SQLHelper.addChannelToArticle(Convert.ToInt32(item.Value),request_article);
                }

                Response.Redirect("articles_page.aspx");
            }
        }
    }
}