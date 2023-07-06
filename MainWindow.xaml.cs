using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

namespace unix_convert
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Regex regex = new Regex(@"^\d+$");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonConvertUnixToDateTime_Click(object sender, RoutedEventArgs e)
        {

            // TODO: Max value 253402300799999. Numbers greater than this bork the program.

            var errorMessage = "Sorry, this time is not valid." + System.Environment.NewLine + System.Environment.NewLine + "Check your timestamp, strip letters and punctuation marks.";

            var dateError = "Expecting a more recent date? Check your input.";

            if (regex.IsMatch(txtUnixInput.Text))
            {
                var input = long.Parse(txtUnixInput.Text);

                if (!string.IsNullOrWhiteSpace(txtUnixInput.Text))
                {
                    var offsetFormat = "dddd, d MMMM yyyy" + System.Environment.NewLine + "h:mm tt";

                    if (input >= Decimal.Parse("1E11", System.Globalization.NumberStyles.Float))
                    {
                        DateTimeOffset offset = DateTimeOffset.FromUnixTimeMilliseconds(input);
                        output.Clear();
                        output.Text = offset.ToString(offsetFormat) + System.Environment.NewLine + System.Environment.NewLine + "Timestamp is in milliseconds.";

                        if ((input >= 100) && (input < 18E7))
                        {
                            errorOutput.Text = dateError;
                        }
                    }

                    else
                    {
                        DateTimeOffset offset = DateTimeOffset.FromUnixTimeSeconds(input);
                        output.Clear();
                        output.Text = offset.ToString(offsetFormat) + System.Environment.NewLine + System.Environment.NewLine + "Timestamp is in seconds.";

                        if ((input >= 100) && (input < 18E7))
                        {
                            errorOutput.Text = dateError;
                        }
                    }

                    output.AppendText(System.Environment.NewLine + System.Environment.NewLine + txtUnixInput.Text);
                    
                    txtUnixInput.Clear();
                    
                }
            }
            else
            {
                output.Text = errorMessage;
                errorOutput.Clear();
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            output.Clear();
            txtUnixInput.Clear();
            errorOutput.Clear();
        }
    }
}