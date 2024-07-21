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

                    if (!Seguridad.sesionActiva(Session["Usuario"]))
                    {
                        Response.Redirect("Login.aspx", false);
                        return;
                    }

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
                Page.Validate();
                if (!Page.IsValid)
                    return;

                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario user = (Usuario)Session["Usuario"];

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                if(!Helper.validaTexto(user.Nombre) || !Helper.validaTexto(user.Apellido))
                {
                    Session.Add("Error", "Los campos nombre y apellido no pueden estar vacíos.Ingrese un nombre y apellido válidos.");
                    Response.Redirect("Error.aspx", false);
                    return;
                }

                if (txtImagenPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";

                }

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
