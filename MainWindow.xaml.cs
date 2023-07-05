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

namespace unix_convert
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

        private void ButtonConvertUnixToDateTime_Click(object sender, RoutedEventArgs e)
        {
            var input = long.Parse(txtUnixInput.Text);

            if (input >= Decimal.Parse("1E11", System.Globalization.NumberStyles.Float))
            {
                DateTimeOffset offset = DateTimeOffset.FromUnixTimeMilliseconds(input);
                output.Items.Clear();
                output.Items.Add(offset);
            }
            else
            {
                DateTimeOffset offset = DateTimeOffset.FromUnixTimeSeconds(input);
                output.Items.Clear();
                output.Items.Add(offset);
            }

            output.Items.Add(txtUnixInput.Text);

            txtUnixInput.Clear();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            output.Items.Clear();
            txtUnixInput.Clear();
        }
    }
}
