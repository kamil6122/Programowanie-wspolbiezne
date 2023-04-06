using Collisions.Prezentacja.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Collisions.Prezentacja.ViewModel
{
    class CreateBalls : INotifyPropertyChanged
    {
        private List<Ball> balls = new List<Ball>();
        private Field field;
        private int amountOfBalls;

        public StartAnimation startAnimation { get; set; }

        public CreateBalls()
        {
            startAnimation = new StartAnimation(this);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public int AmountOfBalls
        {
            get { return amountOfBalls; }
            set
            {
                if (amountOfBalls != value)
                {
                    amountOfBalls = value;
                    OnPropertyChanged(nameof(amountOfBalls));
                }
            }
        }

        public Field Field
        {
            get { return field; }
            set { field = value; }
        }

        public List<Ball> Balls { get { return balls; } }

        public void generateBalls()
        {
            field.clearBalls();
            for (int i = 0; i < AmountOfBalls; i++)
            {
                Random rng = new Random();

                int x = rng.Next(25, field.Width - 25);
                int y = rng.Next(25, field.Height - 25);

                int xDir = rng.Next(-3, 4);
                int yDir = rng.Next(-3, 4);


                Debug.WriteLine(xDir.ToString() + " " + yDir.ToString());
                

                Ball newBall = new Ball(20);
                
                field.addBall(newBall);

                newBall.changePosition(x, y);
                newBall.setDirection(xDir, yDir);
                
                balls.Add(newBall);
            }

        }

    }
}
