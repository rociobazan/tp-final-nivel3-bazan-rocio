<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="CatalogoWeb.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mt-4 mx-5">
        <div class="card-body">
            <div class="row">

                <div class="col-5">
                    <asp:Image ImageUrl="https://epichotelsanluis.com/wp-content/uploads/2022/11/placeholder-2.png" ID="imgDetalle" class="img-fluid" alt="Imagen del producto" runat="server" />
                </div>
                <div class="col-7">
                    <div class="d-flex justify-content-between align-items-center">
                        <h3 class="text-center d-inline">
                            <asp:Label Text="" ID="lblNombre" runat="server" />
                        </h3>
                        <asp:Button CssClass="d-inline" ID="btnFavorito" OnClick="btnFavorito_Click" Text="Favorito♡" runat="server" />
                    </div>

                    <hr />
                    <div class="row">
                        <div class="col">
                            <asp:Label Text="" ID="lblCategoria" runat="server" />
                            <asp:Label Text="" ID="lblMarca" runat="server" />
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-4">
                            <asp:Label Text="" ID="lblPrecio" runat="server" />
                        </div>
                    </div>
                    <asp:Label Text="text" ID="lblDescripción" runat="server" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
