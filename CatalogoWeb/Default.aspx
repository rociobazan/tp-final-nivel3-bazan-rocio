<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogoWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card:hover {
            transform: scale(1.05);
            transition: transform 0.3s;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <div class="container mt-3">
        <div class="row mb-3">
            <div class="col-12 col-md-9 col-lg-8">
                <div class="d-flex">
                    <asp:TextBox CssClass="form-control me-2" type="search" ID="txtSearch" placeholder="Buscar" runat="server" />
                    <asp:Button OnClick="btnBuscar_Click" CssClass="btn btn-primary" ID="btnBuscar" Text="Buscar" runat="server" />
                </div>
            </div>
        </div>

        <div class="row row-cols-1 row-cols-md-4 g-4">
            <% 
                foreach (Dominio.Articulo art in ListaArticulos)
                {
            %>
            <div class="col">
                <div class="card h-100" style="overflow: hidden;">
                    <img src="<%:art.ImagenUrl %>" style="height: 18rem; object-fit: cover" class="card-img-top img-fluid" alt="imagen del producto">
                    <div class="card-body">
                        <h5 class="card-title"><%:art.Nombre %></h5>
                        <h6><%:art.Precio %></h6>
                        <p class="card-text"><%:art.Descripcion %></p>
                        <div class="row">
                            <div class="col">
                                <a href="Detalles.aspx?Id=<%:art.Id%>" class="btn btn-sm btn-outline-dark">Ver detalles</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%}%>
        </div>
    </div>
</asp:Content>
