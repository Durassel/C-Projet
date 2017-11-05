using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Projet.authentification
{
    [Serializable]
    public class Authentification : AuthentificationManager
    {
        private Dictionary<String, User> users;

        public Authentification()
        {
            // Load users from file
            try {
                this.load("C:\\Users\\Frédéric\\Desktop\\EFREI\\2017-2018\\Semestre 1\\C#\\Project\\Projet\\Projet\\bin\\Debug\\users.txt");
            } catch (System.IO.IOException e) { // If an error occured, declaration of an empty users array
                Console.WriteLine(e);
                users = new Dictionary<string, User>();
            }
        }

        public void addUser(String login, String password)
        {
            // Check if this user doesn't exist
            if (!users.ContainsKey(login)) {
                users[login] = new User(login, password);
            } else {
                throw new UserExistsException(login);
            }
	    }

        public void removeUser(String login)
        {
            // Check if the user exists
            if (!users.ContainsKey(login)) {
                throw new UserUnknownException(login);
            }
            users.Remove(login);
        }

        public void authentify(String login, String password)
        {
            // Check if the user exists
            if (!users.ContainsKey(login)) {
                throw new UserUnknownException(login);
            }
            // Check if the password is correct
            if (users[login].Password.CompareTo(password) != 0) {
                throw new WrongPasswordException(login);
            }
        }

        public AuthentificationManager load(String path)
        {
            try { // Deserialization of users (cast the stream from file)
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
            try { // Serialization of users
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
