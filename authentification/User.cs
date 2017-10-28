using System;

namespace Projet.authentification
{
    [Serializable]
    public class User
    {
        private String login;
        private String password;

        public User(String login, String password) : base()
        {
            this.login = login;
            this.password = password;
        }

        public String Login
        {
            get { return this.login; }
            set { this.login = value; }
        }

        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
    }
}
