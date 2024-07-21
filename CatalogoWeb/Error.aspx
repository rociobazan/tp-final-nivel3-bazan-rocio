<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="CatalogoWeb.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex justify-content-center align-items-center vh-100">
        <div class="text-center">
            <div class="card border-0 shadow">
                <div class="card-body">
                    <div class="mb-3 fw-semibold fs-4">
                        <asp:Label Text="Algo salió mal!" runat="server" />
                    </div>
                    <div class="mb-3 fs-5">
                        <asp:Label Text="text" ID="lblError" runat="server" />
                    </div>
                    <div class="mb-3">
                        <a href="Default.aspx" class="btn btn-primary">Volver</a>                        
                    </div>

                </div>
            </div>
        </div>
    </div>
    


</asp:Content>
