<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSocio.aspx.cs" Inherits="Obligatorio_2.Presentacion.frmSocio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
       
        <asp:Label ID="Label1" runat="server" Text="Seleccione un tipo de Socio:" 
            Font-Bold="True" Font-Overline="False"></asp:Label>
        &nbsp;
        <asp:RadioButton ID="rdbComun" runat="server" Text="Socio Comun" 
            GroupName="Socio" Font-Italic="False" Font-Overline="False" 
            Font-Strikeout="False" Font-Underline="False" />
&nbsp;<asp:RadioButton ID="rdbPremiun" runat="server" Text="Socio Premiun" 
            GroupName="Socio" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image1" runat="server" Height="67px" 
            ImageUrl="~/Resources/logo-espectaculos.png" Width="146px" style="float:right;" />
    </p>
    <p>

        <asp:Label ID="lblCedula" runat="server" Text="Cedula"></asp:Label>
&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtCl" runat="server" 
            style="margin-left: 0px; margin-top: 0px" Width="300px" MaxLength="8" ></asp:TextBox>
    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
            runat="server" ControlToValidate="txtCl" ErrorMessage="Solo Numeros" 
            Font-Bold="True" ForeColor="#990000" ValidationExpression="\d+"></asp:RegularExpressionValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
&nbsp; <asp:TextBox ID="txtNombre" runat="server" Width="300px" ></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ControlToValidate="txtNombre" ErrorMessage="Solo Letras" Font-Bold="True" 
            ForeColor="#990000" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
    </p>
    <p>
        <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" Width="300px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
        &nbsp;<asp:TextBox ID="txtTelefono" runat="server" Width="300px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="txtTelefono" ErrorMessage="Solo Numeros" Font-Bold="True" 
            ForeColor="#990000" ValidationExpression="\d+"></asp:RegularExpressionValidator>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtEmail" ErrorMessage="Fromato Incorrecto" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            Font-Bold="True" ForeColor="#990000"></asp:RegularExpressionValidator>
    </p>
    <p>
        <asp:Button ID="btnAlta" runat="server" Text="Alta" Width="220px" 
            onclick="btnAlta_Click" Height="26px" />
    &nbsp;&nbsp;
    </p>
    <p>
        <asp:Button ID="btnBaja" runat="server" Text="Baja" 
            onclick="btnBaja_Click" Width="223px" Height="26px" />
    </p>
    <p>
        <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="223px" 
            onclick="btnModificar_Click" Height="26px" />
    </p>
    <p>
        <asp:Button ID="btnLimpiar" runat="server" Height="26px" 
            onclick="btnLimpiar_Click" Text="Limpiar" Width="222px" />
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensaje" runat="server" Text="." Font-Bold="True"></asp:Label>
        &nbsp;</p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblSociosComunes" runat="server" Text="Lista Socios Comunes"></asp:Label>
        
    </p>
    <p>
        <asp:GridView ID="gvSocioComun" runat="server" 
            onselectedindexchanged="gvSocioComun_SelectedIndexChanged" CellPadding="4" 
            ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblSocioPremiun" runat="server" Text="Lista Socios Premiun"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="gvSocioPremiun" runat="server" 
            onselectedindexchanged="gvSocioPremiun_SelectedIndexChanged" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
       
</asp:Content>
