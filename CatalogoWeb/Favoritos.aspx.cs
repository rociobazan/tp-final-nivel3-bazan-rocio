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
    public partial class Favoritos : System.Web.UI.Page

    {
        public List<Articulo> ListaFavoritos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FavoritoNegocio negocio = new FavoritoNegocio();
            
            try
            {
                if (!(Session["Usuario"] is null))
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    int IdUser = usuario.Id;
                    List<int> listaIdFavoritos = new List<int>();
                    listaIdFavoritos = negocio.listarFavorito(IdUser);


                    if (listaIdFavoritos.Count > 0)
                    {
                        ArticuloNegocio artNegocio = new ArticuloNegocio();
                        ListaFavoritos = artNegocio.listarConListaIds(listaIdFavoritos);
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }

                
            }
            catch (Exception ex)
            {

                Session.Add("Error", Seguridad.manejoDeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }

        
    }
}