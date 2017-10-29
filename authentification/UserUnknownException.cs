using System;

namespace Projet.authentification
{
    public class UserUnknownException : AuthentificationException
    {
        public UserUnknownException(String alias) : base(alias)
        {

        }
    }
}
