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
            } catch (IOException e) { // If an error occured, declaration of an empty users array
                Console.WriteLine(e);
                users = new Dictionary<String, User>();
            }
        }

        public void addUser(String login, String password)
        {
            // Check if this user doesn't exist
            if (!users.ContainsKey(login)) {
                users[login] = new User(login, password);
                save("C:\\Users\\Frédéric\\Desktop\\EFREI\\2017-2018\\Semestre 1\\C#\\Project\\Projet\\Projet\\bin\\Debug\\users.txt");
            } else {
                throw new UserExistsException(login);
            }
	    }

        public void updateUser(String login, Boolean connected)
        {
            if (users.ContainsKey(login)) {
                users[login].Connected = connected;
                save("C:\\Users\\Frédéric\\Desktop\\EFREI\\2017-2018\\Semestre 1\\C#\\Project\\Projet\\Projet\\bin\\Debug\\users.txt");
            } else {
                throw new UserUnknownException(login);
            }
        }

        public void removeUser(String login)
        {
            // Check if the user exists
            if (users.ContainsKey(login)) {
                users.Remove(login);
                save("C:\\Users\\Frédéric\\Desktop\\EFREI\\2017-2018\\Semestre 1\\C#\\Project\\Projet\\Projet\\bin\\Debug\\users.txt");
            } else {
                throw new UserUnknownException(login);
            }
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
            // Check if the user isn't already connected
            if (users[login].Connected == true) {
                throw new UserConnectedException(login);
            }
            users[login].Connected = true; // Connect the user if any exception has thrown
            this.save("C:\\Users\\Frédéric\\Desktop\\EFREI\\2017-2018\\Semestre 1\\C#\\Project\\Projet\\Projet\\bin\\Debug\\users.txt");
        }

        public AuthentificationManager load(String path)
        {
            // Deserialization of users (cast the stream from file)
            FileStream input = new FileStream(path, FileMode.Open);
            BinaryFormatter binaryf = new BinaryFormatter();
            users = (Dictionary<String, User>) binaryf.Deserialize(input);
            input.Close();
            return null;
        }

        public void save(String path)
        {
            // Serialization of users
            FileStream output = new FileStream(path, FileMode.Create);
            BinaryFormatter binaryf = new BinaryFormatter();
            binaryf.Serialize(output, users);
            output.Close();
        }
    }
}
