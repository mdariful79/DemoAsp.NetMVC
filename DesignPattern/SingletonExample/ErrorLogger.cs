 using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.SingletonExample
{
    public class ErrorLogger
    {
        private static ErrorLogger? _instance = null;

        private ErrorLogger() { }

        public static ErrorLogger CreateLogger()
        {
            if (_instance == null)
            {
                _instance = new ErrorLogger();
            }
            return _instance;
        }

        public void LogError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
