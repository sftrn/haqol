using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Loggerns
{
    public static class Logger
    {
        static string prefix;
        static FileStream fs;
        static Action<string> logFunction;
        public static void Init(string _prefix, bool openConsole = true)
        {
            prefix = _prefix;

            if (openConsole)
            {
                logFunction = LogConsole;
                AllocConsole();

                // stdout's handle seems to always be equal to 7
                IntPtr defaultStdout = new IntPtr(7);
                IntPtr currentStdout = GetStdHandle(StdOutputHandle);

                if (currentStdout != defaultStdout)
                    // reset stdout
                    SetStdHandle(StdOutputHandle, defaultStdout);

                // reopen stdout
                TextWriter writer = new StreamWriter(Console.OpenStandardOutput())
                { AutoFlush = true };
                Console.SetOut(writer);
            }
            else
            {
                fs = File.Open("haqol.log", FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                logFunction = LogFile;
            }
            Log("Logger init complete");
        }
        public static void Log(string message)
        {
            logFunction(message);
        }
        public static string FormatMessage(string message)
        {
            return string.Format("[{1}]{0,11}: {2}",  DateTime.Now.ToString("HH:mm:ss:fff"), prefix, message);
        }
        public static void LogFile(string message)
        {
            var mBytes = Encoding.UTF8.GetBytes($"{FormatMessage(message)}\n");
            fs.Write(mBytes, 0, mBytes.Length);
            fs.Flush();
        }
        public static void LogConsole(string message)
        {
            Console.WriteLine($"{FormatMessage(message)}");
        }

        private const UInt32 StdOutputHandle = 0xFFFFFFF5;
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(UInt32 nStdHandle);
        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);
        [DllImport("kernel32")]
        static extern bool AllocConsole();
    }
}
