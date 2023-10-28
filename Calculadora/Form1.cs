using System.Buffers;
using System.Diagnostics;
using System.Drawing.Text;
using System.Globalization;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        List<Button> buttons;
        List<Button> operations;
        private double value;
        private string operation;
        CultureInfo culturaBrasileira;
        public Form1()
        {
            InitializeComponent();
            culturaBrasileira = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = culturaBrasileira;
            buttons = new List<Button> { btnZero, btnOne, btnTwo, btnTree, btnFour, btnFive, btnSix, btnSeven, btnEight, btnNine };
            foreach (Button button in buttons)
            {
                button.Click += writeNumber;
            }
            operations = new List<Button> { btnMult, btnSum, btnSub, btnDiv };
            foreach (Button operation in operations)
            {
                operation.Click += writeOperation;
            }
            btnClean.Click += (object sender, EventArgs e) =>
            {
                txtResult.Text = string.Empty;
                txtCalc.Text = string.Empty;
            };
            btnEqual.Click += (object sender, EventArgs e) =>
            {
                if (txtCalc.Text != string.Empty)
                {
                    Debug.WriteLine("teste: " + operation);
                    if (operation == "+")
                    {
                        //Debug.WriteLine("teste: " + Convert.ToDouble(value));
                        double total = Convert.ToDouble(value) + Convert.ToDouble(txtResult.Text);
                        txtResult.Text = total.ToString("N2", culturaBrasileira);
                    }else if (operation == "-")
                    {
                        double total = Convert.ToDouble(value) - Convert.ToDouble(txtResult.Text);
                        txtResult.Text = total.ToString("N2", culturaBrasileira);
                    }
                    else if(operation == "x")
                    {
                        double total = Convert.ToDouble(value) * Convert.ToDouble(txtResult.Text);
                        txtResult.Text = total.ToString("N2", culturaBrasileira);
                    }
                    else if(operation== "/")
                    {
                        double total = Convert.ToDouble(value) / Convert.ToDouble(txtResult.Text);
                        txtResult.Text = total.ToString("N2", culturaBrasileira);
                    }

                    txtCalc.Text = string.Empty;
                }

            };
            btnDot.Click += (object sender, EventArgs e) =>
            {

            };
        }

        private void BtnEqual_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void writeNumber(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            txtResult.Text += btn.Text;
            
        }
        private void writeOperation(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (!txtResult.Text.ToString().EndsWith(" ", StringComparison.OrdinalIgnoreCase))
            {
                switch (btn.Text)
                {
                    case "+":
                        operation = "+";
                        break;

                    case "-":
                        operation = "-";
                        break;

                    case "x":
                        operation = "x";
                        break;

                    case "/":
                        operation = "/";
                        break;
                }
                value = Convert.ToDouble(txtResult.Text);
                txtCalc.Text = value.ToString("N2",culturaBrasileira) + " " + btn.Text + " ";
                txtResult.Text = "";
            }
        }
        

    }
}