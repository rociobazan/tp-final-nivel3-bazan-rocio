<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="CatalogoWeb.ListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row m-3">
        <div class="col-7">
            <div class="d-flex mb-3">
                <asp:TextBox CssClass="form-control me-2" type="search" OnTextChanged="txtSearch_TextChanged" ID="txtSearch" placeholder="Search" aria-label="Search" runat="server" />
                <asp:Button OnClick="btnLimpiar_Click" CssClass="btn btn-outline-info" ID="btnLimpiar" Text="Limpiar" runat="server" />
            </div>
            <div>
                <asp:CheckBox ID="cbxFiltro" AutoPostBack="true" OnCheckedChanged="cbxFiltro_CheckedChanged" Text="Filtro Avanzado" runat="server" />
            </div>
        </div>
        <div class="col-5">
            <div class="mb-3">
                <asp:Button ID="btnAgregarNuevo" OnClick="btnAgregarNuevo_Click" Text="Agregar nuevo" CssClass="btn btn-success" runat="server" />
            </div>
        </div>
    </div>
    <%if (cbxFiltro.Checked)
        { %>
    <div class="row m-3"">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" runat="server" />
                <asp:DropDownList ID="ddlCampo"  CssClass="form-control" runat="server">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Contiene" />
                    <asp:ListItem Text="Termina con" />
                    <asp:ListItem Text="Comienza con" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" />
                <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server" />
            </div>
        </div>
    </div>
    <div class="row m-3"">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" runat="server" />
            </div>
        </div>
    </div>
    <% }%>


    <asp:GridView runat="server" ID="dgvArticulos" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" CssClass="table table-borderer table-hover" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Administrar" />
        </Columns>
    </asp:GridView>
</asp:Content>
