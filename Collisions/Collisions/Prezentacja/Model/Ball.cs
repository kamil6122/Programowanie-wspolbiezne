using Collisions.Prezentacja.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Collisions.Prezentacja.Model
{
    internal class Ball
    {
        private Ellipse ball;
        private int radius;
        private int x;
        private int y;
        private int xDirection;
        private int yDirection;

        public Ball(int radius) 
        {
            this.ball = new Ellipse();
            this.radius = radius;
            this.ball.Width = radius;
            this.ball.Height = radius;
            this.ball.Fill = System.Windows.Media.Brushes.Red;
        }

        public Ellipse _Ball
        { get { return ball; } }

        public int Radius { get { return radius; } }
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int XDirection { get { return xDirection; } }
        public int YDirection { get { return yDirection; } }


        public void changePosition(int x, int y)
        {
            this.x = x; 
            this.y = y;
            this.ball.Margin = new System.Windows.Thickness(x, y, 0, 0);
        }

        public void setDirection(int x, int y)
        {
            this.xDirection = x;
            this.yDirection = y;
        }
    }
}
