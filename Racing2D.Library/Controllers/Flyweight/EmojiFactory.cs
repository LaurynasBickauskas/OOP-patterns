using System.Collections.Generic;

namespace Racing2D.Library
{
    class EmojiFactory
    {
        private static readonly Dictionary<string, Emoji> EmojiList = new Dictionary<string, Emoji>();

        public static Emoji GetEmoji(string text)
        {
            Emoji emoji;
            if (EmojiList.ContainsKey(text))
            {
                emoji = EmojiList[text];
            } else
            {
                emoji = new Emoji(text);
                EmojiList[text] = emoji;
            }
            return emoji;
        }
    }
}
