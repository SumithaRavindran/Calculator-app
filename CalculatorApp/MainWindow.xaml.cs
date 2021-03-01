using System.Windows;
using System.Windows.Input;

namespace CalculatorApp
{
    /*
     * This is Main window class
     */
    public partial class MainWindow : Window
    {
        private CalculatorOrchestrator calculatorOrchestrator;

        public MainWindow()
        {
            InitializeComponent();
            calculatorOrchestrator = new CalculatorOrchestrator();
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateNumberToSystem(txtDisplay, "0");
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateNumberToSystem(txtDisplay, "1");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateNumberToSystem(txtDisplay, "2");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateNumberToSystem(txtDisplay, "3");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateNumberToSystem(txtDisplay, "4");
        }
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateNumberToSystem(txtDisplay, "5");
        }
        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateNumberToSystem(txtDisplay, "6");
        }
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateNumberToSystem(txtDisplay, "7");
        }
        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateNumberToSystem(txtDisplay, "8");
        }
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateNumberToSystem(txtDisplay, "9");
        }
        private void BtnChangeSign_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.ChangeSign(txtDisplay);
        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateOperation(txtDisplay, '+');
        }
        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateOperation(txtDisplay, '-');
        }
        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateOperation(txtDisplay, '*');
        }
        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.UpdateOperation(txtDisplay, '/');
        }
        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.ComputeResult(txtDisplay);
        }
      
        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.ExecuteCE(txtDisplay);
        }
        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.ExecuteC(txtDisplay);
        }
        private void BtnPeriod_Click(object sender, RoutedEventArgs e)
        {
            calculatorOrchestrator.ExecutePeriod(txtDisplay);
        }
        private static bool shiftPressed = true;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                shiftPressed = true;
                return;
            }
                
            if(e.Key == Key.OemPlus)
            {
                if(shiftPressed)
                    calculatorOrchestrator.UpdateOperation(txtDisplay, '+');
                else
                    calculatorOrchestrator.ComputeResult(txtDisplay);
                shiftPressed = false;
                return;
            }

            if(e.Key == Key.D8 && shiftPressed)
            {
                calculatorOrchestrator.UpdateOperation(txtDisplay, '*');
                shiftPressed = false;
                return;
            }
            if (e.Key == Key.OemMinus && shiftPressed)
            {
                calculatorOrchestrator.UpdateOperation(txtDisplay, '-');
                shiftPressed = false;
                return;
            }

            if (e.Key == Key.OemPeriod && shiftPressed)
            {
                calculatorOrchestrator.ExecutePeriod(txtDisplay);
                shiftPressed = false;
                return;
            }
            if (e.Key == Key.OemQuestion && shiftPressed)
            {
                calculatorOrchestrator.UpdateOperation(txtDisplay, '/');
                shiftPressed = false;
                return;
            }


            if (e.Key == Key.Enter)
            {
                calculatorOrchestrator.ComputeResult(txtDisplay);
                return;
            }
                

            int value = -1;

            if (e.Key >= Key.D0 && e.Key <= Key.D9) // check for top row "0" through "9"
            {
                value = e.Key - Key.D0;
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) // check for Numeric Keypad"0" through "9"
            {
                value = e.Key - Key.NumPad0;
            }
            if(value != -1)
                calculatorOrchestrator.UpdateNumberToSystem(txtDisplay, value.ToString());
          
          
        }
    }
}

