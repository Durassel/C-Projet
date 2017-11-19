using System;

namespace Projet.authentification
{
    [Serializable]
    public class User
    {
        private String login;
        private String password;
        private Boolean connected;

        public User(String login, String password) : base()
        {
            this.login = login;
            this.password = password;
            this.connected = false;
        }

        public String Login
        {
            get { return login; }
            set { login = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public Boolean Connected
        {
            get { return connected; }
            set { connected = value; }
        }

        public override string ToString()
        {
            return "Login : " + login + " / password : " + password + " / connected : " + connected;
        }
    }
}
