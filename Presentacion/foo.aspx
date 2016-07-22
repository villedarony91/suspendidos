<%@ Page Language="C#" AutoEventWireup="true" CodeFile="foo.aspx.cs" Inherits="foo" %>

<!DOCTYPE html>
<html>
<head>
    <!--Import Google Icon Font-->
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <!--Import materialize.css-->
    <link type="text/css" rel="stylesheet" href="../materialize/css/materialize.min.css" media="screen,projection" />

    <!--Let browser know website is optimized for mobile-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>

<body>
    <form id="form1" runat="server">
    <!--Import jQuery before materialize.js-->
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="../materialize/js/materialize.min.js"></script>

        <nav>
            <div class="nav-wrapper">
                <a href="#!" class="brand-logo">Logo</a>
                <a href="#" data-activates="mobile-demo" class="button-collapse"><i class="material-icons">menu</i></a>
                <ul class="right hide-on-med-and-down">
                    <li><a href="sass.html">Buscar</a></li>
                    <li><a href="badges.html">Suspender</a></li>
                </ul>
                <ul class="side-nav" id="mobile-demo">
                    <li><a href="sass.html">Buscar</a></li>
                    <li><a href="badges.html">Suspender</a></li>
                </ul>
            </div>
        </nav>
    <div class ="row"></div>
      <div class="row">
      <div class="row">
        <div class="input-field col s3">
          <i class="material-icons prefix">account_circle</i>
          <input id="icon_prefix" type="text" class="validate" runat ="server">
          <label for="icon_prefix">No. de Boleta</label>
            </div>
          <div class="col s4">
         <div class="input-field col s10">
          <i class="material-icons prefix">account_circle</i>
          <input id="icon_telephone" type="tel" class="validate" runat ="server">
          <label for="icon_telephone">No. DPI</label>
             </div>
        </div>
          <a class="waves-effect waves-light btn-large" runat ="server" onserverclick="searchEvent">Buscar</a>   
             </div>
  </div>
        <div class ="divider"></div>
       <div class ="row">
            <div class =" col s4 offset-s4">
        |    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

            </div>
       </div>

    </form>
       
</body>
</html>
<script>
    // Initialize collapse button
    $(".button-collapse").sideNav();
    // Initialize collapsible (uncomment the line below if you use the dropdown variation)
    $('.collapsible').collapsible();
</script>




