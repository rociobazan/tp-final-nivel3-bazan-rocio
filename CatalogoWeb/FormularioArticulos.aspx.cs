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
        public bool confirmaEliminar {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtId.Enabled = false;
                confirmaEliminar = false;
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

                //Si vamos a modificar el art.
                string id = Request.QueryString["Id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack) //si tengo un id y no es postback.
                {
                    
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    List<Articulo> listaArticulos = negocio.listar(id);
                    Articulo seleccionado = listaArticulos[0]; //Siempre va a ser la posición 0 porque sólo trae un obj.

                    //Precargo los campos
                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtImageUrl.Text = seleccionado.ImagenUrl;

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                    txtImageUrl_TextChanged(sender, e);
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

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);
                }

                
                Response.Redirect("ListadoArticulos.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoArticulos.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminar = true;
        }

        protected void btnEliminarPermanente_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (cbxEliminar.Checked)
            {
                negocio.eliminar(int.Parse(txtId.Text));
                Response.Redirect("ListadoArticulos.aspx", false);
            }
        }
    }
}