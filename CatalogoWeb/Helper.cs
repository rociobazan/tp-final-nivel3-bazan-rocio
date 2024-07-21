using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web;

namespace CatalogoWeb
{
    static public class Helper
    {
        static public bool validaUserPass(string user, string pass)
        {
           
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                return false;
            }

            string expresion = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool validaUser = Regex.IsMatch(user, expresion);

            bool validaPass = !string.IsNullOrWhiteSpace(pass);

            return validaUser && validaPass;
        }

        static public bool validaTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return false;
            else
                return true;
            
        }

        static public bool validaFormulario(string codigo, string nombre, string desc, string precio)
        {
            string expresion = @"^[0-9]+([.,][0-9]+)?$";
            


            if (String.IsNullOrWhiteSpace(codigo) || String.IsNullOrWhiteSpace(nombre) || String.IsNullOrWhiteSpace(desc) || String.IsNullOrWhiteSpace(precio.ToString()))
                return false;
            else if(!Regex.IsMatch(precio, expresion))
                return false;
            else
                return true;
            
                
            
        }

    }
}