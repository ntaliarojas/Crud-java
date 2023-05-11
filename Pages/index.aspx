<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CRUD3.Pages.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

      <form runat="server">
        <br />
        <div class="mx-auto" style="width:300px">
            <h2>Listado de Registros</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:Button ID="BtnCreate" OnClick="Create_Click" CssClass="btn btn-success form-control-sm" runat="server" Text="Crear Registro" />
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small" BorderStyle="Dotted">
                <asp:GridView ID="gvusuarios"  CssClass="table table-borderless table-hover" runat="server">
                    <Columns>
                        <asp:TemplateField  HeaderText="Opciones">
                            <ItemTemplate>
                                <asp:Button CssClass="btn btn-danger" ID="read" runat="server" Text="Read" OnClick="Read_Click" />
                                <asp:Button CssClass="btn btn-success" ID="update" runat="server" Text="Update" OnClick="Update_Click" />
                                <asp:Button CssClass="btn btn-warning" ID="delete" runat="server" Text="Delete" OnClick="Delete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </form>
</asp:Content>
