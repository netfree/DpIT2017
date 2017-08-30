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

        protected void btn_submit_Click(object sender, EventArgs e)
        {

        }
    }
}