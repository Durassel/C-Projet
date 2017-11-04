using System;

namespace Projet.chat
{
    class ChatroomExistsException : Exception
    {
        public ChatroomExistsException() : base("This chatroom already exists.")
        {
            
        }
    }
}
