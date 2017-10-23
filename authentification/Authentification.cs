using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Projet.authentification
{
    [Serializable]
    class Authentification : AuthentificationManager
    {
        private Dictionary<String, User> users;

        public Authentification()
        {
            try {
                this.load("users.txt");
                Console.WriteLine("Loading is done");
            } catch (System.IO.IOException e) {
                Console.WriteLine(e);
                users = new Dictionary<string, User>();
            }
        }

        public void addUser(String login, String password)
        {
            if (users.ContainsKey(login))
                throw new UserExistsException(login);
            else
                users[login] = new User(login, password);		
	    }

        public void removeUser(String login)
        {
            if (!users.ContainsKey(login))
                throw new UserUnknownException(login);
            users.Remove(login);
        }

        public void authentify(String login, String password)
        {
		    if(!users.ContainsKey(login))
                throw new UserUnknownException(login);	

		    if(users[login].Password.CompareTo(password) != 0)
                throw new WrongPasswordException(login);
        }

        public AuthentificationManager load(String path)
        {
            try {
                FileStream input = new FileStream(path, FileMode.Open);
                BinaryFormatter binaryf = new BinaryFormatter();
                users = (Dictionary<String, User>) binaryf.Deserialize(input);
                input.Close();
            } catch (System.TypeLoadException e) {
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public void save(String path)
        {
            try {
                FileStream output = new FileStream(path, FileMode.Create);
                BinaryFormatter binaryf = new BinaryFormatter();
                binaryf.Serialize(output, users);
                output.Close();
            } catch (System.IO.IOException e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
