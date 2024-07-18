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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {

                //Si están ok las validaciones del front sigue, sino no
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;

                //Si el email es válido y la contra también, lo registra. Sino pantalla de error.
                if (Helper.validaUserPass(user.Email, user.Pass))
                {
                    user.Id = negocio.insertarNuevo(user);
                    Session.Add("Usuario", user);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Ingrese un email y una contraseña válidos");
                    Response.Redirect("Error.aspx", false);
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