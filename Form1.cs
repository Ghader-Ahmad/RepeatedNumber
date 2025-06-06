using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RepeatedNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random RandNumber = new Random();

        private int RandomNumber(int From, int To)
        {
            return RandNumber.Next(From, To);
        }

        private bool ValidateNumber(string Input)
        {
            int Number = 0;

            bool isVlidateNumber = int.TryParse(Input, out Number) && Number >= 0;
            
            return isVlidateNumber;
        }

        private bool ValidationInput()
        {
            if (!ValidateNumber(txtAnswer.Text))
            {
                if (string.IsNullOrEmpty(txtAnswer.Text))
                {
                    MessageBox.Show("The input filed must not be empty!", "Note: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    txtAnswer.Text = "";
                    txtAnswer.Focus();
                    return false;
                }

                if (MessageBox.Show("Please Enter A Positive Number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    txtAnswer.Text = "";
                    txtAnswer.Focus();
                    return false;
                }
            }
            return true;
        }

        private string NumberToText(int Number)
        {
            string[] arr = { "", "One", "Two", "Three", "Four", "Five", "Seven", "Eight", "Nine" };

            return arr[Number];
        }

        private void FillMatrixWithRandomNumber(int [,] Matrix , int Rows, int Cols)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Matrix[i, j] = RandomNumber(0, 10);
                }
            }
        }

        private void UpdateControlsAfterClickButtonSet()
        {
            txtAnswer.Enabled = true;
            btnCheck.Enabled = true;
            txtAnswer.Focus();

            lblRepeatNumber.Text = RandomNumber(0, 10).ToString();

            lblRepeatNumber.Visible = true;
            panel2.Visible = true;

            txtAnswer.Text = "";
            lblResult.Text = "";
            lblCorrectResult.Text = "";
        }


        private void Set()
        {
            int[,] Matrix = new int[6, 5];
            FillMatrixWithRandomNumber(Matrix, 6, 5);

            short Count = 1;

            for (int i = 0; i< 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    string labelName = "lbl" + Count;
                    Label lbl = panel2.Controls[labelName] as Label;

                    lbl.Text = Matrix[i, j].ToString();
                    
                    Count++;
                }
            }
            UpdateControlsAfterClickButtonSet();
        }

        void FinalResult(Byte RepeatedNumber)
        {
            if (Convert.ToByte(txtAnswer.Text) == RepeatedNumber)
            {
                lblResult.Text = "Correct : -)";
                lblResult.ForeColor = Color.Blue;
            }

            else
            {
                lblResult.Text = "Wrong : -(";
                lblCorrectResult.Text = "The correct result is : " + NumberToText(RepeatedNumber);
                lblResult.ForeColor = Color.Red;
            }

        }

        private void Check()
        {
            if (!ValidationInput())
            {
                return;
            }

            Byte FindNumber = Convert.ToByte(lblRepeatNumber.Text);
            Byte Count = 1;

            Byte RepeatedNumber = 0;


            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j <5; j++)
                {
                    string labelName = "lbl" + Count;

                    Label lbl = panel2.Controls[labelName] as Label;

                    if (Convert.ToByte(lbl.Text) == FindNumber)
                        RepeatedNumber++;

                    Count++;
                }
            }

            FinalResult(RepeatedNumber);
        }








        private void btnSet_Click(object sender, EventArgs e)
        {
            Set();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Check();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
