using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace appOrganizer.Organizer.Data
{
    public static class Helper
    {
        public static string TextToStandart(string text)
        {
            if (text == "" || text == null)
                throw new ArgumentNullException();

            string[] arrayWords = text.Split(' ');
            List<string> listWords = new List<string>();

            foreach (string word in arrayWords)
            {
                if (word == "" || word == " " || word == "\n")
                    continue;
                listWords.Add(word);
            }

            string finalText = String.Join(" ", listWords.ToArray());

            if (finalText.Length > 1)
                return finalText[0].ToString().ToUpper() + finalText[1..].ToLower();
            if (finalText.Length == 1)
                return finalText[0].ToString().ToUpper();
            return "";
        }
    }
}