using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Odessa.VideoRental.Messages;

namespace Odessa.VideoRental.BusinessLogic
{
    [ServiceContract]
    public interface ICustomerManagement
    {
        /// <summary>
        /// Registers a customer and assign a unique identification string
        /// </summary>
        /// <param name="customer">Customer object/DTO</param>
        /// <returns>Returns response object having newly constructed customer object</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        ResponseEnvelope<Customer> RegisterCustomer(Customer customer);

        /// <summary>
        /// Get the list of all customers
        /// </summary>
        /// <returns>Returns response object having list of customer objects</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        ResponseEnvelope<Customer> GetAllCustomers();

        /// <summary>
        /// Rents a movie
        /// </summary>
        /// <returns>Returns response object having newly constructed RentalItem object</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        ResponseEnvelope<MovieRentalItem> RentMovie(MovieRentalItem item);

        /// <summary>
        /// Return a movie and update the rental history
        /// </summary>
        /// <returns>Returns response object having newly constructed RentalItem object</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        ResponseEnvelope<MovieRentalItem> ReturnMovie(MovieRentalItem item);

        /// <summary>
        /// Genereates bill for all movies rented by a customer
        /// </summary>
        /// <param name="customer">Customer object/DTO for whom billing data needs to be generated</param>
        /// <returns>Returns response object having list of RentalItem object for billing data</returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        ResponseEnvelope<MovieRentalItem> GenerateBill(Customer customer);
    }
}
