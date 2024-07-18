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

        

    }
}