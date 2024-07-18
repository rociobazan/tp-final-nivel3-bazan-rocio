<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CatalogoWeb.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            display: block;
            color: red;
            font-size: 0.875rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 pt-5">
        <div class="row">
            <div class="col-12 col-sm-7 col-md-6 m-auto shadow">
                <h2 class="text-center">Registrarse</h2>
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="txtEmail" runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="Ingrese un email válido" CssClass="validacion" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtEmail" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox ClientIDMode="Static" CssClass="form-control" ID="txtPass" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="La contraseña no puede estar vacía" CssClass="validacion" ControlToValidate="txtPass" runat="server" />

                </div>
                <div class="text-center pb-3">
                    <asp:Button OnClick="btnRegistrarse_Click" CssClass="btn btn-primary" Text="Registrarse" ID="btnRegistrarse" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
