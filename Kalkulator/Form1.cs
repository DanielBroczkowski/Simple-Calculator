using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            InitializeComponent();
        }


        public static string prevEquation = "", prevOperation = "", operation = "";
        public static double answer = 0;


    private void ButtonsClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btnDel":
                    if (lblDisp.Text.Length > 0)
                    {
                        lblDisp.Text = lblDisp.Text.Substring(0, lblDisp.Text.Length - 1);
                    }
                    break;

                case "btnClear":
                    operation = "";
                    lblDisp.ResetText();
                    lblDisp2.ResetText();
                    break;

                case "btnClearEntry":
                    lblDisp.ResetText();
                    break;

                case "btnDec":
                    if (!lblDisp.Text.Contains("."))
                    {
                        lblDisp.Text += ".";
                    }
                    break;

                case "btnPlusMinus":
                    if (lblDisp.Text.Length > 0)
                    {
                        if (!lblDisp.Text.Contains("-"))
                        {
                            lblDisp.Text = "-" + lblDisp.Text;
                        }
                        else if (lblDisp.Text.Contains("-"))
                        {
                            lblDisp.Text = lblDisp.Text.Substring(1, lblDisp.Text.Length - 1);
                        }
                    }
                    break;

                default:
                    if (operation == "=")
                    {
                        operation = "";
                        //lblDisp.ResetText();
                    }

                    if (lblDisp.Text.Length == 20)
                    {
                        MessageBox.Show("Wpisywane dalej wartości nie mieszczą się na ekranie, przewiń strzałką, aby je podejrzeć!");
                    }

                    lblDisp.Text += btn.Text;
                    break;
            }
        }

        private void OperationClick(object sender, EventArgs e)
        {
            Button opr = sender as Button;

            switch (opr.Text)
            {
                case "+":
                    if (lblDisp.Text.Length > 0)
                    {
                        if (operation == "" || operation == "=")
                        {
                            operation = "+";
                            prevOperation = operation;
                            prevEquation = lblDisp.Text;
                            lblDisp2.Text = prevEquation + operation;
                            lblDisp.ResetText();

                        }
                    }
                    else
                    {
                        operation = "+";
                        MultiEquations();
                    }
                    break;

                case "-":
                    if (lblDisp.Text.Length > 0)
                    {
                        if (operation == "" || operation == "=")
                        {
                            operation = "-";
                            prevOperation = operation;
                            prevEquation = lblDisp.Text;
                            lblDisp2.Text = prevEquation + operation;
                            lblDisp.ResetText();
                        }
                    }
                    else
                    {
                        operation = "-";
                        MultiEquations();
                    }
                    break;

                case "/":
                    if (lblDisp.Text.Length > 0)
                    {
                        if (operation == "" || operation == "=")
                        {
                            operation = "/";
                            prevOperation = operation;
                            prevEquation = lblDisp.Text;
                            lblDisp2.Text = prevEquation + operation;
                            lblDisp.ResetText();
                        }
                    }
                    else
                    {
                        operation = "/";
                        MultiEquations();
                    }
                    break;

                case "x":
                    if (lblDisp.Text.Length > 0)
                    {
                        if (operation == "" || operation == "=")
                        {
                            operation = "x";
                            prevOperation = operation;
                            prevEquation = lblDisp.Text;
                            lblDisp2.Text = prevEquation + operation;
                            lblDisp.ResetText();
                        }
                    }
                    else
                    {
                        operation = "x";
                        MultiEquations();
                    }
                    break;

                case "=":
                    if (lblDisp.Text.Length > 0)
                    {
                        operation = "=";
                        MultiEquations();
                        lblDisp2.ResetText();
                        lblDisp.Text = answer.ToString();
                    }
                    break;

                default:
                    break;
            }
        }

            private void MultiEquations()
            {
                double res;
                if ((!double.TryParse(lblDisp.Text, out res)) || (!double.TryParse(prevEquation, out res)))
                {
                    MessageBox.Show("Podana wartość nie jest liczbą!");
                    lblDisp.ResetText();
                    lblDisp2.ResetText();
                    prevEquation = "0";
                }

            if ((prevOperation == "+") && (lblDisp.Text.Length > 0))
                {
                    prevOperation = operation;
                    answer = Convert.ToDouble(prevEquation) + Convert.ToDouble(lblDisp.Text);
                    prevEquation = answer.ToString();
                    lblDisp2.Text = prevEquation + operation;
                    lblDisp.ResetText();
                }

                else if ((prevOperation == "-") && (lblDisp.Text.Length > 0))
                {
                    prevOperation = operation;
                    answer = Convert.ToDouble(prevEquation) - Convert.ToDouble(lblDisp.Text);
                    prevEquation = answer.ToString();
                    lblDisp2.Text = prevEquation + operation;
                    lblDisp.ResetText();
                }

                else if ((prevOperation == "/") && (lblDisp.Text.Length > 0))
                {

                    if (lblDisp.Text == ".")
                    {
                        lblDisp.ResetText();
                        lblDisp2.ResetText();
                        MessageBox.Show("Nie dziel przez 0, albo będziesz miał te wkurzające okienka!");
                    }

                    else if (Convert.ToDouble(lblDisp.Text) == 0)
                    {
                        lblDisp.ResetText();
                        lblDisp2.ResetText();
                        MessageBox.Show("Nie dziel przez 0, albo będziesz miał te wkurzające okienka!");
                    }

                    else
                    {
                        prevOperation = operation;
                        answer = Convert.ToDouble(prevEquation) / Convert.ToDouble(lblDisp.Text);
                        prevEquation = answer.ToString();
                        lblDisp2.Text = prevEquation + operation;
                        lblDisp.ResetText();
                    }
                }

                else if ((prevOperation == "x") && (lblDisp.Text.Length > 0))
                {
                    prevOperation = operation;
                    answer = Convert.ToDouble(prevEquation) * Convert.ToDouble(lblDisp.Text);
                    prevEquation = answer.ToString();
                    lblDisp2.Text = prevEquation + operation;
                    lblDisp.ResetText();
                }            
        }
    }
}
