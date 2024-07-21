using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace CatalogoWeb
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            

            // Agregar ScriptResourceMapping para jQuery
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-3.6.0.min.js", // Ajusta la ruta según la ubicación de tu archivo jQuery
                DebugPath = "~/scripts/jquery-3.6.0.js",
                CdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.6.0.min.js",
                CdnDebugPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.6.0.js"
            });
        }
        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            Session.Add("Error", exc.Message);
            Response.Redirect("Error.aspx", false);
        }
    }
}