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
        private int radius;
        private int x;
        private int y;
        private int xDirection;
        private int yDirection;

        public Ball(int radius)
        {
            this.radius = radius;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public int Radius 
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
        public int X 
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
        public int Y 
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
        public int XDirection { get { return xDirection; } }
        public int YDirection { get { return yDirection; } }


        public void changePosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void setDirection(int x, int y)
        {
            this.xDirection = x;
            this.yDirection = y;
        }
    }
}
