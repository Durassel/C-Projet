using Projet.authentification;
using Projet.chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Step 1
            // Chatters
            Chatter bob = new TextChatter("Bob");
            Chatter joe = new TextChatter("Joe");

            // Topics
            TopicsManager gt = new TextTopicsManager();
            gt.createTopic("java");
            gt.createTopic("UML");
            gt.listTopics();
            gt.createTopic("jeux");
            gt.listTopics();

            // Chatroom
            Chatroom cr = gt.joinTopic("jeux");
            cr.join(bob);
            cr.post("Je suis seul ou quoi ?", bob);
            cr.join(joe);
            cr.post("Tiens, salut Joe !", bob);
            cr.post("Toi aussi tu chat sur les forums de jeux pendant les TP, Bob ? ",joe);
            */

            /* Step 2 */
            AuthentificationManager am = new Authentification();
            // users management
            try
            {
                am.addUser("bob", "123");
                Console.WriteLine("Bob has been added !");
                am.removeUser("bob");
                Console.WriteLine("Bob has been removed !");
                am.removeUser("bob");
                Console.WriteLine("Bob has been removes twice !");
            } catch (UserUnknownException e) {
                Console.WriteLine(e.login + " : user unknown (enable to remove) !");
            } catch (UserExistsException e) {
                Console.WriteLine(e.login + " has already been added !");
            }

            // authentification
            try
            {
                am.addUser("bob", "123");
                Console.WriteLine("Bob has been added !");
                am.authentify("bob", "123");
                Console.WriteLine("Authentification OK !");
                am.authentify("bob", "456");
                Console.WriteLine("Invalid password !");
            } catch (WrongPasswordException e) {
                Console.WriteLine(e.login + " has provided an invalid password !");
            } catch (UserExistsException e) {
                Console.WriteLine(e.login + " has already been added !");
            } catch (UserUnknownException e) {
                Console.WriteLine(e.login + " : user unknown (enable to remove) !");
            }

            // persistance
            try
            {
                am.save("users.txt");
                AuthentificationManager am1 = new Authentification();
                am1.load("users.txt");
                am1.authentify("bob", "123");
                Console.WriteLine("Loading complete !");
            } catch (UserUnknownException e) {
                Console.WriteLine(e.login + " is unknown ! error during the saving/loading.");
            } catch (WrongPasswordException e) {
                Console.WriteLine(e.login + " has provided an invalid password ! error during the saving/loading.");
            } catch (System.IO.IOException e) {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}
