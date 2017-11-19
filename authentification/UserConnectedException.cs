using System;

namespace Projet.authentification
{
    public class UserConnectedException : AuthentificationException
    {
        public UserConnectedException(String alias) : base(alias)
        {

        }

        public override string Message
        {
            get { return alias + " is already connected."; }
        }
    }
}