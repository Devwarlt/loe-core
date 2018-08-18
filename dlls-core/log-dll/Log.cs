using System;
using System.Collections.Concurrent;
using System.IO;

namespace LoESoft.Log
{
    public abstract class Log
    {
        private string _type { get; set; }
        private string _origin { get; set; }
        private ConcurrentQueue<string> _data { get; set; }
        private int _test { get; set; }

        protected string[] _time => DateTime.Now.ToString().Split(' ');

        public Log(string origin, string type)
        {
            _origin = origin;
            _type = type;
            _data = new ConcurrentQueue<string>();
            _test = 0;
        }

        protected string AddMessage(string text)
        {
            string message = $"[{_time[1]}]\t{_origin}\t{text}";
            _data.Enqueue($"{message}\n");

            return message;
        }

        public virtual void Write(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void Export()
        {
            if (_data.Count == 0)
                return;

            Directory.CreateDirectory(_type);

            string data = null;

            while (_data.Count > 0)
            {
                _data.TryDequeue(out string extraData);
                data += extraData;
            }

            File.WriteAllText($"{_type}/[{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} at {_time[1].Replace(":", ".")}] {_type}.txt", data);
        }
    }

    public class Error : Log
    {
        public Error(string origin) : base(origin, "error") { }

        public void Write(string text) { base.Write(AddMessage(text), ConsoleColor.DarkRed); }
    }

    public class Info : Log
    {
        public Info(string origin) : base(origin, "info") { }

        public void Write(string text) { base.Write(AddMessage(text)); }
    }

    public class Warn : Log
    {
        public Warn(string origin) : base(origin, "warn") { }

        public void Write(string text) { base.Write(AddMessage(text), ConsoleColor.DarkYellow); }
    }
}
