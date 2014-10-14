
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odessa.VideoRental.Messages;
using System.Configuration;

namespace Odessa.VideoRental.BusinessRules
{
    public static class MovieRentalBusinessRule
    {
        /// <summary>
        /// Validation rules to be applied before update or saving an object
        /// </summary>
        /// <param name="item">Object to be saved or updated</param>
        /// <returns>Returns true if no business rule voilation else false</returns>
        public static bool ValidateMovieRental(MovieRentalItem item)
        {
            return true;
        }

        /// <summary>
        /// Calculates rental points
        /// </summary>
        /// <param name="item">MovieRentalItem to be calculated</param>
        /// <returns>Returns the number of points</returns>
        public static int CalculateRentalPoints(MovieRentalItem item)
        {
            return item.Movie.Category == MovieCategoryEnum.New ? Convert.ToInt16(item.ReturnDate.Subtract(item.RentedDate).TotalDays) * 1 : 1;
        }

        /// <summary>
        /// Calculates rental points
        /// </summary>
        /// <param name="item">MovieRentalItem to be calculated</param>
        /// <returns>Returns the number of points</returns>
        public static double CalculateRentalBill(MovieRentalItem item)
        {
            double baseRate_New = Convert.ToDouble(ConfigurationManager.AppSettings["BaseRateForNewMovie"]);
            double baseRate_Regular = Convert.ToDouble(ConfigurationManager.AppSettings["BaseRateForRegularMovie"]);
            double baseRate_Kid = Convert.ToDouble(ConfigurationManager.AppSettings["BaseRateForKidMovie"]);

            int rentalDays = 0;
            double rentialBill = 0;

            rentalDays = Convert.ToInt16(item.ReturnDate.Subtract(item.RentedDate).TotalDays);
            if (item.Movie.Category == MovieCategoryEnum.New)
            {
                rentialBill = Convert.ToInt16(item.ReturnDate.Subtract(item.RentedDate).TotalDays) * baseRate_New;
            }
            else if (item.Movie.Category == MovieCategoryEnum.Kids)
            {
                rentialBill = ((rentalDays/3) * baseRate_Kid * 3) + ((rentalDays % 3) * (baseRate_Kid * 1.5));
            }
            else
            {
                rentialBill = ((rentalDays/2) * baseRate_Regular * 2) + ((rentalDays % 2) * (baseRate_Regular * 1.5));
            }
            return rentialBill;
        } 

    }
}
