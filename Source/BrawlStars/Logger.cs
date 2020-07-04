using System;
using System.IO;
using NLog;

namespace BrawlStars
{
    public class Logger
    {
        public enum ErrorLevel
        {
            Info = 1,
            Warning = 2,
            Error = 3,
            Debug = 4
        }
#if DEBUG
        private static readonly object ConsoleSync = new object();
#endif

        private static NLog.Logger _logger;

        public Logger()
        {
            Directory.CreateDirectory("Logs");

            _logger = LogManager.GetCurrentClassLogger();
        }

        public static void Log(object message, Type type, ErrorLevel logType = ErrorLevel.Info)
        {
            switch (logType)
            {
                case ErrorLevel.Info:
                {
                    _logger.Info(message);

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"[{logType.ToString()}] ");
                    Console.ResetColor();
                    Console.WriteLine(message);
                    break;
                }

                case ErrorLevel.Warning:
                {
                    _logger.Warn(message);
#if DEBUG
                    lock (ConsoleSync)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"[{logType.ToString()}] ");
                        Console.ResetColor();
                        Console.WriteLine(message);
                    }
#endif
                    break;
                }

                case ErrorLevel.Error:
                {
                    _logger.Error(message);
#if DEBUG

                    lock (ConsoleSync)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"[{logType.ToString()}] ");
                        Console.ResetColor();
                        Console.WriteLine(message);
                    }
#endif
                    break;
                }

                case ErrorLevel.Debug:
                {
#if DEBUG
                    _logger.Debug(message);

                    lock (ConsoleSync)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"[{logType.ToString()}] ");
                        Console.ResetColor();
                        Console.WriteLine(message);
                    }
#endif
                    break;
                }
            }
        }
    }
}