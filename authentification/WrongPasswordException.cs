using System;
using System.Collections.Generic;
using System.Text;

namespace Projet.authentification
{
    public class WrongPasswordException : AuthentificationException
    {
        public WrongPasswordException(String str) : base(str)
        {

        }
    }
}
