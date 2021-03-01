using System.Windows.Controls;

namespace CalculatorApp
{
    class CalculatorOrchestrator
    {
        string input = string.Empty;
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        char operation;
        double result = 0.0;

        public void UpdateNumberToSystem(TextBox txtDisplay,  string number)
        {
            txtDisplay.Text = "";
            input += number;
            txtDisplay.Text += input;
        }
        public void ChangeSign(TextBox txtDisplay)
        {
            double num1;
            double.TryParse(input, out num1);
            num1 *= -1;
            txtDisplay.Text = input = num1.ToString();
        }

        public void UpdateOperation(TextBox txtDisplay, char operation)
        {
            txtDisplay.Text = "";
            operand1 = input;
            this.operation = operation;
            input = string.Empty;
            txtDisplay.Text += input;
        }
        public void ComputeResult(TextBox txtDisplay)
        {
            operand2 = input;
            double num1, num2;
            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);

            txtDisplay.Text = "";
            this.input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty;

            if (operation == '+')
            {
                result = num1 + num2;

            }
            else if (operation == '-')
            {
                result = num1 - num2;

            }
            else if (operation == '*')
            {
                result = num1 * num2;

            }
            else if (operation == '/')
            {
                if (num2 != 0)
                {
                    result = num1 / num2;

                }
                else
                {
                    txtDisplay.Text = "undefined";
                }

            }
            if ((result - (int)result) != 0)
            {

                txtDisplay.Text = string.Format("{0:F3}", result);
            }

            else
                txtDisplay.Text = result.ToString();
            operand1 = result.ToString();
        }

        public void ExecutePeriod(TextBox txtDisplay)
        {
            txtDisplay.Text = "";
            if (!input.Contains("."))
                input += ".";
            txtDisplay.Text += input;
        }

        public void ExecuteCE(TextBox txtDisplay)
        {
            txtDisplay.Text = "";
            input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty;
        }
        public void ExecuteC(TextBox txtDisplay)
        {
            txtDisplay.Text = "";
            input = string.Empty;
        }
    }
}
