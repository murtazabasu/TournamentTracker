﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void prizePercentageLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                // can try TryParse or: create a constructor in PrizeModel
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text,
                    placeNumberValue.Text,
                    prizeAmountValue.Text,
                    prizePercentageValue.Text);

                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }
            }
        }
        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placeNumber);
            // The try parse method takes the string from the 
            // text box (since it is a "text box") and tries
            // to convert it into a string. 
            // the converted it sends "out" into "placeNumber" var
            // and it also returns a bool if the parse was successful or not.
            
            // For the placeNumber Text
            if (!placeNumberValidNumber) 
            {
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;
            }

            // For the placeName Text
            if (placeNameValue.Text.Length == 0) // when there is not text entered.
            {
                output = false;
            }

            // For the prize Amount and percentage Text
            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out prizePercentage);

            if (!prizeAmountValid || !prizePercentageValid)
            {
                output = false;
            }

            if (prizeAmount <=0 && prizePercentage <= 0)
            {
                output = false;
            }

            if (prizePercentage <0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }
    }
}
