using System;
using System.Collections.Generic;
using System.Text;

namespace Projet.authentification
{
    public class UserExistsException : AuthentificationException
    {
        public UserExistsException(String str) : base(str)
        {
            
        }
    }
}
