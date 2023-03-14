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
using System.Configuration;
using PiTester.Properties;

namespace PiTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Written by Ben Barenz March 12,2019
    /// Dumb program to help me learn pi 
    /// </summary>

    public partial class MainWindow : Window
    {
        static string PiStr100 = "3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679";
        static string PiStr200 = "3.14159265358979323846264338327950288419716939937510582097494459230781640628620899862803482534211706798214808651328230664709384460955058223172535940812848111745028410270193852110555964462294895493038196";
        static string PiStr1000 = "3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679821480865132823066470938446095505822317253594081284811174502841027019385211055596446229489549303819644288109756659334461284756482337867831652712019091456485669234603486104543266482133936072602491412737245870066063155881748815209209628292540917153643678925903600113305305488204665213841469519415116094330572703657595919530921861173819326117931051185480744623799627495673518857527248912279381830119491298336733624406566430860213949463952247371907021798609437027705392171762931767523846748184676694051320005681271452635608277857713427577896091736371787214684409012249534301465495853710507922796892589235420199561121290219608640344181598136297747713099605187072113499999983729780499510597317328160963185950244594553469083026425223082533446850352619311881710100031378387528865875332083814206171776691473035982534904287554687311595628638823537875937519577818577805321712268066130019278766111959092164201989";

        private char[] PiDigits;
        private int DigitCnt = 0;
        private int LastDigitCnt = 0;
        private string HowManyDigits;
        private int HighScore; 

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        public MainWindow()
        {
            InitializeComponent();
            lbl_OutputInfo.Visibility = Visibility.Hidden;
            txt_EnterDigits.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, HandlePaste));
            HighScore = Properties.Settings.Default.SavedHighScore;
            lbl_HighScore.Content = $"High Score: {HighScore}"; 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCheckboxes();
            txtb_Output.Text = "";
            txt_EnterDigits.Focus();
        }

        private void txt_EnterDigits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
            spnl_SelectDigits.IsEnabled = false;
        }

        private void HandlePaste(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void Txt_EnterDigits_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (LastDigitCnt < txt_EnterDigits.Text.Length)
            {

                char[] DigitList = txt_EnterDigits.Text.ToCharArray();

                if (DigitList[DigitCnt] == PiDigits[DigitCnt])
                {

                    txtb_Output.Text = txtb_Output.Text.ToString() + DigitList[DigitCnt];
                    if (DigitCnt > 1) lbl_DigitLength.Content = (DigitCnt - 1).ToString(); // Offset to account for the 3. at beginning 
                    DigitCnt += 1;

                    if (DigitCnt == PiDigits.Length)
                    {
                        lbl_OutputInfo.Foreground = Brushes.Green;
                        string message = "";
                        if (rbtn_100Digits.IsChecked == true) message = "Horray! You win at life! "; else if (rbtn_200Digits.IsChecked == true) message = "You're a Pi-God! "; else if (rbtn_1000Digits.IsChecked == true) message = "You're a machine! (most likely)";
                        lbl_OutputInfo.Content = message + HowManyDigits + " digits of Pi!!!";
                        lbl_OutputInfo.Visibility = Visibility.Visible;
                        txt_EnterDigits.IsEnabled = false;
                        
                        SaveHighScore(DigitCnt);
                    }
                }

                else
                {
                    if (DigitCnt > 0) lbl_OutputInfo.Content = "GAME OVER. You got " + (DigitCnt - 2) + " digits correct. Click Start Over to try again"; else lbl_OutputInfo.Content = "Damn you really suck! Click Star Over to try again";
                    lbl_OutputInfo.Visibility = Visibility.Visible;
                    txt_EnterDigits.IsEnabled = false;

                    SaveHighScore(DigitCnt); 
                    // Add the next 10 correct digits to the output label 
                    string Next10 = "";

                    for (int i = DigitCnt; i < PiDigits.Length; i++) Next10 += PiDigits[i];

                    txtb_Output.TextWrapping = TextWrapping.Wrap;
                    txtb_Output.Inlines.Add(new Run(Next10) { Foreground = Brushes.Red });

                }
            } // End validate text 
            LastDigitCnt = DigitCnt;

        }// End text changed 

        private void SaveHighScore (int Score)
        {
            HighScore = Score;
            Properties.Settings.Default.SavedHighScore = HighScore;
            lbl_HighScore.Content = $"High Score: {HighScore}";
            PiTester.Properties.Settings.Default.Save(); 

        }

        private void Btn_StartOver_Click(object sender, RoutedEventArgs e)
        {
            ResetTest(false);
            txt_EnterDigits.Focus();
            spnl_SelectDigits.IsEnabled = true;
        }

        private void btn_StartOverLastPos_Click(object sender, RoutedEventArgs e)
        {
            ResetTest(true);
            txt_EnterDigits.Focus();
            spnl_SelectDigits.IsEnabled = true;
        }

        private void ResetTest(bool KeepPlace)
        {
            if (KeepPlace)
            {
             
                lbl_DigitLength.Content = DigitCnt;
                txt_EnterDigits.Text = txt_EnterDigits.Text.Remove(DigitCnt, 1);
                txtb_Output.Text = txt_EnterDigits.Text;
                txt_EnterDigits.CaretIndex = DigitCnt;
                LastDigitCnt = DigitCnt;

            }
            else
            {
                txtb_Output.Text = "";
                DigitCnt = 0;
                lbl_DigitLength.Content = "0";
                txt_EnterDigits.Text = "";
                LastDigitCnt = 0;
            }

            lbl_OutputInfo.Visibility = Visibility.Hidden;

            txt_EnterDigits.IsEnabled = true;
            lbl_OutputInfo.Foreground = Brushes.Red;
        }


        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void UpdateCheckboxes()
        {
            if (rbtn_1000Digits.IsChecked == true) { PiDigits = PiStr1000.ToCharArray(); HowManyDigits = "1000"; }
            else if (rbtn_200Digits.IsChecked == true) { PiDigits = PiStr200.ToCharArray(); HowManyDigits = "200"; }
            else if (rbtn_100Digits.IsChecked == true) { PiDigits = PiStr100.ToCharArray(); HowManyDigits = "100"; }
        }

        private void rbtn_100Digits_Click(object sender, RoutedEventArgs e)
        {
            UpdateCheckboxes();
        }

        private void rbtn_200Digits_Click(object sender, RoutedEventArgs e)
        {
            UpdateCheckboxes();
        }

        private void rbtn_1000Digits_Click(object sender, RoutedEventArgs e)
        {
            UpdateCheckboxes();
        }

        private void btn_ClearHighSCore_Click(object sender, RoutedEventArgs e)
        {
            SaveHighScore(0); 
        }
    }
}
