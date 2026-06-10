using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiplicationTables
{
    public partial class MultiplicationTables : Form
    {
        public MultiplicationTables()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            // clearing any previous output
            txtOutput.Clear();

            // parse inputs
            if (int.TryParse(txtNumber.Text, out int number) &&
                int.TryParse(txtStart.Text, out int start) &&
                int.TryParse(txtFinish.Text, out int finish))
            {
                // ensure start <= finish
                if (start > finish)
                {
                    int temp = start;
                    start = finish;
                    finish = temp;
                }

                // produce multiplication lines using the loop variable for the left-hand operand
                if (chkReverse.Checked)
                {
                    for (int i = finish; i >= start; i--)
                    {
                        txtOutput.AppendText($"{i} x {number} = {i * number}{Environment.NewLine}");
                    }
                }
                else
                {
                    for (int i = start; i <= finish; i++)
                    {
                        txtOutput.AppendText($"{i} x {number} = {i * number}{Environment.NewLine}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter valid integers for Number, Start and Finish.");
            }
        }
    }
}

