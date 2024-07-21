<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="CatalogoWeb.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img-small {
            max-width: 150px; /* Ajusta este valor según tus necesidades */
            height: auto; /* Mantiene la proporción de la imagen */
        }

        .validacion {
            display: block;
            margin-top: 0.25rem;
            color: red;
            font-size: 0.875rem;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mt-3 m-lg-1">
        <h3>Mi perfil</h3>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre no puede estar vacío" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El apellido no puede estar vacío" ControlToValidate="txtApellido" runat="server" />
            </div>
            <div class="col-md-4">
                <asp:Button OnClick="btnGuardar_Click" ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar" runat="server" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="mb-3">
                <label class="form-label">Imagen de perfil</label>
                <input type="file" id="txtImagenPerfil" class="form-control" runat="server" />
            </div>
            <asp:Image ID="imgPerfil" CssClass="img-fluid mb-3" ImageUrl="https://www.cronobierzo.es/wp-content/uploads/2020/01/no-image.jpg" runat="server" />
        </div>
    </div>
    
</asp:Content>
