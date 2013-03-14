/*
 * Homework #4 Christopher's Car Rental
 * Last modified: 3/11/13 11:59 p.m. 
 * Name: Eric Tran
 * ID: 006481291
 * Course: IS340-01
 * Time: TuTh 11 a.m.
 * 
 * Description: This program is designed for a car purchasing purposes.  The user has two text boxes to 
 *              enter information about their car sales price and trade-in allowance while all other text 
 *              boxes are disabled.  Input to the Car Sales Price text box is mandatory for the program 
 *              to run, but not mandatory for the Trade-in Allowance text box because by default the 
 *              trade-in allowance is set to zero.  An error message will appear if the characters entered 
 *              are not numerical and the program will send the insertion point back to the Car Sales 
 *              Price text box.
 *              
 *              The Accessories group box contains three check boxes for the user to select.  Those check 
 *              boxes are Stereo System (425.76), Leather Interior (987.41), and Computer Navigation 
 *              (1,741.23).  By default, these check boxes are unchecked.
 *              
 *              The Exterior Finish group box contains three radio buttons for the user to select.  Those 
 *              radio buttons are Standard (no additional charge), Pearlized (345.72), and Customized 
 *              Detailing (599.99).  By default, the Standard radio button is already enabled at the start 
 *              of the program.
 *              
 *              The Calculate button will compute all the prices and display the Amount Due at the bottom.
 *              First the program takes the Car Sales Price and adds it to the Accessories Finish (totaled 
 *              from the Accessories group box and the Exterior Finish group box) and return a Subtotal 
 *              for display.  Then a Sales Tax of 8% will be calculated and displayed in its own text box.
 *              The Total is the combined price of the Subtotal and Sales Tax.  Then finally the Trade-In 
 *              Allowance is subtracted from the Total and the result is displayed in the Amount Due text 
 *              box.  The Calculate button is also set as the form’s Accept button.
 *              
 *              The Clear button erases all of the text boxes, resets the trade-in allowance to zero, 
 *              unchecks all the check boxes, and sets the Standard Exterior Finish radio button to enable.
 *              The Clear button is also set as the form’s Cancel button.
 *              
 *              The Summary Button will pop up a window showing the number of transactions, total car 
 *              sales, and total trade-in allowance.  It will also ask if the user would like to restart 
 *              the form or not.
 *              
 *              The Menu strip has three sections: File, Edit, and Help.  Under the File menu there is an 
 *              option for Exit.  Under the Edit menu there are the options Calculate, Clear, Summary, 
 *              Font, and Color.  Under the Help menu is the About section.
 *              
 *              The Font option allows the user to make font changes to the Amount Due textbox.
 *              
 *              The Color option allows the user to select a color for the forms ForeColor.  
 *              
 *              The program has access keys for every option in the group boxes, the buttons, the menu 
 *              strip and the menu strip options.
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hw4EricTran
{
    public partial class christophersCarCenterForm : Form
    {
        //Initialize Variables and Constants
        private const decimal STEREO_SYSTEM_DECIMAL = 425.76M;
        private const decimal LEATHER_INTERIOR_DECIMAL = 987.41M;
        private const decimal COMPUTER_NAVIGATION_DECIMAL = 1741.23M;
        private const decimal PEARLIZED_DECIMAL = 345.72M;
        private const decimal CUSTOMIZED_DETAILING_DECIMAL = 599.99M;
        private const decimal TAX_RATE_DECIMAL = 0.08M;
        private int totalTransactions = 0;
        private decimal totalCharge = 0M;
        private decimal totalTradeInAllowanceDecimal = 0M;
        private decimal defaultTradeInAllowanceDecimal = 0M;

        public christophersCarCenterForm()
        {
            InitializeComponent();
        }

        private void christophersCarCenterForm_Load(object sender, EventArgs e)
        { 
            //Set the Trade-in Allowance to its deafault value and display in corresponding text box
            tradeInAllowanceTextBox.Text = defaultTradeInAllowanceDecimal.ToString("N2");

            //Start application with the clear button disabled
            clearButton.Enabled = false;
        }
        
        private void calculateButton_Click(object sender, EventArgs e)
        {
            //Initialize Variables
            decimal carSalesPriceDecimal;
            decimal accessoriesFinishDecimal = 0;
            decimal subtotalDecimal = 0;
            decimal salesTaxDecimal = 0;
            decimal totalDecimal = 0;
            decimal tradeInAllowanceDecimal = 0;
            decimal amountDueDecimal = 0;
            
            //Accessories Check Boxes
            if (stereoSystemCheckBox.Checked)
            {
                //Adds the Stereo System constant to the accessories variable
                accessoriesFinishDecimal += STEREO_SYSTEM_DECIMAL;
            }

            if (leatherInteriorCheckBox.Checked)
            {
                //Adds the Leather Interior constant to the accessories variable
                accessoriesFinishDecimal += LEATHER_INTERIOR_DECIMAL;
            }

            if (computerNavigationCheckBox.Checked)
            {
                //Adds the Computer Navigation constant to the accessories variable
                accessoriesFinishDecimal += COMPUTER_NAVIGATION_DECIMAL;
            }

            //Exterior Finish Check Boxes
            if (pearlizedRadioButton.Checked)
            {
                //Adds the Pearlized constant to the accessories variable
                accessoriesFinishDecimal += PEARLIZED_DECIMAL;
            }

            else if (customizedDetailingRadioButton.Checked)
            {
                //Adds the Customized Detailing constant to the accessories variable
                accessoriesFinishDecimal += CUSTOMIZED_DETAILING_DECIMAL;
            }

            try
            {
                if (carSalesPriceTextBox.Text != "")
                {
                    //Takes the input from carSalesPriceTextBox and assigns the value to variable
                    carSalesPriceDecimal = decimal.Parse(carSalesPriceTextBox.Text);

                    //Displays the Accessories Finished value
                    accessoriesFinishTextBox.Text = accessoriesFinishDecimal.ToString("C2");

                    //Calculates the Subtotal
                    subtotalDecimal = carSalesPriceDecimal + accessoriesFinishDecimal;
                    subtotalTextBox.Text = subtotalDecimal.ToString("C2");

                    //Calculates the Sales Tax
                    salesTaxDecimal = subtotalDecimal * TAX_RATE_DECIMAL;
                    salesTaxTextBox.Text = salesTaxDecimal.ToString("C2");

                    //Calculates the Total
                    totalDecimal = subtotalDecimal + salesTaxDecimal;
                    totalTextBox.Text = totalDecimal.ToString("C2");

                    //Calculates the total Trade-in Allowance
                    tradeInAllowanceDecimal = decimal.Parse(tradeInAllowanceTextBox.Text);
                    totalTradeInAllowanceDecimal += tradeInAllowanceDecimal;

                    //Calculates the Amount Due
                    amountDueDecimal = totalDecimal - tradeInAllowanceDecimal;
                    amountDueTextBox.Text = amountDueDecimal.ToString("C2");

                    //Increments the totalTranactions by 1
                    totalTransactions++;
                    
                    //Adds amount due to the totalCharge
                    totalCharge += amountDueDecimal;

                    //Disables the Calculate buttona and enables the Clear button
                    calculateButton.Enabled = false;
                    clearButton.Enabled = true;
                }

                else
                {
                    //Error Message for when a no input is made
                    MessageBox.Show("Please input Car Sale Price!", "Missing Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                    //Sets the insertion pont to the Car Sales Price text box
                    carSalesPriceTextBox.Focus();
                }
            }

            catch
            {
                //Error message when a non-numerical data is entered
                MessageBox.Show("Enter numeric data", "Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                //Sets insertion point to the Car Sales Price text box and highlights its contents
                carSalesPriceTextBox.Focus();
                carSalesPriceTextBox.SelectAll();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //Clears all text boxes
            carSalesPriceTextBox.Clear();
            accessoriesFinishTextBox.Clear();
            subtotalTextBox.Clear();
            salesTaxTextBox.Clear();
            totalTextBox.Clear();
            tradeInAllowanceTextBox.Clear();
            amountDueTextBox.Clear();

            //Sets the trade-in value to zero
            defaultTradeInAllowanceDecimal = 0;
            tradeInAllowanceTextBox.Text = defaultTradeInAllowanceDecimal.ToString("N2");

            //Sets all check boxes to false
            stereoSystemCheckBox.Checked = false;
            leatherInteriorCheckBox.Checked = false;
            computerNavigationCheckBox.Checked = false;

            //Sets Standard radio button to true, other radio buttons to false
            standardRadioButton.Checked = true;
            pearlizedRadioButton.Checked = false;
            customizedDetailingRadioButton.Checked = false;

            //Places insertion point at starting text box
            carSalesPriceTextBox.Focus();

            //Enable the calculate button and disable the clear button
            calculateButton.Enabled = true;
            clearButton.Enabled = false;
        }

        private void summaryButton_Click(object sender, EventArgs e)
        {
            //
            DialogResult whichButtonDialogResult;

            //Shows text and data for Summary
            whichButtonDialogResult = MessageBox.Show("The summary information for Christopher's Car Center"
                + "\n" + "\n" + "Total number of transations: " + totalTransactions.ToString("N0")
                + "\n" + "Total Charges: " + totalCharge.ToString("C2")
                + "\n" + "Total Trade-in Allowance: " + totalTradeInAllowanceDecimal.ToString("C2")
                + "\n" + "\n" + "Do you want to reset the form?", "Summary", MessageBoxButtons.YesNo);
            
            //
            if (whichButtonDialogResult == DialogResult.Yes)
            {
                //Resets the totalTransactions and totalCharge variables to zero
                totalTransactions = 0;
                totalCharge = 0;
                totalTradeInAllowanceDecimal = 0;
                
                //Calls the clearButton method
                clearButton_Click(sender, e);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Exits the application
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Calls the exitButton method
            exitButton_Click(sender, e);
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Calls the calculateButton method
            calculateButton_Click(sender, e);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Calls the clearButton method
            clearButton_Click(sender, e);
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Calls the summaryButton method
            summaryButton_Click(sender, e);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Allows font changes to the Amount Due text box
            fontDialog.ShowDialog();
            amountDueTextBox.Font = fontDialog.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Allows color change to the form's ForeColor
            colorDialog.ShowDialog();
            this.ForeColor = colorDialog.Color;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //About section for the program
            MessageBox.Show("Programmed by Eric Tran"
                + "\n" + "Copyright 2013, CSULB" + " " + "Christopher's Car Center");
        }
    }
}
