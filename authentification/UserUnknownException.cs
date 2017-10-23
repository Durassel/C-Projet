using System;
using System.Collections.Generic;
using System.Text;

namespace Projet.authentification
{
    public class UserUnknownException : AuthentificationException
    {
        public UserUnknownException(String str) : base(str)
        {

        }
    }
}
