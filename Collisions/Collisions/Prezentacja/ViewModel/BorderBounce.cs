using Collisions.Prezentacja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collisions.Prezentacja.ViewModel
{
    internal class BorderBounce
    {
        private List<Ball> balls;
        private Field field;
        public BorderBounce(List<Ball> balls, Field field) 
        {
            this.balls = balls;
            this.field = field;
        }

        public void checkBounce()
        {
            foreach (Ball ball in balls)
            {
                if (ball.X <= 0 || ball.X >= field.Width - ball.Radius) { ball.setDirection(-ball.XDirection, ball.YDirection); }
                if (ball.Y <= 0 || ball.Y >= field.Height - ball.Radius) { ball.setDirection(ball.XDirection, -ball.YDirection); }
            }
        }
    }
}
