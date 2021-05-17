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

namespace WPF_intro_._XAML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }
        bool newValue = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(newValue == true)
            {
                tblResult.Text = "";
                newValue = false;
            }
            var elems = tblResult.Text.Split(" ");
            if (elems.Length == 2)
            {
                tblMath.Text = $"{elems[0] } {elems[1]}";
                tblResult.Text = $"{(sender as Button).Content}";
            }
            
            else
            {
                if (tblResult.Text == "")
                {
                    tblResult.Text = $"{(sender as Button).Content}";
                }
                else
                {
                   
                    tblResult.Text += $"{(sender as Button).Content}";
                    
                }
            }
        }
        private void Button_ClickMathOperator(object sender, RoutedEventArgs e)
        {
            if(newValue == true)
            {
               
                newValue = false;
            }
            var elems = tblMath.Text.Split(" ");
            if (elems.Length == 0)
            {
                return;
            }else if(elems.Length == 1)
            {
                tblMath.Text = tblResult.Text + $" { (sender as Button).Content} ";
                tblResult.Text = "";
                return;

            }
            else if (elems.Length == 2 && tblResult.Text == "")
            {
                tblMath.Text += $"{elems[0]} { (sender as Button).Content} ";
                return;
            }
            else if(elems.Length == 3 && elems[2] != "" && tblResult.Text != "")
            {
                tblMath.Text = $"{tblResult.Text} { (sender as Button).Content} ";
                tblResult.Text = "";
                return;

            }
            else if(elems.Length == 3 && elems[2] != "")
            {
                Button_Click_2(null, null);
                tblMath.Text = tblResult.Text + $" { (sender as Button).Content} ";
                return;

            }
            else if (elems.Length == 3 && elems[2] != "" && tblResult.Text != "")
            {              
                tblMath.Text = tblResult.Text + $" { (sender as Button).Content} ";
                tblResult.Text = "";
                return;

            }
            else if(elems.Length == 2 || elems[2] == "" && tblResult.Text != "")
            {
                newValue = true;
                tblMath.Text += tblResult.Text;

                Button_Click_2(null, null);               
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tblResult.Text = "";
            tblMath.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var elems = tblMath.Text.Split(" ");
            if (elems.Length == 3 && elems[2] == "")
            {
                tblMath.Text += tblResult.Text;
                elems = tblMath.Text.Split(" ");
            }
            if(elems.Length >= 3 && elems[2] != "")
            {
                
                if(elems[1] == "+")
                { 
                   tblResult.Text = $"{double.Parse(elems[0]) + double.Parse(elems[2])}";
                }else if(elems[1] == "-")
                {
                    tblResult.Text = $"{double.Parse(elems[0]) - double.Parse(elems[2])}";
                }else if (elems[1] == "*")
                {
                    tblResult.Text = $"{double.Parse(elems[0]) * double.Parse(elems[2])}";
                }
                else if (elems[1] == "/")
                {
                    tblResult.Text = $"{double.Parse(elems[0]) / double.Parse(elems[2])}";
                }else if (elems[1] == "<")
                {
                    tblResult.Text = $"{double.Parse(elems[0]) < double.Parse(elems[2])}";
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var elems = tblMath.Text.Split(" ");
            if(elems.Length == 0)
            {
                elems = tblResult.Text.Split(" ");
                elems[0] = elems[0].Remove(elems[0].Length - 2 < 0 ? 0 : elems.Length - 2);
                return;
            }
            if (elems.Length >= 3 && elems[2] != "")
            {
                elems[2] = elems[2].Remove(elems[2].Length - 2 < 0 ? 0 : elems.Length - 2);
                tblMath.Text = $"{elems[0]} {elems[1]} {elems[2]}";
            } else if (elems.Length == 1)
            {
                if(elems[0] == "")
                {
                    return;
                }
                elems[0] = elems[0].Remove(elems[0].Length - 2 < 0 ? 0 : elems.Length - 2);
                tblMath.Text = $"{elems[0]}";
            }
            else if (elems.Length == 2 || elems[2] == "")
            {
                elems[0] = elems[0].Remove(elems[0].Length - 2 < 0 ? 0 : elems.Length - 2);
                tblMath.Text = $"{elems[0]}";
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var elems = tblMath.Text.Split(" ");
            if (elems.Length >= 3)
            {               
                tblMath.Text = $"{elems[0]} {elems[1]}";
                tblResult.Text = "";
            }
            else  
            {         
                tblMath.Text = "";
                tblResult.Text = "";
            }
            
        }
    }
}
