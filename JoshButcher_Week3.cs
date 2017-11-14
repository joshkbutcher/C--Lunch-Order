using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoshButcher_Week3
{
    public partial class Form1 : Form
    {
        double subtotal = 0.0;
        double addOnPrice = 0.0;
        double addOnCount = 0;
        double tax = 0.0;
        double orderTotal = 0.0;

        public Form1()
        {
            InitializeComponent();
            subtotalTB.Text = subtotal.ToString("C");
            taxTB.Text = tax.ToString("C");
            orderTotalTB.Text = orderTotal.ToString("C");
            hamburgerRB.CheckedChanged += new EventHandler(mainCourse_CheckedChanged);
            pizzaRB.CheckedChanged += new EventHandler(mainCourse_CheckedChanged);
            saladRB.CheckedChanged += new EventHandler(mainCourse_CheckedChanged);
            addOnCB1.CheckedChanged += new EventHandler(addOn_CheckedChanged);
            addOnCB2.CheckedChanged += new EventHandler(addOn_CheckedChanged);
            addOnCB3.CheckedChanged += new EventHandler(addOn_CheckedChanged);
        }
        
        public void ClearTotals()
        {
            // Clear all totals and text boxes
            subtotal = 0.0;
            tax = 0.0;
            orderTotal = 0.0;
            addOnCount = 0;
            subtotalTB.Text = subtotal.ToString("C");
            taxTB.Text = tax.ToString("C");
            orderTotalTB.Text = orderTotal.ToString("C");
        }

        public void ClearAddOns()
        {
            // Set all check boxes to false
            addOnCB1.Checked = false;
            addOnCB2.Checked = false;
            addOnCB3.Checked = false;
        }

        public double CalcTax(double sub)
        {
            // Calculate tax (7.75%)
            return sub * .0775;
        }
        
        private void mainCourse_CheckedChanged(object sender, EventArgs e)
        {
            // Check which radio button was clicked
            RadioButton radioButton = sender as RadioButton;

            // Hamburger radio button clicked
            if (hamburgerRB.Checked)
            {
                addOnCB1.Text = "Lettuce, tomato, and onions";
                addOnCB2.Text = "Ketchup, mustard, and mayo";
                addOnCB3.Text = "French fries";
                addOnLabel.Text = "Add-on items ($.75/each)";
                ClearTotals();
                ClearAddOns();
            }

            // Pizza radio button clicked
            else if (pizzaRB.Checked)
            {
                addOnCB1.Text = "Pepperoni";
                addOnCB2.Text = "Sausage";
                addOnCB3.Text = "Olives";
                addOnLabel.Text = "Add-on items ($.50/each)";
                ClearTotals();
                ClearAddOns();
            }

            // Salad radio button clicked
            else if (saladRB.Checked)
            {
                addOnCB1.Text = "Croutons";
                addOnCB2.Text = "Bacon bits";
                addOnCB3.Text = "Bread sticks";
                addOnLabel.Text = "Add-on items ($.25/each)";
                ClearTotals();
                ClearAddOns();
            }
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            // Set prices according to buttons clicked
            if (hamburgerRB.Checked)
            {
                subtotal += 6.95;
                addOnPrice = 0.75;
            }
            else if (pizzaRB.Checked)
            {
                subtotal += 5.95;
                addOnPrice = 0.50;
            } else
            {
                subtotal += 4.95;
                addOnPrice = 0.25;
            }

            if (addOnCB1.Checked)
            {
                addOnCount++;
            }
            if (addOnCB2.Checked)
            {
                addOnCount++;
            }
            if (addOnCB3.Checked)
            {
                addOnCount++;
            }

            // Calculate subtotal and set it to text box
            subtotal += (addOnCount * addOnPrice);
            subtotalTB.Text = subtotal.ToString("C");

            // Call CalcTax method to calculate tax, and set it to text box
            tax = CalcTax(subtotal);
            taxTB.Text = tax.ToString("C");

            // Calculate total and set it to text box
            orderTotalTB.Text = (subtotal + tax).ToString("C");
        }

        // Clear all totals if add-on clicked after totals calculated
        private void addOn_CheckedChanged(object sender, EventArgs e)
        {
            ClearTotals();
        }

       
    }
}
