using System;

namespace Projet.authentification
{
    public class UserExistsException : AuthentificationException
    {
        public UserExistsException(String alias) : base(alias)
        {
            
        }
    }
}
