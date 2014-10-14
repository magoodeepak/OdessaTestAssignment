using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Odessa.VideoRental.Messages;
using Odessa.VideoRental.BusinessRules;
using Odessa.VideoRental.PersistenceLogic;

namespace Odessa.VideoRental.BusinessLogic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerManagement.svc or CustomerManagement.svc.cs at the Solution Explorer and start debugging.
    public class CustomerManagement : ICustomerManagement
    {
        private const string Invalid_Customer_Name = "Either first name or last name is invalid";
        private const string Movie_Rental_BusinessRuleVoilation = "Business rule voilation";

        public ResponseEnvelope<Customer> RegisterCustomer(Customer customer)
        {
            ResponseEnvelope<Customer> response = new ResponseEnvelope<Customer>();
            if (customer == null)
            {
                ExceptionFaultContract ex = new ExceptionFaultContract();
                ex.Message = "ArgumentNullException";
                ex.Description = "Customer contract is not initialzed.";
                throw new FaultException<ExceptionFaultContract>(ex);
            }
            
            if (!CustomerRegistrationBusinessRule.ValidateCustomer(customer))
            {
                response.ResponseCode = ResponseCodeEnum.ResponseBusinessRuleVoilation;
                response.ResponseMessage = Invalid_Customer_Name;
            }
            else
            {
                RepositoryCustomer rep = new RepositoryCustomer();
                Customer newObject = rep.Save(customer);
                response.ResponseCode = ResponseCodeEnum.ResponseOk;
                response.ResponseMessage = newObject.Id.ToString();
            }


            return response;
        }

        public ResponseEnvelope<Customer> GetAllCustomers()
        {
            RepositoryCustomer rep = new RepositoryCustomer();
            ResponseEnvelope<Customer> response = new ResponseEnvelope<Customer>();
            response.List = rep.FindAll().ToList<Customer>();
            response.ResponseCode = ResponseCodeEnum.ResponseOk;
            return response;
        }
        
        public ResponseEnvelope<MovieRentalItem> RentMovie(MovieRentalItem movieRentalItem)
        {
            ResponseEnvelope<MovieRentalItem> response = new ResponseEnvelope<MovieRentalItem>();
            if (movieRentalItem == null)
            {
                ExceptionFaultContract ex = new ExceptionFaultContract();
                ex.Message = "ArgumentNullException";
                ex.Description = "MovieRentalItem contract is not initialzed.";
                throw new FaultException<ExceptionFaultContract>(ex);
            }

            if (!MovieRentalBusinessRule.ValidateMovieRental(movieRentalItem))
            {
                response.ResponseCode = ResponseCodeEnum.ResponseBusinessRuleVoilation;
                response.ResponseMessage = Movie_Rental_BusinessRuleVoilation;
            }
            else
            {
                RepositoryMovieRental rep = new RepositoryMovieRental();
                //movieRentalItem.Customer.RentalPoints = MovieRentalBusinessRule.ValidateMovieRental(movieRentalItem);
                //Customer newObject = rep.Update(movieRentalItem.Customer);
                MovieRentalItem newObject = rep.Save(movieRentalItem);
                response.ResponseCode = ResponseCodeEnum.ResponseOk;
                response.ResponseMessage = String.Format("Movie {0} is rented with UID {1} to customer {2}"
                    , newObject.Movie.Name, newObject.MovieRentalItemUID, newObject.Customer.UniqueNumber);
                response.List = new List<MovieRentalItem>();
                response.List.Add(newObject);
            }
            
            return response;
        }

        public ResponseEnvelope<MovieRentalItem> ReturnMovie(MovieRentalItem movieRentalItem)
        {
            ResponseEnvelope<MovieRentalItem> response = new ResponseEnvelope<MovieRentalItem>();
            if (movieRentalItem == null)
            {
                ExceptionFaultContract ex = new ExceptionFaultContract();
                ex.Message = "ArgumentNullException";
                ex.Description = "MovieRentalItem contract is not initialzed.";
                throw new FaultException<ExceptionFaultContract>(ex);
            }
                        
            // Update movie return status
            RepositoryMovieRental rep = new RepositoryMovieRental();
            movieRentalItem.ReturnDate = DateTime.Today;
            movieRentalItem.RentalBill = MovieRentalBusinessRule.CalculateRentalBill(movieRentalItem); 
            rep.Update(movieRentalItem);
            
            // Calculate the rental points and update customer object.
            movieRentalItem.RenterPoints = MovieRentalBusinessRule.CalculateRentalPoints(movieRentalItem);
                        
            RepositoryCustomer repCustomer = new RepositoryCustomer();
            repCustomer.Update(movieRentalItem.Customer);

            response.ResponseCode = ResponseCodeEnum.ResponseOk;
            response.ResponseMessage = String.Format("Movie {0} is returned incurring rental points {1}."
                , movieRentalItem.MovieRentalItemUID.ToString(), movieRentalItem.RenterPoints.ToString());
            
            return response;
        }

        public ResponseEnvelope<MovieRentalItem> GenerateBill(Customer customer)
        {
            RepositoryMovieRental rep = new RepositoryMovieRental();
            ResponseEnvelope<MovieRentalItem> response = new ResponseEnvelope<MovieRentalItem>();
            response.List = rep.FindAll().Where(p => p.Customer.UniqueNumber == customer.UniqueNumber).ToList<MovieRentalItem>();
            response.ResponseCode = ResponseCodeEnum.ResponseOk;
            return response;
        }

    }
}
