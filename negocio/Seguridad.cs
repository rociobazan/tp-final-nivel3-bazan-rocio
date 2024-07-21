using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;

            if(usuario != null && usuario.Id != 0)
                return true;
            else 
                return false;
        }

        public static bool esAdmin(Object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            return usuario != null ? usuario.Admin : false;
        }

        public static string manejoDeError(Exception error)
        {
            return error.Message;
        }
    }
}
