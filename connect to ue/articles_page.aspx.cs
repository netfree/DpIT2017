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

        string ChannelName = "Nothing";

        public string getPublicChannel()
        {
            return ChannelName;
        }

        public void RefreshList(bool isPostBack)
        {
            lb_my_channels.Items.Clear();
            lb_not_my_channels.Items.Clear();

            ListItem item2 = new ListItem("Toate articolele:", "");

            item2.Selected = isPostBack;

            lb_my_channels.Items.Add(item2);


            DataTable dt = SQLHelper.Generate_my_channels(((User)Session["user"]).Id);
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["Nume"].ToString(), row["ID"].ToString());
                lb_my_channels.Items.Add(item);
            }

            lb_my_channels.AutoPostBack = true;

            dt = SQLHelper.Show_Channels();

            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(row["Nume"].ToString(), row["ID"].ToString());

                bool valid = true;

                foreach (ListItem myitm in lb_my_channels.Items)
                {
                    if (myitm.Value == item.Value)
                        valid = false;
                }

                if (valid)
                    lb_not_my_channels.Items.Add(item);
            }

            lb_not_my_channels.AutoPostBack = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

            div_subscibe.Visible = false;


            if (!IsPostBack)
            {
                RefreshList(true);
            }



            DataTable articles = SQLHelper.Show_Articles();
            rpt_list_articles.DataSource = articles;
            rpt_list_articles.DataBind();

        }

        protected void lb_my_channels_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_not_my_channels.ClearSelection();

            var selection = lb_my_channels.SelectedItem;

            div_subscibe.Visible = false;

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

        protected bool is_item_in_lbl_my_channels(ListItem item)
        {
            foreach (ListItem myitm in lb_my_channels.Items)
            {
                if (myitm.Value == item.Value)
                    return true;
            }
            return false;
        }


        protected void lb_not_my_channels_SelectedIndexChanged(object sender, EventArgs e)
        {
                lb_my_channels.ClearSelection();

                string selection = lb_not_my_channels.SelectedItem.ToString();
                ChannelName = selection;
                div_subscibe.Visible = true;


                DataTable articles = SQLHelper.Show_Curstom_Articles(SQLHelper.giveNumegetID(lb_not_my_channels.SelectedItem.ToString()));
                //DataRow row = articles.NewRow();
                //row["Titlu"] = "Friendly Reminder, please Subscribe jerk";
                //row["Continut"] = @"<a href=""/adaugare_articol"">Subscribe Here</a>";
                //articles.Rows.InsertAt(row, 0);

                

                rpt_list_articles.DataSource = articles;
                rpt_list_articles.DataBind();
         
        }

        protected void btn_subscribe_Click(object sender, EventArgs e)
        {
            int subscribe_to = SQLHelper.giveNumegetID(lb_not_my_channels.SelectedItem.ToString());
            if (subscribe_to != 0) {
                SQLHelper.InsertPreferences(((User)Session["user"]).Id, subscribe_to);
                RefreshList(false);
                System.Diagnostics.Debug.WriteLine("Good");
            }
        }
    }
}