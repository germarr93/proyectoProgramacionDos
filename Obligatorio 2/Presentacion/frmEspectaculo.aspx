<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEspectaculo.aspx.cs" Inherits="Obligatorio_2.Presentacion.frmEspectaculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 953px">
        <div style="height: 437px; border:1px solid black;">
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <div style="width: 432px; float:right; height: 345px;">
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label14" runat="server" Text="Lista de Salas"></asp:Label>
                <br />
                <asp:GridView ID="gvListaDeSalas" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="gvListaDeSalas_SelectedIndexChanged" 
                    ShowHeaderWhenEmpty="True" Width="418px">
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
                <br />
                <asp:ListBox ID="lstSectores" runat="server" Width="418px"></asp:ListBox>
            </div>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtNombre" ErrorMessage="Solo Letras" Font-Bold="True" 
                ForeColor="#990000" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Precio"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="txtPrecio" ErrorMessage="Solo Numeros" Font-Bold="True" 
                ForeColor="#990000" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Tipo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
                runat="server" ControlToValidate="txtTipo" ErrorMessage="Solo Letras" 
                Font-Bold="True" ForeColor="#990000" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Sala"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtSala" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <asp:Button ID="btnAlta" runat="server" Text="Alta" Height="26px" 
                Width="78px" onclick="btnAlta_Click" />
            &nbsp;<asp:Button ID="btnBaja" runat="server" Text="Baja" Height="26px" 
                Width="78px" onclick="btnBaja_Click" />
            &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" Height="26px" 
                Width="78px" onclick="btnModificar_Click" />
            &nbsp;<asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Height="26px" 
                Width="78px" onclick="btnLimpiar_Click" />
            &nbsp;<asp:Button ID="btnBuscarSector" runat="server" Height="26px" 
                onclick="btnBuscarSector_Click" Text="Ver Sectores" Width="97px" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
                ID="Label7" runat="server" Text="Lista de Espectaculos"></asp:Label>
            <br />
            <asp:GridView ID="gvListaEspectaculos" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" 
                onselectedindexchanged="gvListaEspectaculos_SelectedIndexChanged" 
                ShowHeaderWhenEmpty="True" Width="366px">
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
            <br />
            <br />
            <br />
&nbsp;<br />
            <br />
            <br />
            <br />

            <br />
        </div>
        <br />
    
        <div style="height: 496px; border:1px solid black;">
            <div style="width: 442px; float:right; height: 491px; margin-left: 4px;" >
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label15" runat="server" 
                    Text="Lista de Espectaculo"></asp:Label>
                <br />
                <asp:GridView ID="gvListaEspectaculosAsignar" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="gvListaEspectaculosAsignar_SelectedIndexChanged" 
                    ShowHeaderWhenEmpty="True" Width="432px">
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
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label16" runat="server" 
                    Text="Lista de Auspiciantes"></asp:Label>
                <br />
                <asp:GridView ID="gvListaAuspiciante" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="gvListaAuspiciante_SelectedIndexChanged" 
                    ShowHeaderWhenEmpty="True" Width="432px">
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
            </div>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Espectaculo"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEspectaculo" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Auspiciante"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAuspiciante" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblMensajeAsignar" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnAsignar" runat="server" Text="Asignar" Height="26px" 
                Width="78px" onclick="btnAsignar_Click" />
&nbsp;<asp:Button ID="btnRemover" runat="server" Text="Remover" Height="26px" 
                Width="78px" onclick="btnRemover_Click" />
&nbsp;<asp:Button ID="btnLimpiar2" runat="server" Text="Limpiar" Height="26px" 
                Width="78px" onclick="btnLimpiar2_Click" />
&nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar" Height="26px" Width="78px" 
                onclick="btnBuscar_Click" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label12" runat="server" Text="Espectaculo: "></asp:Label>
&nbsp;<asp:Label ID="lblEspectaculo" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="gvListaAuspicianteEspectaculo" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" 
                Width="322px" 
                onselectedindexchanged="gvListaAuspicianteEspectaculo_SelectedIndexChanged">
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
            <br />
        </div>
    </div>
</asp:Content>
