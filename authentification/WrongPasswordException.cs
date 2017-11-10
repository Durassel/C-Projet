using System;

namespace Projet.authentification
{
    public class WrongPasswordException : AuthentificationException
    {
        public WrongPasswordException(String alias) : base(alias)
        {

        }

        public override string Message
        {
            get { return "Wrong password."; }
        }
    }
}
