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
    public partial class adaugare_articol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = SQLHelper.GetChannels();
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["Nume"].ToString(), row["ID"].ToString());
                ckboxlist_channels.Items.Add(item);
            }
        }
    }
}
