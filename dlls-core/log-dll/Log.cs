using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LoESoft.Log
{
    public abstract class Log
    {
        protected string _type { get; set; }

        private string _origin { get; set; }
        private List<string> _data { get; set; }

        protected string[] _time => DateTime.Now.ToString().Split(' ');

        public Log(string origin, string type)
        {
            _origin = origin;
            _type = type;
            _data = new List<string>();
        }

        public virtual void Write(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            string message = $"[{_time[1]}]\t{_origin}\t{text}";

            _data.Add(message);

            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Export() => File.WriteAllLines($"{_type}/[{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} at {_time[1].Replace(":", ".")}] {_type}.txt", _data);
    }

    public class Error : Log
    {
        public Error(string origin) : base(origin, "error") { }

        public void Write(string text) { base.Write(text, ConsoleColor.DarkRed); }
    }

    public class Info : Log
    {
        public Info(string origin) : base(origin, "info") { }

        public void Write(string text) { base.Write(text); }
    }

    public class Warn : Log
    {
        public Warn(string origin) : base(origin, "warn") { }

        public void Write(string text) { base.Write(text, ConsoleColor.DarkYellow); }
    }
}
