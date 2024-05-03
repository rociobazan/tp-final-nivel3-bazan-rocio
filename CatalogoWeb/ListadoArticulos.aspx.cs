using Dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			ArticuloNegocio negocio = new ArticuloNegocio();
			try
			{
				dgvArticulos.DataSource = negocio.listar();
				dgvArticulos.DataBind();

				
			}
			catch (Exception)
			{

				throw;
			}
        }

        protected void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
			Response.Redirect("FormularioArticulos.aspx", false);
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulos.aspx?id=" + id);
        }
    }
}