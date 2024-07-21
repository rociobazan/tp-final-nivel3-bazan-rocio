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
    public partial class Site1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuoiVnnWu_QbtFist_W7Hbz2V4drhwXDVyiw&s";

            if (!(Page is Registro || Page is Default || Page is Login || Page is Error || Page is Detalles))
            {
                if (Seguridad.sesionActiva(Session["Usuario"]))
                  cargarBanner();
                else
                    Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (Seguridad.sesionActiva(Session["Usuario"]))
                   cargarBanner();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx", false);
        }

        protected void lblUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }

        protected void cargarBanner()
        {
            Usuario user = (Usuario)Session["Usuario"];
            lblUser.Text = user.Nombre;

            if (!string.IsNullOrEmpty(user.ImagenPerfil))
                imgAvatar.ImageUrl = "~Images/" + user.ImagenPerfil;
        }
    }
}