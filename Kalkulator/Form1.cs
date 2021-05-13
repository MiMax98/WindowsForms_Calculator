using System;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        private string _first;
        private string _second;
        private char? _operation;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PushNumber("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PushNumber("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PushNumber("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PushNumber("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PushNumber("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PushNumber("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PushNumber("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PushNumber("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PushNumber("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            PushNumber("0");
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            PushNumber(",");
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            PushOperation('+');
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_first))
            {
                PushNumber("-");
            }
            else
            {
                PushOperation('-');
            }
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            PushOperation('*');
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            PushOperation('/');
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _first = null;
            _second = null;
            _operation = null;
            Display();
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            Compute();
        }

        private void PushOperation(char operation)
        {
            if(_operation.HasValue)
            {
                Compute();
            }
            _operation = operation;
            Display();
        }

        private void Compute()
        {
            if (!_operation.HasValue)
            {
                return;
            }
            if(!double.TryParse(_first, out double fst))
            {
                DisplayError();
                return;
            }
            if (!double.TryParse(_second, out double snd))
            {
                DisplayError();
                return;
            }
            switch (_operation.Value)
            {
                case '+':
                    SetResult(fst + snd);
                    Display();
                    break;
                case '-':
                    SetResult(fst - snd);
                    Display();
                    break;
                case '*':
                    SetResult(fst * snd);
                    Display();
                    break;
                case '/':
                    SetResult(fst / snd);
                    Display();
                    break;
                default:
                    DisplayError();
                    break;
            }
        }

        private void SetResult(double result)
        {
            _first = result.ToString();
            _second = null;
            _operation = null;
        }

        private void DisplayError()
        {
            _first = null;
            _second = null;
            _operation = null;
            textBox1.Text = "Wystąpił błąd";
        }

        private void PushNumber(string symbol)
        {
            if (_operation.HasValue)
            {
                _second = $"{_second}{symbol}";
            }
            else
            {
                _first = $"{_first}{symbol}";
            }
            Display();
        }

        private void Display()
        {
            var operation = _operation.HasValue ? _operation.Value.ToString() : string.Empty;
            textBox1.Text = $"{_first} {operation} {_second}";
        }
    }
}
