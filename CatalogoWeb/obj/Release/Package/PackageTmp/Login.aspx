<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CatalogoWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            display: block;
            margin-top: 0.25rem;
            color: red;
            font-size: 0.875rem;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 pt-5">
        <div class="row">
            <div class="col-12 col-sm-7 col-md-6 m-auto">
                <div class="card border-0 shadow">
                    <div class="card-body">
                        <div class="text-center">
                            <svg class="bi bi-person-circle" xmlns="http://www.w3.org/2000/svg" width="50" height="50" fill="currentColor" viewBox="0 0 16 16">
                                <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0" />
                                <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8m8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1" />
                            </svg>
                        </div>
                        <div class="my-2 py-1">
                            <asp:TextBox CssClass="form-control" ClientIDMode="Static" ID="txtUsuario" runat="server" placeholder="Usuario" />
                            <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Ingrese un email válido" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ControlToValidate="txtUsuario" runat="server" />
                        </div>
                        <div class="my-2 py-1">
                            <asp:TextBox CssClass="form-control" ClientIDMode="Static" ID="txtContraseña" runat="server" placeholder="Contraseña" TextMode="Password" />
                            <asp:RequiredFieldValidator ErrorMessage="La contraseña no puede estar vacía" CssClass="validacion" ControlToValidate="txtContraseña" runat="server" />
                        </div>
                        <div class="text-center">
                            <asp:Button CssClass="btn btn-primary" OnClick="btnLogin_Click" Text="Login" ID="btnLogin" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
