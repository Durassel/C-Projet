using Projet.chat;
using System;
using static Projet.net.Message;

namespace projet.client
{
    public delegate void receiveDel(Object sender, EventArgs e, String message, Chatter c, Header h);

    public class Transmittor
    {
        private static event receiveDel multiReceive;

        protected virtual void onMyDel(object sender, EventArgs e, String message, Chatter c, Header h)
        {
            if (multiReceive != null) { // check for suscribers
                multiReceive(sender, e, message, c, h);
            }
        }

        public void raiseEvent(String message, Chatter c, Header h)
        {
            onMyDel(this, EventArgs.Empty, message, c, h);
        }        public void raiseEvent(Chatter c, Header h)
        {
            onMyDel(this, EventArgs.Empty, null, c, h);
        }
        public void AddReceiveDel(receiveDel recDel)
        {
            multiReceive += recDel;
        }

        public void RemoveReceiveDel(receiveDel recDel)
        {
            multiReceive -= recDel;
        }
    }

}