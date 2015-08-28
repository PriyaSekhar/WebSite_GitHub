using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    String UserId = "V820350";
    //String UserId = Session["UserId"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //resetPanelsAndLabels();
            DataAccessLayer dal = new DataAccessLayer();
            DDL_AppName.DataSource = dal.getAppDetails(UserId);
            DDL_AppName.DataTextField = "AppName";
            DDL_AppName.DataValueField = "AppName";
            DDL_AppName.DataBind();
        }
    }

    private void resetPanelsAndLabels()
    {
        Panel_Databases.Visible = false;
        Panel_SQLJobs.Visible = false;
        PanelErrorMessages.Visible = false;
        Panel_Statistics.Visible = false;
        Label_ErrorMessage.Text = "";
    }

    protected void DDL_AppName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataAccessLayer dal = new DataAccessLayer();
        DDL_ServerName.DataSource = dal.getServerIpDetails(DDL_AppName.SelectedValue);
        DDL_ServerName.DataTextField = "ServerIp";
        DDL_ServerName.DataValueField = "ServerIp";
        DDL_ServerName.DataBind();
    }

    protected void Button_SQLJobs_Click(object sender, EventArgs e)
    {
        resetPanelsAndLabels();
        DataAccessLayer dal = new DataAccessLayer();
        String AppName = DDL_AppName.SelectedValue;
        String ServerIp = DDL_ServerName.SelectedValue;
        DataSet ds = dal.getSqlJobsByServerIp(ServerIp);
        if(ds.Tables[0].Rows.Count > 0)
        {
            Panel_SQLJobs.Visible = true;
            GridView_JobDetails.DataSource = ds;
            GridView_JobDetails.DataBind();
        }
        
        else
        {
            PanelErrorMessages.Visible = true;
            Label_ErrorMessage.Visible = true;
            Label_ErrorMessage.Text = String.Format("There are no SQL jobs scheduled on the server: {0}",ServerIp);
        }
    }

    protected void Button_Statistics_Click(object sender, EventArgs e)
    {
        resetPanelsAndLabels();
        DataAccessLayer dal = new DataAccessLayer();
        String AppName = DDL_AppName.SelectedValue;
        String ServerIp = DDL_ServerName.SelectedValue;
        DataSet ds = dal.getStatsByServerIp(ServerIp);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Panel_Statistics.Visible = true;
            GridView_ServerStats.DataSource = ds;
            GridView_ServerStats.DataBind();
        }

        else
        {
            PanelErrorMessages.Visible = true;
            Label_ErrorMessage.Visible = true;
            Label_ErrorMessage.Text = String.Format("There is some error while connecting to the server {0}", ServerIp);
        }
    }

    protected void Button_Databases_Click(object sender, EventArgs e)
    {
        DataAccessLayer dal = new DataAccessLayer();
        resetPanelsAndLabels();
        DataTable databases = dal.getDatabaseNames();
        if (databases.Rows.Count > 0)
        {

            Panel_Databases.Visible = true;
            GridView_Databases.DataSource = databases;
            GridView_Databases.DataBind();
        }
        else
        {
            PanelErrorMessages.Visible = true;
            Label_ErrorMessage.Visible = true;
            Label_ErrorMessage.Text = String.Format("There is some error while connecting to the server " );
        }

        //foreach (DataRow database in databases.Rows)
        //{
        //    String databaseName = database.Field<String>("database_name");
        //    short dbID = database.Field<short>("dbid");
        //    DateTime creationDate = database.Field<DateTime>("create_date");
        //}
    }

    protected void GridView_Databases_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}