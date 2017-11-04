using Projet.authentification;
using Projet.chat;
using Projet.net;
using System;
using static Projet.net.Message;

namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Step 1
            Console.WriteLine("STEP 1 : Chat package" + Environment.NewLine);
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
            Console.Read();

            // Step 2 
            Console.WriteLine(Environment.NewLine + "STEP 2 : Authentification package" + Environment.NewLine);
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
                Console.WriteLine(e.alias + " : user unknown (enable to remove) !");
            } catch (UserExistsException e) {
                Console.WriteLine(e.alias + " has already been added !");
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
                Console.WriteLine(e.alias + " has provided an invalid password !");
            } catch (UserExistsException e) {
                Console.WriteLine(e.alias + " has already been added !");
            } catch (UserUnknownException e) {
                Console.WriteLine(e.alias + " : user unknown (enable to remove) !");
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
                Console.WriteLine(e.alias + " is unknown ! error during the saving/loading.");
            } catch (WrongPasswordException e) {
                Console.WriteLine(e.alias + " has provided an invalid password ! error during the saving/loading.");
            } catch (System.IO.IOException e) {
                Console.WriteLine(e);
            }
            Console.Read();
            */
        }
    }
}
