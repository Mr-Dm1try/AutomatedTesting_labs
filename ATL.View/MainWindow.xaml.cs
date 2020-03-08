using ATL.Model;
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

namespace ATL.View
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var symbol = Rad_Brackets.IsChecked.Value ? Symbol.Brackets : Symbol.Quotes;

                if (!TextTransform.CheckTextContainsSymbols(Text_Enter.Text, symbol))
                    MessageBox.Show("There are no selected symbols in the text!", "Oops...");
                else
                    Text_Out.Text = TextTransform.RemoveTextBetweenSymbols(Text_Enter.Text, symbol);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error:\n" + ex.Message, "Error!");
            }                       
        }
    }
}
