using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class foo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ConnectDB conn = new ConnectDB();
        conn.executeQuery("");
        EncryptUsuario enc = new EncryptUsuario();
        string foo = enc.DesEncriptar("70C90D30D90CA");
    }
}