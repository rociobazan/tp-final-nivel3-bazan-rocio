<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CatalogoWeb.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 pt-5">
        <div class="row">
            <div class="col-12 col-sm-7 col-md-6 m-auto shadow">
                <h2 class="text-center">Registrarse</h2>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox CssClass="form-control" ID="txtPass" runat="server" />
                </div>
                <div class="text-center pb-3">
                    <asp:Button OnClick="btnRegistrarse_Click" CssClass="btn btn-primary" Text="Registrarse" ID="btnRegistrarse" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
