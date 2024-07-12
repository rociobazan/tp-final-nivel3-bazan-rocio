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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.sesionActiva(Session["Usuario"]))
                {
                    try
                    {
                        Usuario user = (Usuario)Session["Usuario"];

                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtEmail.Text = user.Email;

                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        {
                            imgPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                        }

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario user = (Usuario)Session["Usuario"];

                if (txtImagenPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                    imgPerfil.ImageUrl = user.ImagenPerfil;
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                negocio.Actualizar(user);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/images/" + user.ImagenPerfil;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }


   
}
