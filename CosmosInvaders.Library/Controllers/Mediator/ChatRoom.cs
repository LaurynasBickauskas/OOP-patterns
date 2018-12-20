using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosInvaders.Library
{
    class ChatRoom
    {
        public static Tuple<string, string> ShowMessage(Ship ship, string message)
        {      
                string userMessage = DateTime.Now.ToString("HH:mm:ss") + " [" + ship.PlayerName + "]: " + message + " ";
                return Tuple.Create(userMessage, "");

        }
    }
}
