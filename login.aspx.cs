using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btnlogin_Click(object sender, EventArgs e)
    {
        DataAccessLayer dal = new DataAccessLayer();
        string strVzid = Txtvzid.Text.Trim();
        string strPwd = Txtpwd.Text.Trim();
        if(strVzid != "" && strPwd != "")
        {
            int validUser = dal.getUserdetails(strVzid, strPwd);
            if (validUser == 1)
            {
                Session["UserId"] = strVzid;
                Session["Password"] = strPwd;
                Response.Redirect("Home.aspx");

            }
            else
            {
                Label_LoginError.Text = "User name and password are not matched";
            }
        }
        
    }
}