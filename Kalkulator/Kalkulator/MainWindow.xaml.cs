using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Text.RegularExpressions;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        
        public Calculator()
        {
            InitializeComponent();
        }

        public string getTextFromLiczba_1()
        {
            return this.liczba_1.Text;
        }

        public string getTextFromLiczba_2()
        {
            return this.liczba_2.Text;
        }

        public string getTextFromWynik()
        {
            return this.wynik.Text;
        }

        public int convertStringToInt(string str)
        {
            return int.Parse(str);
        }

        public int add(int x, int y)
        {
            return x + y;
        }

        public int substruct(int x, int y)
        {
            return x - y;
        }

        public int multiplication(int x, int y)
        {
            return x * y;
        }

        public int divide(int x, int y)
        {
            int result = 0;
            try
            {
                result = x / y;

            } catch(DivideByZeroException ex)
            {                
                MessageBox.Show("Nie wolno dzielic przez 0!", ex.Message);
                
            }
            return result;
        }

        public bool validInput()
        {
            Regex regex = new Regex("^[0-9]+$");
            string liczba1 = this.liczba_1.Text;
            string liczba2 = this.liczba_2.Text;
            bool a = regex.IsMatch(liczba1);
            bool b = regex.IsMatch(liczba2);
            return regex.IsMatch(this.liczba_1.Text) && regex.IsMatch(this.liczba_2.Text);
        }

        public bool emptyInput()
        {
            return this.liczba_1.Text == "" || this.liczba_2.Text == "";
        }

        private void onlyNumberAvailable(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void onAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validInput() && !emptyInput())
            {
                this.wynik.Text = add(convertStringToInt(this.liczba_1.Text), convertStringToInt(this.liczba_2.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Bledne dane!");
            }
        }

        private void onSubstruct_Click(object sender, RoutedEventArgs e)
        {
            if (validInput() && !emptyInput())
            {
                this.wynik.Text = substruct(convertStringToInt(this.liczba_1.Text), convertStringToInt(this.liczba_2.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Bledne dane!");
            }
        }

        private void onMultiple_Click(object sender, RoutedEventArgs e)
        {
            if (validInput() && !emptyInput())
            {
                this.wynik.Text = multiplication(convertStringToInt(this.liczba_1.Text), convertStringToInt(this.liczba_2.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Bledne dane!");
            }
        }

        private void onDivide_Click(object sender, RoutedEventArgs e)
        {
            if (validInput() && !emptyInput())
            {
                this.wynik.Text = divide(convertStringToInt(this.liczba_1.Text), convertStringToInt(this.liczba_2.Text)).ToString();
                if (convertStringToInt(this.liczba_2.Text) == 0)
                {
                    this.wynik.Text = "Dzielenie przez 0!";
                }   
            }
            else
            {
                MessageBox.Show("Bledne dane!");
            }
        }

    }
}
