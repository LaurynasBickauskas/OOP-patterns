using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosInvaders.Library
{
    class ChatRoom
    {
        public static Tuple<string, string> ShowMessage(Vehicle vehicle, string message)
        {
            string emojiChars = message.Substring(message.Length - 2);
            if(emojiChars == ":)" || emojiChars == ":D" || emojiChars == ":(" || emojiChars == ";(")
            {
                string userMessage = DateTime.Now.ToString("HH:mm:ss") + " [" + vehicle.PlayerName + "]: " + message.Substring(0, message.Length - 2) + " ";
                Emoji emoji = EmojiFactory.GetEmoji(emojiChars);
                return Tuple.Create(userMessage, emoji.GetEmoji());
            } else
            {
                string userMessage = DateTime.Now.ToString("HH:mm:ss") + " [" + vehicle.PlayerName + "]: " + message + " ";
                return Tuple.Create(userMessage, "");
            }
        }
    }
}
