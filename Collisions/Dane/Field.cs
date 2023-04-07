using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Field : INotifyPropertyChanged
    {
        private double width;
        private double height;
        private readonly List<Ball> balls = new List<Ball>();

        public Field(int width, int height, int amountOfBalls)
        {
            Width = width;
            Height = height;
            GenerateBalls(amountOfBalls, 20);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
     

        public double Width 
        { 
            get { return width; } 
            set
            {
                if (width != value) 
                {
                    width = value;
                    OnPropertyChanged(nameof(Width));
                }
            }
        }
        public double Height 
        { 
            get { return height; } 
            set 
            {
                if (height != value)
                {
                    height = value; 
                    OnPropertyChanged(nameof(Height));
                }
            }
        }

        public Ball GenerateBall(int radius)
        {
            Random rng = new Random();

            int x = rng.Next(25, (int)this.Width - 25);
            int y = rng.Next(25, (int)this.Height - 25);

            int xDir = rng.Next(-1, 2);
            int yDir = rng.Next(-1, 2);

            Ball newBall = new Ball(20);

            newBall.changePosition(x, y);
            newBall.setDirection(xDir, yDir);

            return newBall;
        }

        public void GenerateBalls(int amountOfBalls, int radius)
        {
            this.balls.Clear();
            for (int i = 0; i < amountOfBalls; i++)
            {
                this.balls.Add(GenerateBall(radius));
            }
        }

        public List<Ball> Balls
        { get { return balls; } }

    }
}
