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
    public partial class FormularioArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack) //sólo ejecutar si no es postback
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marca> marcas = marcaNegocio.listar(); //trae lista de marcas desde DB
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Categoria> categorias = categoriaNegocio.listar(); //trae lista de categorías desde DB

                    ddlMarca.DataSource = marcas;
                    ddlMarca.DataValueField = "id";  //valor que capturo
                    ddlMarca.DataTextField = "Descripcion"; //Texto que muestro
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = categorias;
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void txtImageUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImageUrl.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                nuevo.Codigo= txtCodigo.Text;
                nuevo.Nombre= txtNombre.Text;
                nuevo.Descripcion= txtDescripcion.Text;
                nuevo.Precio = Decimal.Parse(txtPrecio.Text);
                nuevo.ImagenUrl = txtImageUrl.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                negocio.agregar(nuevo);
                Response.Redirect("ListadoArticulos.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}