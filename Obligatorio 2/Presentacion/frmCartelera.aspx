<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCartelera.aspx.cs" Inherits="Obligatorio_2.Presentacion.frmCartelera" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Fecha Comienzo"></asp:Label>
&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtFechaComienzo" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
<br />
<asp:Label ID="Label2" runat="server" Text="Fecha Fin"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtFechaFin" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
<br />
<asp:Label ID="Label3" runat="server" Text="Espectaculo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtEspectaculo" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
<br />
<asp:Label ID="Label4" runat="server" Text="Cartelera"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtCartelera" runat="server" ReadOnly="True"></asp:TextBox>
<asp:Image ID="Image2" runat="server" Height="72px" 
        ImageUrl="~/Resources/Cartelera.png" Width="427px" 
        style="float:right; position:relative; top: -131px; left: -30px;" />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label>
<br />
<asp:Button ID="btnAlta" runat="server" onclick="btnAlta_Click" Text="Alta" 
        Width="70px" />
&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnBaja" runat="server" onclick="btnBaja_Click" Text="Baja" 
        Width="70px" />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label8" runat="server" Text="Lista de Cartelera"></asp:Label>
<br />
<asp:ListBox ID="lstListaCartelera" runat="server" AutoPostBack="True" 
    onselectedindexchanged="lstListaCartelera_SelectedIndexChanged" Width="912px">
</asp:ListBox>
<br />
<br />
&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label6" runat="server" Font-Bold="True" 
    Text="Seleccione fecha Comienzo"></asp:Label>
<br />
<asp:Calendar ID="dtpFechaComienzo" runat="server" BackColor="White" 
    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
    ForeColor="#003399" Height="200px" 
    onselectionchanged="dtpFechaComienzo_SelectionChanged" Width="220px">
    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
    <OtherMonthDayStyle ForeColor="#999999" />
    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
        Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
    <WeekendDayStyle BackColor="#CCCCFF" />
</asp:Calendar>
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label7" runat="server" Font-Bold="True" 
    Text="Seleccione fecha Fin"></asp:Label>
<br />
<asp:Calendar ID="dtpFechaFin" runat="server" BackColor="White" 
    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
    ForeColor="#003399" Height="200px" 
    onselectionchanged="dtpFechaFin_SelectionChanged" Width="220px">
    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
    <OtherMonthDayStyle ForeColor="#999999" />
    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
        Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
    <WeekendDayStyle BackColor="#CCCCFF" />
</asp:Calendar>
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label9" runat="server" Font-Bold="True" 
    Text="Lista de Espectaculos"></asp:Label>
<br />
<asp:GridView ID="gvListaEspectaculo" runat="server" CellPadding="4" 
    ForeColor="#333333" GridLines="None" 
    onselectedindexchanged="gvListaEspectaculo_SelectedIndexChanged" 
    ShowHeaderWhenEmpty="True" Width="484px">
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
</asp:Content>
