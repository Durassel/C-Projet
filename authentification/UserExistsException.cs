using System;

namespace Projet.authentification
{
    public class UserExistsException : AuthentificationException
    {
        public UserExistsException(String alias) : base(alias)
        {

        }

        public override string Message
        {
            get { return alias + " already exists."; }
        }
    }
}
