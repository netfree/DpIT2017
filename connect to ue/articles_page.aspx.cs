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
                ListItem item2 = new ListItem("Toate articolele:", "");
                lb_my_channels.Items.Add(item2);


                DataTable dt = SQLHelper.Generate_my_channels(((User)Session["user"]).Id);
                foreach (DataRow row in dt.Rows)
                {
                    ListItem item = new ListItem(row["Nume"].ToString(), row["ID"].ToString());
                    lb_my_channels.Items.Add(item);
                }

               
                lb_my_channels.AutoPostBack = true;
            }



            DataTable articles = SQLHelper.Show_Articles();
            rpt_list_articles.DataSource = articles;
            rpt_list_articles.DataBind();

        }

        protected void lb_my_channels_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selection = lb_my_channels.SelectedItem;
<<<<<<< HEAD
            

            DataTable articles = SQLHelper.Show_Curstom_Articles(SQLHelper.giveNumegetID(lb_my_channels.SelectedItem.ToString()));
            rpt_list_articles.DataSource = articles;
            rpt_list_articles.DataBind();
=======
>>>>>>> 677593ab703ae2c611298cab1967ace37c1b330e

            if (lb_my_channels.SelectedItem.ToString() != "Toate articolele:")
            {
                DataTable articles = SQLHelper.Show_Curstom_Articles(SQLHelper.giveNumegetID(lb_my_channels.SelectedItem.ToString()));
                rpt_list_articles.DataSource = articles;
                rpt_list_articles.DataBind();
            }
            else
            {
                DataTable articles = SQLHelper.Show_Articles();
                rpt_list_articles.DataSource = articles;
                rpt_list_articles.DataBind();
            }
        }
    }
}