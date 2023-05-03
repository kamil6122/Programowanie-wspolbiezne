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
            Random rng = new Random();
            int radius = rng.Next(15,25);
            GenerateBalls(amountOfBalls, radius);
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

            double x = rng.Next(25, (int)this.Width - 25);
            double y = rng.Next(25, (int)this.Height - 25);

            double xDir;
            do
            {
                xDir = rng.NextDouble() * 0.99;
            } while (xDir == 0);
            xDir = (rng.Next(-1,1) < 0) ? xDir : -xDir;

            double yDir;
            do
            {
                yDir = rng.NextDouble() * 0.99;
            } while (yDir == 0);
            yDir = (rng.Next(-1, 1) < 0) ? yDir : -yDir;

            double mass = rng.Next(5, 30);

            Ball newBall = new Ball(radius);

            newBall.changePosition(x, y);
            newBall.setDirection(xDir, yDir);
            newBall.Mass = mass;

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
