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
    public partial class detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                user.Email = txtUsuario.Text;
                user.Pass = txtContraseña.Text;

                if (negocio.Login(user))
                {
                    Session.Add("Usuario", user);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("Error", "User o pass incorrectos");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex) 
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}