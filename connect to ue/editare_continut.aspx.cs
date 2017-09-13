using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConnectToUE;

namespace connect_to_ue
{
    public partial class editare_continut : System.Web.UI.Page
    {
        protected bool ValidRequest()
        {
            if (Session["user"] != null)
                if (Request.QueryString["articol"] != "" && ((User)Session["user"]).isAdmin())
                    return true;

            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int request_article = Convert.ToInt32(Request.QueryString["articol"]);

            DataTable dt = SQLHelper.selectArticle(request_article);

            if (dt.Rows.Count > 0)
            {
                txt_content.InnerText = dt.Rows[0]["Continut"].ToString();
                txt_title.InnerText = dt.Rows[0]["Titlu"].ToString();
                txt_rezumat.InnerText = dt.Rows[0]["Rezumat"].ToString();
            }
        }

        protected void btn_submit_art_Click(object sender, EventArgs e)
        {

            int request_article = Convert.ToInt32(Request.QueryString["articol"]);
            DataTable dt = SQLHelper.selectArticle(request_article);

            if (dt.Rows.Count > 0)
            {
                System.Diagnostics.Debug.WriteLine(txt_title.InnerText);
                System.Diagnostics.Debug.WriteLine(txt_content.InnerText);

                SQLHelper.updateArticle(txt_title.InnerText, txt_content.InnerText, request_article);
            }
        }
    }
}