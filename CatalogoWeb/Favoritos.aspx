<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="CatalogoWeb.Favoritos" %>

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


        <%if (!(ListaFavoritos is null))
            { %>
        <div class="row row-cols-1 row-cols-md-4 g-4">
            <% 
                foreach (Dominio.Articulo art in ListaFavoritos)
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
        </div>
              <%}%>

        <%}
            else
            {%>
        <h2 class="text-center">Comience a agregar favoritos!! :D</h2>
        <%} %>
    </div>
</asp:Content>

