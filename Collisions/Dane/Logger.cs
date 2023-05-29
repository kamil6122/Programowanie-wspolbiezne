using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dane
{
    internal class Logger
    {
        private static List<Ball> balls;
        private Stopwatch stopwatch = new Stopwatch();

        public Logger(List<Ball> balls) 
        {
            balls = balls;
            Thread t = new Thread(() =>
            {
                stopwatch.Start();
                while (true)
                {
                    if (stopwatch.ElapsedMilliseconds >= 5)
                    {
                        stopwatch.Restart();
                        using (StreamWriter stream = new StreamWriter(Directory.GetCurrentDirectory() + "\\logs.txt", true))
                        {
                            string text = ($"Loggs: {DateTime.Now:R}");
                            foreach (Ball b in balls)
                            {
                                stream.WriteLine(text + JsonSerializer.Serialize(b));
                            }
                        }
                    }
                }
            })
            {
                IsBackground = true
            };
            t.Start();
        }

        public void stop()
        {
            stopwatch.Reset();
            stopwatch.Stop();
        }
    }
}
