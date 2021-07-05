<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVenta.aspx.cs" Inherits="Obligatorio_2.Presentacion.frmVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" Text="Espectaculo" Font-Bold="True"></asp:Label>
<asp:TextBox ID="txtEspectaculo" runat="server" ReadOnly="True"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Persona" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPersona" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label13" runat="server" Text="Sector" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtSector" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label11" runat="server" Text="Fila" Font-Bold="True"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtFila" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtFila" ErrorMessage="Solo numeros" Font-Bold="True" 
        ForeColor="#FF3300" ValidationExpression="\d+"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="Label12" runat="server" Text="Columna" Font-Bold="True"></asp:Label>
    &nbsp;&nbsp;
    <asp:TextBox ID="txtColumna" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="txtColumna" ErrorMessage="Solo numeros" Font-Bold="True" 
        ForeColor="#FF3300" ValidationExpression="\d+"></asp:RegularExpressionValidator>
<br />
    <br />
    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Seleccione : "></asp:Label>
    <asp:RadioButton ID="rdbCliente" runat="server" GroupName="Personas" 
        Text="Cliente" />
&nbsp;<asp:RadioButton ID="rdbSocioComun" runat="server" GroupName="Personas" 
        Text="Socio Comun" />
&nbsp;<asp:RadioButton ID="rdbSocioPremiun" runat="server" GroupName="Personas" 
        Text="Socio Premiun" />
    <br />
<asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label>
<br />
<asp:Button ID="btnAlta" runat="server" Text="Alta" Width="70px" 
        onclick="btnAlta_Click" />
&nbsp;<asp:Button ID="btnBaja" runat="server" Text="Baja" Width="70px" 
        onclick="btnBaja_Click" style="height: 26px" />
&nbsp;<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label3" runat="server" Text="Lista de Ventas" Font-Bold="True" 
        Font-Size="Medium"></asp:Label>
    <br />
<br />
    <asp:ListBox ID="lstListaVentas" runat="server" Width="915px" 
        onselectedindexchanged="lstListaVentas_SelectedIndexChanged" 
        AutoPostBack="True"></asp:ListBox>
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label4" runat="server" Text="Lista de Espectaculos"></asp:Label>
<br />
    <br />
    <asp:GridView ID="gvEspectaculo" runat="server" 
        onselectedindexchanged="gvEspectac_SelectedIndexChanged" BackColor="White" 
        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ShowHeaderWhenEmpty="True" Width="493px">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
    <br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label5" runat="server" Text="Sectores"></asp:Label>
<br />
<asp:ListBox ID="lstSector" runat="server" Width="297px" 
        onselectedindexchanged="lstSector_SelectedIndexChanged" 
        AutoPostBack="True"></asp:ListBox>
<br />
<br />
<asp:Label ID="Label6" runat="server" Text="Lista Socio Premiun"></asp:Label>
<br />
<asp:GridView ID="gvSocioPremiun" runat="server" 
    onselectedindexchanged="gvSocioPremiun_SelectedIndexChanged" BackColor="White" 
        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
        GridLines="Horizontal" ShowHeaderWhenEmpty="True">
    <Columns>
        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
    </Columns>
    <FooterStyle BackColor="White" ForeColor="#333333" />
    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#487575" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#275353" />
</asp:GridView>
<br />
<asp:Label ID="Label7" runat="server" Text="Lista Socio Comun"></asp:Label>
<br />
<asp:GridView ID="gvSocioComun" runat="server" 
    onselectedindexchanged="gvSocioComun_SelectedIndexChanged" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" ShowHeaderWhenEmpty="True">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
    </Columns>
    <FooterStyle BackColor="#CCCC99" />
    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
    <RowStyle BackColor="#F7F7DE" />
    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#FBFBF2" />
    <SortedAscendingHeaderStyle BackColor="#848384" />
    <SortedDescendingCellStyle BackColor="#EAEAD3" />
    <SortedDescendingHeaderStyle BackColor="#575357" />
</asp:GridView>
<br />
<asp:Label ID="Label8" runat="server" Text="Lista de Clientes"></asp:Label>
<br />
<asp:GridView ID="gvListaCliente" runat="server" 
    onselectedindexchanged="gvListaCliente_SelectedIndexChanged" 
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
        CellPadding="4" CellSpacing="2" ForeColor="Black" ShowHeaderWhenEmpty="True" 
        Width="418px">
    <Columns>
        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
    </Columns>
    <FooterStyle BackColor="#CCCCCC" />
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
    <RowStyle BackColor="White" />
    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#808080" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#383838" />
</asp:GridView>
    <br />
    <asp:GridView ID="gvMatrizSector" runat="server">
    </asp:GridView>

    <br />


</asp:Content>
