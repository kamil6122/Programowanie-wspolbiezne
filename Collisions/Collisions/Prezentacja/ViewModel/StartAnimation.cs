using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Collisions.Prezentacja.ViewModel
{
    class StartAnimation : ICommand
    {
        CreateBalls createBalls;
        UpdatePositions updatePositions;

        public StartAnimation(CreateBalls createBalls)
        {
            this.createBalls = createBalls;
            updatePositions = new UpdatePositions();
        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (!updatePositions.IsUpdating())
            {
                createBalls.generateBalls();    
                updatePositions.startUpdating(createBalls.Balls, createBalls.Field);
            }
            else
            {
                updatePositions.stopUpdating();
            }
        }
    }
}
