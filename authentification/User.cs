using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projet.authentification
{
    [Serializable]
    public class User
    {
        private static long serialVersionUID = 2;
        private String login;
        private String password;

        public User(String login, String password) : base()
        {
            this.login = login;
            this.password = password;
        }

        public String Login
        {
            get
            {
                return this.login;
            }
            set
            {
                this.login = value;
            }
        }

        public String Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }
    }
}
