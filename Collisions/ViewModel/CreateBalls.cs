using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows;
using Model;

namespace ViewModel
{
    public class CreateBalls : INotifyPropertyChanged
    {
        private ObservableCollection<Ball> balls = new ObservableCollection<Ball>();
        private AbstractModelApi modelApi;
        private int amountOfBalls;



        public CreateBalls()
        {
            startAnimation = new StartAnimation(this);
            this.modelApi = AbstractModelApi.Api();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        
        public StartAnimation startAnimation { get; set; }
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


        public ObservableCollection<Ball> Balls 
        { 
            get { return balls; } 
            set 
            {
                if (balls != value) 
                {
                    balls = value;
                    OnPropertyChanged(nameof(balls));
                }
            }
        }
        public void StartUpdating()
        {
            this.modelApi.StartUpdating(AmountOfBalls);
            this.Balls = modelApi.GetBalls();
        }

        public void StopUpdating()
        {
            this.modelApi.StopUpdating();
        }

        public bool IsUpdating()
        {
            return this.modelApi.IsUpdating();
        }

    }

}
