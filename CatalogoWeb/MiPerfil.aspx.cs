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

                try
                {
                    Usuario user = (Usuario)Session["Usuario"];

                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;
                    txtEmail.Text = user.Email;
                    txtEmail.ReadOnly = true;

                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    {
                        imgPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString(); ;
                    }

                }
                catch (Exception ex)
                {
                    Session.Add("Error", Seguridad.manejoDeError(ex));
                    Response.Redirect("Error.aspx", false);
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

                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                negocio.Actualizar(user);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/images/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                imgPerfil.ImageUrl = "~/images/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();


            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.manejoDeError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }
    }



}
