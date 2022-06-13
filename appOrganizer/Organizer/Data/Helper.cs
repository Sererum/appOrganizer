using System;

namespace appOrganizer.Organizer.Data
{
    public static class Helper
    {
        public static string TextToStandart(string text)
        {
            if (text == "" || text == null)
                throw new ArgumentNullException();

            string[] arrayWords = text.Split();
            string final = arrayWords[0];

            foreach (string word in arrayWords[1..])
            {
                if (word == "")
                    continue;
                final += " " + word;
            }

            if (final.Length == 0)
                return "";
            return final[0].ToString().ToUpper() + final[1..];
        }
    }
}