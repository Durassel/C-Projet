using System;

namespace Projet.chat
{
    public class ChatroomExistsException : Exception
    {
        public String chatroom;

        public ChatroomExistsException(String chatroom) : base("The chatroom \"" + chatroom + "\" already exists.")
        {
            this.chatroom = chatroom;
        }

        public override string Message
        {
            get { return "The chatroom \"" + chatroom + "\" already exists."; }
        }
    }
}
