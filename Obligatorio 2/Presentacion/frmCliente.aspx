<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="Obligatorio_2.Presentacion.frmCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    #form
    {
        width:40%;
        padding:10px;
    }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="form">

    <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtNombre" ErrorMessage="Solo Letras" Font-Bold="True" 
            ForeColor="Red" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Telefono"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="txtTelefono" ErrorMessage="Solo Numeros" Font-Bold="True" 
            ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Cedula"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtCedula" runat="server" MaxLength="8"></asp:TextBox>
  &nbsp;&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="txtCedula" ErrorMessage="Solo Numeros" Font-Bold="True" 
            ForeColor="Red" ValidationExpression="\d+"></asp:RegularExpressionValidator>
  </div>
    &nbsp;&nbsp;
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnAlta" runat="server" Text="Alta" 
    onclick="btnAlta_Click" Width="118px" Height="26px" />
    &nbsp;&nbsp;
    &nbsp;<asp:Button ID="btnBaja" runat="server" onclick="btnBaja_Click" 
        Text="Baja" Width="118px" Height="26px"/>
    &nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" 
        Height="26px" onclick="btnModificar_Click" Width="118px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text="." Font-Bold="True"></asp:Label>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp; <br />
    <asp:GridView ID="gvListaClientes" runat="server" Width="386px" 
    onselectedindexchanged="gvListaClientes_SelectedIndexChanged" 
        ShowHeaderWhenEmpty="True" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    </asp:Content>
