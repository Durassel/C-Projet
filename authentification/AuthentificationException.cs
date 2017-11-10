using System;

namespace Projet.authentification
{
    public class AuthentificationException : Exception
    {
        public String alias;

        public AuthentificationException(String alias) : base(alias)
        {
            this.alias = alias;
        }

        public String titleError()
        {
            return string.Format("Error");
        }
    }
}
