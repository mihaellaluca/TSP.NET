using System;
using System.Windows.Forms;

namespace calculator
{
	public partial class Form1 : Form
	{
        private double firstNumber;
        private string operation;

        public Form1()
		{
			InitializeComponent();
		}

		private void equal_Click(object sender, EventArgs e)
		{
            double secondNumber;
            double result;
            var inputText = input.Text;
            secondNumber = Convert.ToDouble(inputText.ToString());

            switch(operation)
            {
                case "+":
                    result = (firstNumber + secondNumber);
                    input.Text = result.ToString();
                    firstNumber = result;
                    break;
                case "-":
                    result = (firstNumber - secondNumber);
                    input.Text = result.ToString();
                    firstNumber = result;
                    break;
                case "*":
                    result = (firstNumber * secondNumber);
                    input.Text = result.ToString();
                    firstNumber = result;
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        input.Text = "Divide by zero error!";
                    }
                    else
                    {
                        result = (firstNumber / secondNumber);
                        input.Text = result.ToString();
                        firstNumber = result;
                    }
                    break;
                default:
                    break;
            }
        }

        // OPERATIONS:
        private void multiply_Click(object sender, EventArgs e)
        {
            firstNumber = Convert.ToDouble(input.Text);
            input.Text = "";
            operation = "*";
            input.Focus();
        }

        private void divide_Click(object sender, EventArgs e)
        {
            firstNumber = Convert.ToDouble(input.Text);
            input.Text = "";
            operation = "/";
            input.Focus();
        }

        private void add_Click(object sender, EventArgs e)
        {
            firstNumber = Convert.ToDouble(input.Text);
            input.Text = "";
            operation = "+";
            input.Focus();
        }

        private void substract_Click(object sender, EventArgs e)
        {
            firstNumber = Convert.ToDouble(input.Text);
            input.Text = "";
            operation = "-";
            input.Focus();
        }
        //other operations
        private void CEButton_Click(object sender, EventArgs e)
        {
            input.Text = "";

        }
        private void del_Click(object sender, EventArgs e)
        {
            if (input.Text.Length >= input.SelectionStart + 1)
                input.Text.Remove(input.SelectionStart, 1);
        }

        private void dot_Click(object sender, EventArgs e)
        {
            input.Text = input.Text.Insert(input.SelectionStart, ",");
            input.Focus();

        }

        //NUMBERS:
        private void zero_Click(object sender, EventArgs e)
        {
            input.Text = input.Text.Insert(input.SelectionStart, "0");
            input.Focus();
        }

        private void one_Click(object sender, EventArgs e)
        {
            input.Text = input.Text.Insert(input.SelectionStart, "1");
            input.Focus();
        }

        private void two_Click(object sender, EventArgs e)
        {
            input.Text = input.Text.Insert(input.SelectionStart, "2");
            input.Focus();
        }

        private void three_Click(object sender, EventArgs e)
        {
            input.Text = input.Text.Insert(input.SelectionStart, "3");
            input.Focus();
        }

        private void four_Click(object sender, EventArgs e)
        {
            input.Text= input.Text.Insert(input.SelectionStart, "4");
            input.Focus();
        }

        private void five_Click(object sender, EventArgs e)
        {
            input.Text= input.Text.Insert(input.SelectionStart, "5");
            input.Focus();
        }

        private void six_Click(object sender, EventArgs e)
        {
            input.Text = input.Text.Insert(input.SelectionStart, "6");
            input.Focus();
        }
        private void seven_Click(object sender, EventArgs e)
        {
            input.Text = input.Text.Insert(input.SelectionStart, "7");
            input.Focus();
        }

        private void eight_Click(object sender, EventArgs e)
        {
            input.Text= input.Text.Insert(input.SelectionStart, "8");
            input.Focus();
        }

        private void nine_Click(object sender, EventArgs e)
        {
            input.Text= input.Text.Insert(input.SelectionStart, "9");
            input.Focus();
        }

       
    }
}
