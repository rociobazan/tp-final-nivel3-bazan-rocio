<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="CatalogoWeb.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    function handleImageError(img) {
        img.onerror = null;
        img.src = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSDyBdayoG4JDHSMsTQma1TmHHXu0L5Dtt37NDtHVHK1r-wk_40PzMtynJd9g5SL_n6ekE&usqp=CAU';
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card mt-4 mx-5">
        <div class="card-body">
            <div class="row">

                <div class="col-5">
                    <asp:Image ImageUrl="" onerror="handleImageError(this)" ID="imgDetalle" class="img-fluid" alt="Imagen del producto" runat="server" />
                </div>
                <div class="col-5 mx-auto">
                    <div class="d-flex justify-content-between align-items-center">
                        <h3 class="text-center d-inline">
                            <asp:Label Text="" ID="lblNombre" runat="server" />
                        </h3>
                    </div>

                    <hr />
                    <div class="row mb-3">
                        <div class="col">
                            <asp:Label Text="" ID="lblCategoria" CssClass="badge bg-secondary rounded-pill" runat="server" />
                            <asp:Label Text="" ID="lblMarca" CssClass="badge bg-secondary rounded-pill " runat="server" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-6">
                            <asp:Label Text="" ID="lblPrecio" CssClass="fs-2" runat="server" />
                        </div>
                    </div>
                    <div class="row mb-3">
                        <asp:Label Text="text" ID="lblDescripción" runat="server" />
                    </div>
                    <div class="row mb-3">
                        <div class="col-12 d-flex justify-content-between">
                            <asp:Button CssClass="btn btn-primary w-100 me-2" ID="btnFavorito" OnClick="btnFavorito_Click" Text="Favorito♡" runat="server" />
                            <asp:Button CssClass="btn btn-secondary w-100 ms-2" ID="btnVolver" OnClick="btnVolver_Click" Text="Volver" runat="server" />
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
