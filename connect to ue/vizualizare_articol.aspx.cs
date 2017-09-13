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
    public partial class vizualizare_articol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int requested_id = Convert.ToInt32(Request.QueryString["articol"]);

            DataTable dt = SQLHelper.Show_Articles();
            DataRow selectedArticle = dt.NewRow();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Id"].ToString() == Request.QueryString["articol"])
                    selectedArticle = dr;
            }
            lb_title.Text = selectedArticle["Titlu"].ToString();
            lb_continut.Text = selectedArticle["Continut"].ToString();
        }
    }
}