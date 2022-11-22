using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Kang Hyun Kwon october 20th 2022 

        //totalPayments and interestRate declared as doubles, years as integers, name as string
        double totalPayments = 0;
        const int MINYEARS = 5;
        const string NAME = "John";        

        //help picture
        private void picHelp_Click(object sender, EventArgs e)
        {
          
            //variable initialized + call constant minYears and interestRate (from label) and add a string "%"  
            string lblHelpMessage = "This program reads in 2 numbers: \n " +
                "\tFuture Value: amount of \"$\" \n \tYears: must be at least "
                + MINYEARS +"\n and calculates payments based on: \n\t Yearly " +
                "insterest rate of "+ lblRatePerYear.Text +"%";

            //use the string variable and const name instead of typing the text
            MessageBox.Show(lblHelpMessage, NAME);

        }
        //click Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            //string variable initialized and bring totalPayments variable converted to string(currency)
            string messageClick = "Thanks for using the program! \n If you want to support us send an email to : xxx@xxxx.ca " +
                "Total payments= " + totalPayments.ToString("c");
            //use variable and const instead of typing the text
            MessageBox.Show(messageClick, NAME);
            //Close the program
            this.Close();
        }
        //function created called ResetAll
        private void ResetAll()
        //hide, clear and put cursor on txtFuture Value
        {
            grpSolution.Visible=false;
            txtFutureValue.ResetText();
            txtYears.ResetText();
            lblMonthlyPayments.Text="";
            txtFutureValue.Focus();
        }

        //click Reset button event
        private void btnReset_Click(object sender, EventArgs e)
        {
            //bring the function created ResetAll
            ResetAll();
        }
        //form load event
            //bring the function created ResetAll
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetAll();
        }

        //calculate button event
        private void btnCalculate_Click(object sender, EventArgs e)
        {

            try
            {

                int numberOfYears = Convert.ToInt32(txtYears.Text);
                

                //validade the number of years first
                if (numberOfYears < MINYEARS)
                {                    
                    MessageBox.Show("Years must be at least "+MINYEARS+".", NAME);
                    txtYears.ResetText();
                    txtYears.Focus();
                }
               
                else
                {
                    //var futureValue will grab the input from txtFutureValue
                    double futureValue = Convert.ToDouble(txtFutureValue.Text);
                    //convert the txt value from label to double ( use in the formula)
                    double interestRate = Convert.ToDouble(lblRatePerYear.Text);
                    //to get monthly payments we divite totalPayment by number of months (years*12)
                    double monthlyPayments = (futureValue * interestRate/(12*100))/
                           (Math.Pow((1 + interestRate/(12*100)), numberOfYears*12)-1);

                    //convert monthlyPayment(double) to string(currency)
                    lblMonthlyPayments.Text = monthlyPayments.ToString("c");

                    //totalPayments is monthlyPayments * (number of years *12)
                    totalPayments += monthlyPayments*(numberOfYears*12);

                    //show the grsSolution after calculation
                    grpSolution.Visible = true;

                }
            }

            catch (Exception)
            {
                //if the exception input does not satisfy the condition , show the following message, clear and put cursor on txtFutureValue
                MessageBox.Show("Message encountered:\n Input string was not in a correct format.", NAME);
                txtFutureValue.ResetText();
                txtYears.ResetText();
                txtFutureValue.Focus();

            }
           

          

        }
    }
}
        
