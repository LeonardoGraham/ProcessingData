using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessingData
{
    public partial class vehiclePriceCalc : Form
    {
        private double stereoSystem = 425.76;
        private double leatherInterior = 987.41;
        private double computerNavigation = 1741.23;
        private double pearlize = 345.72;
        private double customizedDetailing = 599.99;
        private double taxRate = 0.08;
        public vehiclePriceCalc()
        {
            InitializeComponent();
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double subTotal = CalculateSubTotal();
            double total = CalculateTotal(subTotal);
            double totalDue = CalculateTotalDue(total);

            subtotalLabel.Text += subTotal.ToString("C");
            totalLabel.Text += total.ToString("C");
            amountDueLabel.Text += totalDue.ToString("C");
        }
        private double CalculateSubTotal()
        {
            double subTotal = Convert.ToDouble(basePriceTextBox.Text);

            if (stereoSystemCheckBox.Checked)
            {
                subTotal += stereoSystem;
            }
            if (leatherInterionCheckBox.Checked)
            {
                subTotal += leatherInterior;
            }
            if (computerNavigationCheckBox.Checked)
            {
                subTotal += computerNavigation;
            }
            if (PearlizeCheckBox.Checked)
            {
                subTotal += pearlize;
            }
            if (customizedDetailingCheckBox.Checked)
            {
                subTotal += customizedDetailing;
            }

            return subTotal;
        }
        private double CalculateTotal(double subTotal)
        {
            return subTotal + (subTotal * taxRate);
        }
        private double CalculateTotalDue(double total)
        {
            double tradeIn = Convert.ToDouble(tradeInTextBox.Text);
            return total - tradeIn;
        }

        private void basePriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tradeInTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            basePriceTextBox.Text = "0";
            tradeInTextBox.Text = "0";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Calculates price due when purchasing a vehicle.");
        }
    }
}
