using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Web.UI.WebControls.WebParts;

namespace CatalogoWeb
{
    public partial class Detalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            try
            {   //Capturo el id del producto, sino vacío
                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
               //Si efectivament tengo un id y no es postback cargo los detalles del prod
                if (id != "" && !IsPostBack)
                {

                    Articulo seleccionado = artNegocio.listar(id)[0];

                    imgDetalle.ImageUrl = seleccionado.ImagenUrl;

                    lblNombre.Text = seleccionado.Nombre;
                    lblMarca.Text = seleccionado.Marca.ToString();
                    lblCategoria.Text = seleccionado.Categoria.ToString();
                    lblPrecio.Text = seleccionado.Precio.ToString();
                    lblDescripción.Text = seleccionado.Descripcion.ToString();
                }
                if (Seguridad.sesionActiva(Session["Usuario"]))
                {
                    int idUser = ((Usuario)Session["Usuario"]).Id;
                    if (EsFavorito(id, idUser))
                    {
                        btnFavorito.Text = "Quitar fav ❤";
                    }
                    else
                    {
                        btnFavorito.Text = "Agregar fav ♡";
                    }
                }

                

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            string idArt = Request.QueryString["Id"];
            Usuario usuario = (Usuario)Session["Usuario"];

            if (Seguridad.sesionActiva(Session["Usuario"]))
            {
                int idUser = usuario.Id;
                FavoritoNegocio negocio = new FavoritoNegocio();
                

                if (Seguridad.sesionActiva(Session["Usuario"]))
                {
                    if (EsFavorito(idArt, idUser))
                    {
                        negocio.eliminarFavorito(idArt, idUser);
                        
                    }
                    else
                    {
                        negocio.agregarFavorito(idUser, idArt);
                    }
                }

            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }

        }

        public bool EsFavorito(string idArt, int idUser)
        {
            int idArticulo = int.Parse(idArt);
            FavoritoNegocio negocio = new FavoritoNegocio();
            List <int>listaIdFavoritos = negocio.listarFavorito(idUser);

            foreach (var id in listaIdFavoritos)
            {
                if (id == idArticulo) 
                {
                    return true;
                }

            }

            return false;
        }

    }
}