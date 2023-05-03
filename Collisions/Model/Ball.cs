using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ball : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double radius;
        private double mass;

        public Ball(BallLogic ball)
        {
            this.x = ball.X;
            this.y = ball.Y;
            this.radius = ball.Radius;
            this.mass = ball.Mass;
            ball.PropertyChanged += Move;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void Move(object sender, PropertyChangedEventArgs e)
        {
            BallLogic ball = (BallLogic)sender;
            if (e.PropertyName == nameof(ball.X)) 
            {
                this.X = ball.X;
            }
            if(e.PropertyName == nameof(ball.Y)) 
            {
                this.Y = ball.Y;
            }
        }

        public double X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (y != value) 
                {
                    y = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }

        public double Radius
        {
            get { return radius; }
            set
            {
                if (radius != value)
                {
                    radius = value;
                    OnPropertyChanged(nameof(Radius));
                }
            }
        }

        public double Mass
        {
            get { return mass; }
            set
            {
                if (mass != value)
                {
                    mass = value;
                    OnPropertyChanged(nameof(Mass));
                }
            }
        }
       
    }
}
