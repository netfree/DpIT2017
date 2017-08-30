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
            if (!IsPostBack)
            {
                //DataTable dt = SQLHelper.GetChannels();
                //foreach (DataRow row in dt.Rows)
                //{
                //    ListItem item = new ListItem(row["Nume"].ToString(), row["ID"].ToString());
                //    ckboxlist_channels.Items.Add(item);
                //}
            }
        }

        protected void btn_submit_art_Click(object sender, EventArgs e)
        {
            /// o sa crape daca nu exista sesiunea
            if (((User)Session["user"]).isAdmin() == false)
                lbl_error.Text = "Nu ai autorizatie sa adaugi un nou articol!";
            else
                SQLHelper.insertArticle(txt_title.InnerText, txt_content.InnerText, ((User)Session["user"]).Email);

            
               

        }
    }
}
