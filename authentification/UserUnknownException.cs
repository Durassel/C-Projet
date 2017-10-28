using System;

namespace Projet.authentification
{
    public class UserUnknownException : AuthentificationException
    {
        public UserUnknownException(String str) : base(str)
        {

        }
    }
}
