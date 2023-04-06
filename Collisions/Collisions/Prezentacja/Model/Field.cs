using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Collisions.Prezentacja.Model
{
    internal class Field
    {
        private Canvas field;

        private int width;
        private int height;

        public Field(Canvas field)
        {
            this.field = field;
            this.width = (int)field.Width;
            this.height = (int)field.Height;
        }

        public void clearBalls()
        {
            field.Children.Clear();
        }

        public void addBall(Ball ball)
        {
            field.Children.Add(ball._Ball);
        }

        public int Width { get { return width; } }
        public int Height { get { return height; } }

    }
}
