using System;

namespace Projet.authentification
{
    public class WrongPasswordException : AuthentificationException
    {
        public WrongPasswordException(String str) : base(str)
        {

        }
    }
}
