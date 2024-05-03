<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="CatalogoWeb.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />

    <div class="row  mt-3 m-lg-2">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtId" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtCodigo" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtNombre" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtDescripcion" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox CssClass="form-control" runat="server" ID="txtPrecio" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlMarca"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" runat="server" />
                <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-outline-primary" runat="server" />
            </div>

        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtCategoria" class="form-label">Categoría</label>
                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlCategoria"></asp:DropDownList>
            </div>
            <asp:UpdatePanel ID="updatePanelImg" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImageUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImageUrl" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImageUrl_TextChanged" />
                    </div>
                    <asp:Image runat="server" ID="imgArticulo" Width="60%" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAYVR7U3jGi8bNBfG5r-KWa1EpornYP69SAzV4Mid4ihf7_M6ysMHnDGqoTEdRzUyUJqg&usqp=CAU" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="row mt-3 m-lg-2"">
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                        <% if (confirmaEliminar)
                            {%>
                        <asp:CheckBox Id="cbxEliminar" Text="Estoy seguro que quiero eliminar el artículo" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnEliminarPermanente" OnClick="btnEliminarPermanente_Click" CssClass="btn btn-outline-danger" runat="server" />
                        <%} %>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
