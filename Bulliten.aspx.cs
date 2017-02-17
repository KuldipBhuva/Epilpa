using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Bulliten : System.Web.UI.Page
{
    clsbulletin Bullet = new clsbulletin();
    DataTable objdt = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["ISLogin"]) != "Yes")
        {
            Response.Redirect("index.aspx?login=no");
        }
        FillGrid();
    }
    private void FillGrid()
    {
        try
        {
            objdt = new DataTable();
            Bullet = new clsbulletin();
            Bullet.Action = "Grid";
            objdt = Bullet.GetBullettin();
            if (objdt.Rows.Count > 0)
            {
                GVBulliten.DataSource = objdt;
                GVBulliten.DataBind();
            }
            else
            {
                GVBulliten.DataSource = null;
                GVBulliten.DataBind();
            }

        }
        catch (Exception ex)
        {
            
            throw ex;
        }
        
    }
}