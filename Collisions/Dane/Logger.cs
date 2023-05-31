using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;

namespace Dane
{
    internal class Logger
    {
        private List<Ball> balls;
        private System.Timers.Timer timer;

        public Logger(List<Ball> balls) 
        {
            this.balls = balls;
            SetTimer();
        }

        private void SetTimer()
        {
            timer = new System.Timers.Timer(500);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            using (StreamWriter stream = new StreamWriter(Directory.GetCurrentDirectory() + "\\logs.txt", true))
            {
                string text = ($"Loggs: {DateTime.Now:R}");
                foreach (Ball b in this.balls)
                {
                    stream.WriteLine(text + JsonSerializer.Serialize(b));
                }
            }   
        }

        public void stop()
        {
            timer.Stop();
            timer.Elapsed -= OnTimedEvent;
        }
    }
}
