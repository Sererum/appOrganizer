using System;
using System.Collections.Generic;

namespace appOrganizer.Organizer.Data
{
    public static class Helper
    {
        public static Dictionary<int, int> PriorityToColorId = new Dictionary<int, int>()
        {
            { 1, Resource.Color.priorityOne },
            { 2, Resource.Color.priorityTwo },
            { 3, Resource.Color.priorityThree },
            { 4, Resource.Color.priorityFour },
            { 5, Resource.Color.priorityFive },
            { 6, Resource.Color.prioritySix },
            { 7, Resource.Color.prioritySeven },
            { 8, Resource.Color.priorityEight },
            { 9, Resource.Color.priorityNine },
        };

        public static string TextToStandart(string text)
        {
            if (text == null)
                throw new ArgumentNullException();

            if (text == "")
                return "";

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

        public static Dictionary<byte, string> DateToString = new Dictionary<byte, string>()
        {
            { (byte) GroupDate.Today, GetStringDate(GroupDate.Today) },
            { (byte) GroupDate.Tomorrow, GetStringDate(GroupDate.Tomorrow) },
            { (byte) GroupDate.ThisMonth, GetStringDate(GroupDate.ThisMonth) },
            { (byte) GroupDate.NextMonth, GetStringDate(GroupDate.NextMonth) },
            { (byte) GroupDate.Year, GetStringDate(GroupDate.Year) },
            { (byte) GroupDate.Global, GetStringDate(GroupDate.Global) }
        };

        public enum GroupDate : byte { Today, Tomorrow, ThisMonth, NextMonth, Year, Global }

        public static string GetStringDate (GroupDate date)
        {
            DateTime time;
            if (date == GroupDate.Today)
            {
                time = DateTime.Now;
                return time.Day + "/" + time.Month;
            }
            if (date == GroupDate.Tomorrow)
            {
                time = DateTime.Now.AddDays(1);
                return time.Day + "/" + time.Month;
            }
            if (date == GroupDate.ThisMonth)
            {
                time = DateTime.Now;
                return time.Month + "/" + time.Year;
            }
            if (date == GroupDate.NextMonth)
            {
                time = DateTime.Now.AddMonths(1);
                return time.Month + "/" + time.Year;
            }
            if (date == GroupDate.Year)
            {
                time = DateTime.Now;
                return time.Year.ToString();
            }
            return "";
        }
    }
}