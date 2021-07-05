<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="Obligatorio_2.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h5 style="border: 1px solid black; font-size:20px; width: 911px;">
        Desarrollado por Xavier de Mello,German Marr y Enzo Braun   
    </h5>
    <asp:Image ID="Image2" runat="server" Height="142px" 
        ImageUrl="~/Resources/redesSociales.jpg" Width="398px" style="float:right;"/>
    <br />

    <div style="background:green; width: 432px; height:160px;">
        <h4 style="color:Black; text-align:center; font-size:20px; font-weight: bold;">
        Ubicacion
            <asp:Image ID="Image3" runat="server" Height="100px" 
                ImageUrl="~/Resources/Ubicacion.png" Width="419px" style="float:left; margin:5px;"/>
        </h4>
        <h6 style="color:Black; font-weight: bold; ">
        Domingo Baquez 820, Uruguay
        </h6>

    </div>

    </asp:Content>
