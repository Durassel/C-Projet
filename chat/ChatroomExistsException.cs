using System;

namespace Projet.chat
{
    class ChatroomExistsException : Exception
    {
        public ChatroomExistsException() : base("Chatroom already exists.")
        {
            
        }
    }
}
