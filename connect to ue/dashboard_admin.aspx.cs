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
    public partial class dashboard_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = SQLHelper.GetAllArticlesForAdmin(((User)Session["user"]).Id);

            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["Titlu"].ToString(), row["Id"].ToString());
                lb_my_articles.Items.Add(item);
            }

            lb_my_articles.AutoPostBack = true;
        }

        protected void lb_my_articles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = Convert.ToInt32(lb_my_articles.SelectedItem.Value);
            Response.Redirect("/editare_articol?articol="+selected.ToString());
        }

        protected void linkbutton_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("/adaugare_articol");
        }
    }
}