using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ViewModel
{
    public class StartAnimation : ICommand
    {
        CreateBalls createBalls;

        public StartAnimation(CreateBalls createBalls)
        {
            this.createBalls = createBalls;
        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (!this.createBalls.IsUpdating())
            {
                this.createBalls.StartUpdating();
            }
            else
            {
                this.createBalls.StopUpdating();
            }
        }
    }
}
