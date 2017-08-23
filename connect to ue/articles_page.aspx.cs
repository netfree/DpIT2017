using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConnectToUE;

namespace connect_to_ue
{
    public partial class articles_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = SQLHelper.Show_Channels();
            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();

            DataTable articles = SQLHelper.Show_Articles();
            rpt_list_articles.DataSource = articles;
            rpt_list_articles.DataBind();
        }
    }
}