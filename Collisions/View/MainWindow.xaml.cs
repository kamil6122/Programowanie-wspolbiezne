using System.Windows;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private CreateBalls createBalls;
        //private Field field;
        public MainWindow()
        {
            InitializeComponent();
            //this.field = new Field(this.canvas);
            //this.createBalls = (CreateBalls)Application.Current.MainWindow.Resources["CB"];
            //this.createBalls.Field = this.field;
            //this.DataContext = this.createBalls;
        }

    }
}
