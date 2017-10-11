using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Cash_Register
{
    
    public partial class Form1 : Form
    {
        //global constants
        const double KEBAB = 2.49;
        const double FRIES = 1.89;
        const double DRINK = 0.99;
        const double TAX = 0.13;

        //global variables
        int numOfKebabs = 0;
        int numOfFries = 0;
        int numOfDrinks = 0;
        double subTotal = 0;
        double total = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            //double kebabTextBox.Text;
            numOfKebabs = Convert.ToInt16(kebabTextBox.Text);
            numOfFries = Convert.ToInt16(friesTextBox.Text);
            numOfDrinks = Convert.ToInt16(drinkTextBox.Text);

            //calculation
            double subTotal = numOfKebabs * KEBAB + numOfFries * FRIES + numOfDrinks * DRINK;
            double tax = subTotal * TAX;
            double total = subTotal * TAX + subTotal;

            calculateLabel.Text = "Sub Total                 " + subTotal.ToString("C");
            calculateLabel.Text += "\nTax                       " + tax.ToString("C");
            calculateLabel.Text += "\nTotal                     " + total.ToString("C");
        }

        private void printButton_Click(object sender, EventArgs e)
        {


            //formGraphics.Clear(Color.Black);

            //prizeLabel.Visible = false;

            //titleColorLabel.Visible = false;
            //titleLabel.Visible = false;
           // myName.Visible = false;

            //kebabLabel.Visible = false;
            //kebabPrizeLabel.Visible = false;
            //kebabTextBox.Visible = false;

            //drinkLabel.Visible = false;
            //drinkPrizeLabel.Visible = false;
            //drinkTextBox.Visible = false;

            //friesLabel.Visible = false;
            //friesPrizeLabel.Visible = false;
            //friesTextBox.Visible = false;

            //calculateButton.Visible = false;
            //calculateLabel.Visible = false;

            //blackLabel.Visible = false;

            //tenderedLabel.Visible = false;
            //tenderedTextBox.Visible = false;

            //printButton.Visible = false;

            Refresh();

            Graphics formGraphics = this.CreateGraphics();
            SolidBrush drawBrush = new SolidBrush(Color.White);
            formGraphics.FillRectangle(drawBrush, 400, 30, 320, 400);

            Font drawFont = new Font("Palatino Linotype", 14, FontStyle.Italic);
            drawBrush.Color = Color.Black;
            //formGraphics.TranslateTransform(430, 40);
            formGraphics.DrawString("The", drawFont, drawBrush, 480, 42);

            drawFont = new Font("Palatino Linotype", 20, FontStyle.Italic);
            formGraphics.DrawString("Kebab", drawFont, drawBrush, 505, 40);


        }
    }
}
