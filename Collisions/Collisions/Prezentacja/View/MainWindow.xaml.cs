using Collisions.Prezentacja.ViewModel;
using Collisions.Prezentacja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Collisions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CreateBalls createBalls;
        private Field field;
        public MainWindow()
        {
            InitializeComponent();
            this.field = new Field(this.canvas);
            this.createBalls = (CreateBalls)Application.Current.MainWindow.Resources["CB"];
            this.createBalls.Field = this.field;
            this.DataContext = this.createBalls;
        }

        
    }
}
