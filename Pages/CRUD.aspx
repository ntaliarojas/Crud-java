<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="CRUD3.Pages.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

<h1><asp:Label ID="lbltitulo" runat="server"> </asp:Label></h1>  
    <form id="formulario" runat="server">

        

        <asp:Label ID="label1" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="nombre" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="label2" runat="server" Text="Edad"></asp:Label>
        <asp:TextBox ID="edad" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="label3" runat="server" Text="Correo"></asp:Label>
        <asp:TextBox ID="correo" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="label4" runat="server" Text="Fecha De Nacimiento"></asp:Label>
        <asp:TextBox ID="fecha_nacimiento" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="BtnCreate" runat="server" Text="Crear" OnClick="Create_Click" Visible="false" />
        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" OnClick="Update_Click" Visible="false" />
        <asp:Button ID="BtnVolver" runat="server" Text="Volver" OnClick="BtnVolver_Click" />
    </form>
</asp:Content>

