using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using negocio;


namespace CatalogoWeb
{
    public partial class Default : System.Web.UI.Page
    {

        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                ListaArticulos = negocio.listar();

            }
            catch (Exception ex)
            {
                Session.Add("Error",Seguridad.manejoDeError(ex));
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulos = negocio.filtrar("Nombre", "contiene", txtSearch.Text);
            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.manejoDeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            Response.Redirect("Detalles.aspx", false);
        }
    }
       
}