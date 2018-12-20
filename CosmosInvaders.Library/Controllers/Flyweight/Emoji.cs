using System;
using System.IO;
using System.Reflection;

namespace Racing2D.Library
{
    class Emoji : IEmoji
    {
        string EmojiRTF;

        public Emoji(string text)
        {
            switch (text)
            {
                case ":D":
                    string fileName = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                    string filePath = fileName.Substring(0, fileName.Length - 25);
                    this.EmojiRTF = System.IO.File.ReadAllText(filePath + @"\Emoji\Laugh.txt");
                    break;
                case ":)":
                    fileName = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                    filePath = fileName.Substring(0, fileName.Length - 25);
                    this.EmojiRTF = System.IO.File.ReadAllText(filePath + @"\Emoji\Smile.txt");
                    break;
                case ":(":
                    fileName = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                    filePath = fileName.Substring(0, fileName.Length - 25);
                    this.EmojiRTF = System.IO.File.ReadAllText(filePath + @"\Emoji\Sad.txt");
                    break;
                case ";(":
                    fileName = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                    filePath = fileName.Substring(0, fileName.Length - 25);
                    this.EmojiRTF = System.IO.File.ReadAllText(filePath + @"\Emoji\Cry.txt");
                    break;
                default:
                    this.EmojiRTF = "";
                    break;
            }
        }
        public string GetEmoji()
        {
            return this.EmojiRTF;
        }
    }
}
