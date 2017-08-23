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
            if (!IsPostBack)
            {
                DataTable dt = SQLHelper.Generate_my_channels(((User)Session["user"]).Id);
                foreach (DataRow row in dt.Rows)
                {
                    ListItem item = new ListItem(row["Nume"].ToString(), row["ID"].ToString());
                    lb_my_channels.Items.Add(item);
                }
            }


        }
    }
}