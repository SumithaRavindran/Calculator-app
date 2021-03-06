﻿using System;
using System.Windows.Controls;

namespace CalculatorApp
{
    /*
    * This class contains the business logic for the calculator app.
    */
    public class CalculatorOrchestrator
    {
        public string input = string.Empty;
        public string operand1 = string.Empty;
        public string operand2 = string.Empty;
        public char operation;
        double result = 0.0;
        private static bool isContinue = false;
        private string prevResult = string.Empty;

        /*
        * This method updates the given number
        */
        public void UpdateNumberToSystem(TextBox txtDisplay,  string number)
        {
            if (isContinue)
            {
                input = string.Empty;
                isContinue = false;
            }
            txtDisplay.Text = "";
            input += number;
            txtDisplay.Text += input;
        }

        /*
        * This method changes the sign for the input digit
        */
        public void ChangeSign(TextBox txtDisplay)
        {
            double.TryParse(input, out double num1);
            num1 *= -1;
            txtDisplay.Text = input = num1.ToString();
        }

        /*
        * This method contains the mathematical operator
        */
        public void UpdateOperation(TextBox txtDisplay, Operator op)
        {
            txtDisplay.Text = "";
            operand1 = input;
            this.operation = Convert.ToChar(op);
            input = string.Empty;
            txtDisplay.Text += input;
            isContinue = false;
        }

        /*
        * This method computes the result
        */
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
            input = result.ToString();
            isContinue = true;
           
        }

        /*
        * This method adds the decimal point
        */
        public void ExecutePeriod(TextBox txtDisplay)
        {
            txtDisplay.Text = "";
            if (!input.Contains("."))
                input += ".";
            txtDisplay.Text += input;
        }

        /*
         * This method handles the global clear
        */
        public void ExecuteCE(TextBox txtDisplay)
        {
            txtDisplay.Text = "";
            input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty;
        }

        /*
        * This method handles the local clear
        */
        public void ExecuteC(TextBox txtDisplay)
        {
            txtDisplay.Text = "";
            input = string.Empty;
        }
    }
}
