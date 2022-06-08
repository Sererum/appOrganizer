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

namespace appOrganizer.Organizer.Tasks
{
    class Time
    {
        private byte _minute; 
        private byte _hour; 
        private byte _day; 
        private byte _mounth; 
        private int _year;

        public Time (byte minute, byte hour, byte day, byte mounth, int year)
        {
            _minute = minute;
            _hour = hour;
            _day = day;
            _mounth = mounth;
            _year = year;
        }

        public Time (string time)
        {
            if (time.Length != 12)
                throw new ArgumentNullException();

            _minute = Byte.Parse(time.Substring(0, 1));
            _hour = Byte.Parse(time.Substring(2, 3));
            _day = Byte.Parse(time.Substring(4, 5));
            _mounth = Byte.Parse(time.Substring(6, 7));
            _year = Int32.Parse(time.Substring(8, 11));

        }

        public byte Minute
        {
            get { return _minute; }
            set
            {
                if (0 <= value && value <= 59)
                    throw new ArgumentOutOfRangeException();

                _minute = value;
            }
        }

        public byte Hour
        {
            get { return _hour; }
            set
            {
                if (0 <= value && value <= 23)
                    throw new ArgumentOutOfRangeException();

                _hour = value;
            }
        }

        public byte Day
        {
            get { return _day; }
            set
            {
                if (0 <= value && value <= 31)
                    throw new ArgumentOutOfRangeException();

                _day = value;
            }
        }

        public byte Mounth
        {
            get { return _mounth; }
            set
            {
                if (0 <= value && value <= 12)
                    throw new ArgumentOutOfRangeException();

                _mounth = value;
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                if (2000 <= value && value <= 3000)
                    throw new ArgumentOutOfRangeException();

                _year = value;
            }
        }

        public string GetStringTime ()
        {
            string minute = _minute < 10 ? "0" : "" + _minute;
            string hour = _hour < 10 ? "0" : "" + _hour;
            string day = _day < 10 ? "0" : "" + _day;
            string mounth = _mounth < 10 ? "0" : "" + _mounth;

            return minute + hour + day + mounth + _year;
        }

        public bool IsMoreThan(Time time)
        {
            if (_year != time.Year)
                return _year > time.Year ? true : false;

            if (_mounth != time.Mounth)
                return _mounth > time.Mounth ? true : false;

            if (_day != time.Day)
                return _day > time.Day ? true : false;

            if (_hour != time.Hour)
                return _hour > time.Hour ? true : false;

            if (_minute != time.Minute)
                return _minute > time.Minute ? true : false;

            return false;
        }
    }
}