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
                    if (SQLHelper.articleBelongsToChannel(Convert.ToInt32(Request.QueryString["articol"]), Convert.ToInt32(item.Value)))
                        item.Selected = true;
                    checkboxlist_channels.Items.Add(item);
                }

                DataTable dt2 = SQLHelper.selectArticle(Convert.ToInt32(Request.QueryString["articol"]));
                DataRow articol = dt2.Rows[0];

                ckbox_public.Checked = Convert.ToBoolean(articol["Este_publicat"]);
            }

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

                SQLHelper.setIsPublished(request_article, ckbox_public.Checked);

                Response.Redirect("articles_page.aspx");
            }
        }

        protected void linkbutton_redirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("editare_continut?articol=" + Request.QueryString["articol"]);
        }
    }
}