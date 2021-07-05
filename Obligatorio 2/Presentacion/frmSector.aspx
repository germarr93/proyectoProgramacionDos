<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSector.aspx.cs" Inherits="Obligatorio_2.Presentacion.frmSector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="label1" runat="server" Text="Nombre Sector"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtNombre" ErrorMessage="Solo Letras" Font-Bold="True" 
        ForeColor="#990000" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
    <br />
    &nbsp;&nbsp;&nbsp;
    <br />
    <asp:Label ID="Label2" runat="server" Text="Cantidad Asientos"></asp:Label>
&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCantidadA" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="txtCantidadA" ErrorMessage="Solo Numeros" Font-Bold="True" 
        ForeColor="#990000" ValidationExpression="\d+"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Button ID="btnAlta" runat="server" Text="Alta" 
    onclick="btnAlta_Click" Height="26px" Width="78px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnBaja" runat="server" Text="Baja" 
    onclick="btnBaja_Click" Height="26px" Width="78px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
    onclick="btnModificar_Click" Height="26px" Width="78px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnLimiar" runat="server" Text="Limpiar" 
    onclick="btnLimiar_Click" Height="26px" Width="78px" />
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text="Lista de Sectores"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="gvListaSectores" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="gvListaSectores_SelectedIndexChanged" 
        ShowHeaderWhenEmpty="True" Width="583px">
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
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server" Text="Asignar Sectores a una Sala"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Sala"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtSala" runat="server" Height="26px" ReadOnly="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnAsignar" runat="server" onclick="btnAsignar_Click" 
        Text="Asignar" Height="26px" Width="70px" />
    <br />
    <br />
    <asp:Label ID="Label7" runat="server" Text="Sector"></asp:Label>
&nbsp;<asp:TextBox ID="txtSector" runat="server" Height="26px" ReadOnly="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnEliminar" runat="server" Text="Baja" 
        onclick="btnEliminar_Click" Width="70px" Height="26px" />
    <br />
    <br />
    <asp:Label ID="lblMensaje2" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
        Text="Buscar Sectores de Sala" />
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label8" runat="server" Text="Lista de Salas"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="gvListaSala" runat="server" CellPadding="4" 
        ForeColor="Black" GridLines="Horizontal" 
        onselectedindexchanged="gvListaSala_SelectedIndexChanged" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
        BorderWidth="1px" ShowHeaderWhenEmpty="True" Width="579px">
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Asignar" 
                ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label9" runat="server" Text="Lista de Sectores"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="gvSectores" runat="server" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" 
        onselectedindexchanged="gvSectores_SelectedIndexChanged" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        ShowHeaderWhenEmpty="True" Width="578px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Asignar" 
                ShowSelectButton="True" />
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
    <asp:Label ID="Label10" runat="server" Text="Sala:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblObjetSala" runat="server"></asp:Label>
    <br />
    <br />
        <asp:GridView ID="gvListaSectoresEnSala" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="gvListaSectoresEnSala_SelectedIndexChanged" 
        Width="587px" ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>

</asp:Content>
