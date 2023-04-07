using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika
{
    public class BallLogic : INotifyPropertyChanged
    {
        private Ball ball;
        public BallLogic(Ball ball)
        {
            this.ball = ball;
            this.ball.PropertyChanged += Update;
        }

        private void Update(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ball.X)) 
            {
                OnPropertyChanged(nameof(ball.X));
            }
            else if (e.PropertyName == nameof(ball.Y)) 
            {
                OnPropertyChanged(nameof(ball.Y));
            }
            else if (e.PropertyName == nameof(ball.Radius))
            {
                OnPropertyChanged(nameof(ball.Radius));
            }
        }

        public int X
        {
            get { return ball.X; }
            set 
            {
                if (ball.X != value) 
                {
                    ball.X = value;
                    OnPropertyChanged(nameof(ball.X));
                }
            }
        }

        public int Y
        {
            get { return ball.Y; }
            set
            {
                if (ball.Y != value)
                {
                    ball.Y = value;
                    OnPropertyChanged(nameof(ball.Y));
                }
            }
        }

        public int Radius
        {
            get { return ball.Radius; }
            set
            {
                if (ball.Radius != value)
                {
                    ball.Radius = value;
                    OnPropertyChanged(nameof(ball.Radius));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
   
    }
}
