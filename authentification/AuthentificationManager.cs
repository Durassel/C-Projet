using System;

namespace Projet.authentification
{
    public interface AuthentificationManager
    {
        void addUser(String login, String password);
        void updateUser(String login, Boolean connected);
        void removeUser(String login);
        void authentify(String login, String password);
        AuthentificationManager load(String path);
        void save(String path);
    }
}
