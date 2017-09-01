using System;
using System.Data;
using ConnectToUE;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace connect_to_ue
{
    public partial class editare_profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Utilizator_ID = SQLHelper.giveEmailgetID(((User)Session["user"]).Email.ToString());

            if (!IsPostBack)
            {
                DataTable dt = SQLHelper.Show_Channels();
                foreach (DataRow row in dt.Rows)
                {
                    ListItem item = new ListItem(row["Nume"].ToString(), row["ID"].ToString());
                    if(SQLHelper.channelBelongtoUser(Convert.ToInt32(item.Value), Utilizator_ID))
                        item.Selected = true;
                    checkboxlist_channels.Items.Add(item);
                }
            }

            

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        { 
            int Utilizator_ID = SQLHelper.giveEmailgetID(((User)Session["user"]).Email.ToString());

            SQLHelper.deleteAllChannelsFromUser(Utilizator_ID);

            foreach (ListItem item in checkboxlist_channels.Items)
            {
                if (item.Selected)
                    SQLHelper.InsertPreferences(Utilizator_ID, Convert.ToInt32(item.Value));
            }

            Response.Redirect(Request.RawUrl);
        }
    }
}