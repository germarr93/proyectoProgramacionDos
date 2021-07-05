<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSala.aspx.cs" Inherits="Obligatorio_2.Presentacion.frmSala" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #form
        {
            width:40%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="form">
    <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtNombre" ErrorMessage="Solo Letras" Font-Bold="True" 
            ForeColor="#990000" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Direccion"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Telefono"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="txtTelefono" ErrorMessage="Solo Numeros" Font-Bold="True" 
            ForeColor="#990000" ValidationExpression="\d+"></asp:RegularExpressionValidator>
        </div>
    <br />
    <br />
    <br />
    <asp:Button ID="btnAlta" runat="server" Text="Alta" onclick="btnAlta_Click" 
        Height="26px" Width="78px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnBaja" runat="server" Text="Baja" onclick="btnBaja_Click" 
        Height="26px" Width="78px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
        onclick="btnModificar_Click" Height="26px" Width="78px" />
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Text="Lista de Salas"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="gvListaSalas" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="gvListaSalas_SelectedIndexChanged" 
        ShowHeaderWhenEmpty="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    <br />
</asp:Content>
