using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dane
{
    public class Ball : INotifyPropertyChanged
    {
        private double radius;
        private double x;
        private double y;
        private double xDirection;
        private double yDirection;
        private double mass;

        public Ball(double radius)
        {
            this.radius = radius;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


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
        public double XDirection { get { return xDirection; } }
        public double YDirection { get { return yDirection; } }


        public void changePosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void setDirection(double x, double y)
        {
            this.xDirection = x;
            this.yDirection = y;
        }
    }
}
