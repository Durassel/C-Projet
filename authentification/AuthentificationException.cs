using System;

namespace Projet.authentification
{
    public class AuthentificationException : Exception
    {
        public String alias;

        public AuthentificationException(String alias)
        {
            this.alias = alias;
        }
    }
}
