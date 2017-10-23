using System;
using System.Collections.Generic;
using System.Text;

namespace Projet.authentification
{
    public class AuthentificationException : Exception
    {
        public String login;

        public AuthentificationException(String str)
        {
            this.login = str;
        }
    }
}
