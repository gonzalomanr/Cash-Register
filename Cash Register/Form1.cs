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
using System.Media;

namespace Cash_Register
{
    
    public partial class theKebab : Form
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
        double tax = 0;
        double tendered = 0;
        double moneyChange = 0;
        double orderNumber = 0;
        double priceKebabs = 0;
        double priceFries = 0;
        double priceDrinks = 0;

        public theKebab()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            //local variables
            numOfKebabs = Convert.ToInt16(kebabTextBox.Text);
            numOfFries = Convert.ToInt16(friesTextBox.Text);
            numOfDrinks = Convert.ToInt16(drinkTextBox.Text);

            //calculation
            subTotal = numOfKebabs * KEBAB + numOfFries * FRIES + numOfDrinks * DRINK;
            tax = subTotal * TAX;
            total = subTotal * TAX + subTotal;

            calculateLabel.Text = "Sub Total                 " + subTotal.ToString("C");
            calculateLabel.Text += "\nTax                       " + tax.ToString("C");
            calculateLabel.Text += "\nTotal                     " + total.ToString("C");
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Coin_Drop_Willem_Hunt_569197907);
            player.Play();

            //local variables
            tendered = Convert.ToInt32(tenderedTextBox.Text);
            moneyChange = tendered - total ;

            changeLabel2.Text = moneyChange.ToString("C");
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            //local variables
            orderNumber = subTotal + numOfDrinks + numOfKebabs + tendered;
            double priceKebabs = numOfKebabs * KEBAB;
            double priceFries = numOfFries * FRIES;
            double priceDrinks = numOfDrinks * DRINK;

            Refresh();

            //receipt
            Graphics formGraphics = this.CreateGraphics();
            SolidBrush drawBrush = new SolidBrush(Color.White);
            formGraphics.FillRectangle(drawBrush, 405, 30, 320, 420);

            Font drawFont = new Font("Palatino Linotype", 18, FontStyle.Italic);
            drawBrush.Color = Color.Black;
            formGraphics.DrawString("The", drawFont, drawBrush, 510, 42);

            drawFont = new Font("Palatino Linotype", 24, FontStyle.Italic);
            formGraphics.DrawString("Kebab", drawFont, drawBrush, 545, 40);

            Thread.Sleep(1500);

            drawFont = new Font("Prestige Elite Std", 13, FontStyle.Regular);
            formGraphics.DrawString("Order Number", drawFont, drawBrush, 430, 90);
            formGraphics.DrawString(orderNumber.ToString("0000"), drawFont, drawBrush, 590, 90);

            Thread.Sleep(1000);

            SoundPlayer player = new SoundPlayer(Properties.Resources.photocopy_machine_daniel_simon);
            player.Play();

            formGraphics.DrawString("October 14, 2017", drawFont, drawBrush, 430, 110);

            Thread.Sleep(1000);

            formGraphics.DrawString("\nKebabs     x" + numOfKebabs + "\t$" + priceKebabs, drawFont, drawBrush, 430, 130);

            Thread.Sleep(1000);

            formGraphics.DrawString("Fries      x" + numOfFries + "\t$" + priceFries, drawFont, drawBrush, 430, 170);

            Thread.Sleep(1000);

            formGraphics.DrawString("Drinks     x" + numOfDrinks + "\t$" + priceDrinks, drawFont, drawBrush, 430, 190);

            Thread.Sleep(1000);

            formGraphics.DrawString("Subtotal       \t" + subTotal.ToString("C"), drawFont, drawBrush, 430, 230);

            Thread.Sleep(1000);

            formGraphics.DrawString("Tax            \t" + tax.ToString("C"), drawFont, drawBrush, 430, 250);

            Thread.Sleep(1000);

            formGraphics.DrawString("Total          \t" + total.ToString("C"), drawFont, drawBrush, 430, 270);

            Thread.Sleep(1000);

            formGraphics.DrawString("Tendered       \t" + tendered.ToString("C"), drawFont, drawBrush, 430, 310);

            Thread.Sleep(1000);

            formGraphics.DrawString("Change         \t" + moneyChange.ToString("C"), drawFont, drawBrush, 430, 330);

            Thread.Sleep(1000);

            formGraphics.DrawString("Thank you! Have a good day", drawFont, drawBrush, 430, 390);
        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            //new order
            Graphics formGraphics = this.CreateGraphics();
            SolidBrush drawBrush = new SolidBrush(Color.SandyBrown);
            formGraphics.FillRectangle(drawBrush, 405, 30, 320, 440);

            kebabTextBox.Text = "";
            friesTextBox.Text = "";
            drinkTextBox.Text = "";
            calculateLabel.Text = "";
            tenderedTextBox.Text = "";
            changeLabel2.Text = "";

            numOfKebabs = 0;
            numOfFries = 0;
            numOfDrinks = 0;
            subTotal = 0;
            total = 0;
            tax = 0;
            tendered = 0;
            moneyChange = 0;
            orderNumber = 0;
            priceKebabs = 0;
            priceFries = 0;
            priceDrinks = 0;
        }
    }
}
