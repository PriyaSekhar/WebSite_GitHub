using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for DataAccessLayer
/// </summary>
public class DataAccessLayer
{
    String ConnString = ConfigurationManager.ConnectionStrings["ConnString_Dev"].ToString();
    String QueryString = string.Empty;
    public DataAccessLayer()
    {
        //
        // TODO: Add constructor logic here
        //

    }

    public DataSet getAppDetails(String vzid)
    {
        DataSet ds = new DataSet();
        QueryString = String.Format("select distinct AppName from AppUserMapping(nolock) where VZID = '{0}'", vzid);
        using (SqlConnection connection =
        new SqlConnection(ConnString))
        {
            
            SqlDataAdapter da = new SqlDataAdapter(QueryString, connection);            
            da.Fill(ds);   
            return ds;
        }
    }

    public DataSet getServerIpDetails(String AppName)
    {
        DataSet ds = new DataSet();
        QueryString = String.Format("select distinct ServerIp from AppServerMapping(nolock) where AppName = '{0}'", AppName);
        using (SqlConnection connection =
        new SqlConnection(ConnString))
        {

            SqlDataAdapter da = new SqlDataAdapter(QueryString, connection);
            da.Fill(ds);
            return ds;
        }
    }

    public DataSet getSqlJobsByServerIp(String ServerIp)
    {
        String TargetConnString = getTargetConnStringForIP(ServerIp);
        DataSet ds = new DataSet();
        QueryString = String.Format("use msdb exec sp_help_jobhistory");
        //SqlCommand cmd = new SqlCommand();
        //cmd.CommandText = " sp_help_jobhistory";
        //cmd.CommandType = CommandType.Text;
        using (SqlConnection connection =
        new SqlConnection(TargetConnString))
        {

            SqlDataAdapter da = new SqlDataAdapter(QueryString, connection);
            da.Fill(ds);
            return ds;
        }
    }

    public DataSet getStatsByServerIp(String ServerIp)
    {
        String TargetConnString = getTargetConnStringForIP(ServerIp);
        DataSet ds = new DataSet();
        //QueryString = String.Format("use msdb exec sp_help_jobhistory");
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "getServerStats";
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlConnection connection =
        new SqlConnection(TargetConnString))
        {
            cmd.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }
    }

    public DataTable getDatabaseNames()
    {
        String TargetConnString = String.Format("server = SCSBWIN-385575\\SQLEXPRESS;Integrated Security = true;");
        using (SqlConnection con = new SqlConnection(TargetConnString))
        {
            con.Open();
            DataTable databases = con.GetSchema("Databases");

            return databases;
        }
    }

    public int getUserdetails(string vzID,string pwd)
    {
        DataSet ds = new DataSet();
        int intvalid = 0;      
        QueryString = String.Format("select VZID,Password from UserDetails(nolock) where VZID = '{0}' and Password='{1}'", vzID,pwd);
        using (SqlConnection connection =
        new SqlConnection(ConnString))
        {

            SqlDataAdapter da = new SqlDataAdapter(QueryString, connection);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
               intvalid = 1;
            }
        }
        return intvalid;
    }


    private string getTargetConnStringForIP(string serverIp)
    {
        DataSet ds = new DataSet();
        String targetConnString = string.Empty;
        QueryString = String.Format("select distinct ConnectionString from AppServerMapping(nolock) where ServerIp = '{0}'", serverIp);
        using (SqlConnection connection =
        new SqlConnection(ConnString))
        {

            SqlDataAdapter da = new SqlDataAdapter(QueryString, connection);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                targetConnString = ds.Tables[0].Rows[0][0].ToString();
            }
        }
        return targetConnString;
    }
}