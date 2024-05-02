<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogoWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Catálogo</h1>
    <p> Holisss</p>
    <br />
    
    <%--<hr />--%>

    <div class="row row-cols-1 row-cols-md-4 g-4" style="padding-left:2em; padding-right:2em;">
        <% 
            foreach (Dominio.Articulo art in ListaArticulos)
            {
        %>
        <div class="col">
            <div class="card" style="width: 18rem; overflow:hidden;">
                <img src="<%:art.ImagenUrl %>" style="height:18rem; object-fit:cover" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%:art.Nombre %></h5>
                    <h6><%:art.Precio %></h6>
                    <p class="card-text"><%:art.Descripcion %></p>
                    <a href="#" class="btn btn-primary">Ver detalles</a>
                </div>
            </div>
        </div>

        <% }%>
    </div>
</asp:Content>
