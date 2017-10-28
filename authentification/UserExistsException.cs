using System;

namespace Projet.authentification
{
    public class UserExistsException : AuthentificationException
    {
        public UserExistsException(String str) : base(str)
        {
            
        }
    }
}
