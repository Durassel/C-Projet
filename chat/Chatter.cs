using System;
using System.Collections.Generic;
using System.Text;

namespace Projet.chat
{
    interface Chatter
    {
        void receiveAMessage(String msg, Chatter c);

        string getAlias();
    }
}
