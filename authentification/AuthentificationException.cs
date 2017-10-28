using System;

namespace Projet.authentification
{
    public class AuthentificationException : Exception
    {
        public String alias;

        public AuthentificationException(String str)
        {
            this.alias = str;
        }
    }
}
