using Collisions.Prezentacja.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Collisions.Prezentacja.ViewModel
{
    internal class UpdatePositions
    {
        private DispatcherTimer timer;
        private List<Ball> balls;
        private bool updating;
        private BorderBounce borderBounce;
        
        private void UpdateBallsPositions(object sender, EventArgs e)
        {
            foreach(Ball ball in balls)
            {
                ball.changePosition(ball.X + ball.XDirection, ball.Y + ball.YDirection);
            }
            borderBounce.checkBounce();
        }

        public UpdatePositions()
        {
            this.updating = false;
        }

        public bool IsUpdating() { return updating; }

        public void startUpdating(List<Ball> balls, Field field)
        {
            borderBounce = new BorderBounce(balls, field);
            this.updating = true;
            this.balls = balls;
            this.timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Tick += new EventHandler(UpdateBallsPositions);
            timer.Interval = new TimeSpan(0,0,0,0,1);
            timer.Start();
        }

        public void stopUpdating()
        {
            updating = false;
            timer.Stop();
        }

    }
}
