using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents what the prize is for the given place
    /// </summary>
    public class PrizeModel
    {
        /// <summary>
        /// The unique identifier for the prize.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The numeric identifier for te place (2 for second place, etc..)
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// The friendly name for the place (second place, first runner up, etc.)
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// The prize amount this place earns or zero if it is not used.
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// The number that represents the percentage of the overall take or
        /// zero if it is not used. The percentage is a fraction of 1 (so 0.5
        /// for 50%).
        /// </summary>
        public double PrizePercentage { get; set; }

        // create Construtor1
        public PrizeModel()
        {

        }

        // create constructor 2
        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizepercentage)
        {
            // PlaceName needs to be a string
            PlaceName = placeName;

            // PlaceNumber needs to be a int - conversion required
            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            // PrizeAmount needs to be a decimal - conversion required
            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            // PrizePercentage needs to be a double - conversion required
            double prizePercentageValue = 0;
            double.TryParse(prizepercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }
    }
}
