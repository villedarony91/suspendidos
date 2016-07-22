using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class foo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    public void searchEvent(object sender, EventArgs e)
    {
        ConnectDB conn = new ConnectDB();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("SELECT NROBOLETA AS BOLETA,")
            .Append("FECINSCRIPCION AS FECHA_INS, NOM1 AS P_NOMBRE, NOM2 AS S_NOMBRE, APE1 AS P_APELLIDO,")
            .Append("APE2 AS S_APELLIDO, APE3 AS T_APELLIDO, STATUS AS ESTADO, GENERO ")
            .Append("FROM TPADRON WHERE NROBOLETA = 9895309");
        DataTable dt = conn.executeQuery(sb.ToString());
        DataRow dr = dt.Rows[0];
        String fName = dr["P_NOMBRE"].ToString();
        String sName = dr["S_NOMBRE"].ToString();
        String lName1 = dr["P_APELLLIDO"].ToString();
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
}