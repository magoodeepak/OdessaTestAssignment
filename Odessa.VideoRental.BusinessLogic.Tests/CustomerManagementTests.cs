using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odessa.VideoRental.BusinessLogic;
using Odessa.VideoRental.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace Odessa.VideoRental.BusinessLogic.Tests
{
    [TestClass()]
    public class CustomerManagementTests
    {
        static MovieRentalItem rentedMovie1;
        static MovieRentalItem rentedMovie2;
        static MovieRentalItem rentedMovie3;

        [TestMethod()]
        public void RegisterCustomer_InvalidLastName_Negative()
        {
            Customer customer = new Customer();
            customer.FirstName = "FirstName001";
            customer.LastName = "FirstName00000000000000000000000000000000000000000000000000000000000000000000000000001";
            customer.ShippingAddress = new Address()
            {
                AddressLine1 = "139/18",
                AddressLine2 = string.Empty,
                City = "Faridabad",
                State = StateEnum.Haryana
            };
            customer.BillingAddress = customer.ShippingAddress;
            CustomerService.CustomerManagementClient client = new CustomerService.CustomerManagementClient();
            ResponseEnvelope<Customer> response = client.RegisterCustomer(customer);

            Console.Out.WriteLine(response.ResponseCode);
            Assert.IsTrue(response.ResponseCode != ResponseCodeEnum.ResponseOk);
        }

        [TestMethod()]
        public void RegisterCustomer_NullException_Negative()
        {
            try
            {

                Customer customer = null;
                
                using (CustomerService.CustomerManagementClient client = new CustomerService.CustomerManagementClient())
                {
                    ResponseEnvelope<Customer> response = client.RegisterCustomer(customer);
                    Console.Out.WriteLine(response.ResponseCode);
                }
            }
            catch (FaultException ex)
            {
                Console.Out.WriteLine(ex.ToString());
            }
        }

        [TestMethod()]
        public void RegisterCustomer1_Positive()
        {
            Customer customer = new Customer();
            customer.FirstName = "FirstName001";
            customer.LastName = "LastName001";
            customer.ShippingAddress = new Address()
            {
                AddressLine1 = "139/18",
                AddressLine2 = string.Empty,
                City = "Faridabad",
                State = StateEnum.Haryana
            };
            customer.BillingAddress = customer.ShippingAddress;
            CustomerService.CustomerManagementClient client = new CustomerService.CustomerManagementClient();
            ResponseEnvelope<Customer> response = client.RegisterCustomer(customer);

            Console.Out.WriteLine(response.ResponseCode);
            Console.Out.WriteLine(response.ResponseMessage);
            Assert.IsTrue(response.ResponseCode == ResponseCodeEnum.ResponseOk && !string.IsNullOrEmpty(response.ResponseMessage));
        }

        [TestMethod()]
        public void RegisterCustomer2_Positive()
        {
            Customer customer = new Customer();
            customer.FirstName = "FirstName002";
            customer.LastName = "LastName002";
            customer.ShippingAddress = new Address()
            {
                AddressLine1 = "18/2B BELLANDUR GATE",
                AddressLine2 = "SARJAPUR ROAD",
                City = "Bangalore",
                State = StateEnum.Karnataka
            };
            customer.BillingAddress = customer.ShippingAddress;
            CustomerService.CustomerManagementClient client = new CustomerService.CustomerManagementClient();
            ResponseEnvelope<Customer> response = client.RegisterCustomer(customer);

            Console.Out.WriteLine(response.ResponseCode);
            Console.Out.WriteLine(response.ResponseMessage);
            Assert.IsTrue(response.ResponseCode == ResponseCodeEnum.ResponseOk && !string.IsNullOrEmpty(response.ResponseMessage));
        }

        [TestMethod()]
        public void GetCustomers_Positive()
        {
            using (CustomerService.CustomerManagementClient client = new CustomerService.CustomerManagementClient())
            {
                ResponseEnvelope<Customer> response = client.GetAllCustomers();
                foreach (var item in response.List)
                {
                    Console.Out.WriteLine(item.FirstName);
                }
                Console.Out.WriteLine(response.ResponseCode);
                Assert.IsTrue(response.ResponseCode == ResponseCodeEnum.ResponseOk);
            }
        }

        [TestMethod()]
        public void RentMovie1ToCustomer1_Positive()
        {
            using (CustomerService.CustomerManagementClient cClient = new CustomerService.CustomerManagementClient())
            {
                ResponseEnvelope<Customer> cResponse = cClient.GetAllCustomers();
                using (MovieService.MovieManagementClient mClient = new MovieService.MovieManagementClient())
                {
                    ResponseEnvelope<Movie> mResponse = mClient.GetAllMovies();

                    MovieRentalItem movieRentalItem = new MovieRentalItem();
                    movieRentalItem.Customer = cResponse.List.First();
                    movieRentalItem.RentedDate = DateTime.Today.AddDays(-5);
                    movieRentalItem.Movie = mResponse.List.First();
                    
                    ResponseEnvelope<MovieRentalItem> rResponse = cClient.RentMovie(movieRentalItem);
                    rentedMovie1 = rResponse.List[0];
                    Console.Out.WriteLine(rResponse.ResponseMessage);
                    Assert.IsTrue(rResponse.ResponseCode == ResponseCodeEnum.ResponseOk);
                }
                
            }
        }

        [TestMethod()]
        public void RentMovie2ToCustomer1_Positive()
        {
            using (CustomerService.CustomerManagementClient cClient = new CustomerService.CustomerManagementClient())
            {
                ResponseEnvelope<Customer> cResponse = cClient.GetAllCustomers();
                using (MovieService.MovieManagementClient mClient = new MovieService.MovieManagementClient())
                {
                    ResponseEnvelope<Movie> mResponse = mClient.GetAllMovies();

                    MovieRentalItem movieRentalItem = new MovieRentalItem();
                    movieRentalItem.Customer = cResponse.List.First();
                    movieRentalItem.Movie = mResponse.List.Skip(1).First();
                    movieRentalItem.RentedDate = DateTime.Today.AddDays(-10);
                    ResponseEnvelope<MovieRentalItem> rResponse = cClient.RentMovie(movieRentalItem);
                    rentedMovie2 = rResponse.List[0];
                    Console.Out.WriteLine(rResponse.ResponseMessage);
                    Assert.IsTrue(rResponse.ResponseCode == ResponseCodeEnum.ResponseOk);
                }

            }
        }

        [TestMethod()]
        public void RentMovie3ToCustomer1_Positive()
        {
            using (CustomerService.CustomerManagementClient cClient = new CustomerService.CustomerManagementClient())
            {
                ResponseEnvelope<Customer> cResponse = cClient.GetAllCustomers();
                using (MovieService.MovieManagementClient mClient = new MovieService.MovieManagementClient())
                {
                    ResponseEnvelope<Movie> mResponse = mClient.GetAllMovies();

                    MovieRentalItem movieRentalItem = new MovieRentalItem();
                    movieRentalItem.Customer = cResponse.List.First();
                    movieRentalItem.Movie = mResponse.List.Skip(2).First();
                    movieRentalItem.RentedDate = DateTime.Today.AddDays(-5);
                    ResponseEnvelope<MovieRentalItem> rResponse = cClient.RentMovie(movieRentalItem);
                    rentedMovie3 = rResponse.List[0];
                    Console.Out.WriteLine(rResponse.ResponseMessage);
                    Assert.IsTrue(rResponse.ResponseCode == ResponseCodeEnum.ResponseOk);
                }

            }
        }

        [TestMethod()]
        public void ReturnMovie1_Positive()
        {
            using (CustomerService.CustomerManagementClient cClient = new CustomerService.CustomerManagementClient())
            {
                ResponseEnvelope<MovieRentalItem> cResponse = cClient.ReturnMovie(rentedMovie1);
                Console.Out.WriteLine(cResponse.ResponseMessage);
                Assert.IsTrue(cResponse.ResponseCode == ResponseCodeEnum.ResponseOk);
            }
        }

        [TestMethod()]
        public void ReturnMovie2_Positive()
        {
            using (CustomerService.CustomerManagementClient cClient = new CustomerService.CustomerManagementClient())
            {
                ResponseEnvelope<MovieRentalItem> cResponse = cClient.ReturnMovie(rentedMovie2);
                Console.Out.WriteLine(cResponse.ResponseMessage);
                Assert.IsTrue(cResponse.ResponseCode == ResponseCodeEnum.ResponseOk);
            }
        }

        [TestMethod()]
        public void ReturnMovie3_Positive()
        {
            using (CustomerService.CustomerManagementClient cClient = new CustomerService.CustomerManagementClient())
            {
                ResponseEnvelope<MovieRentalItem> cResponse = cClient.ReturnMovie(rentedMovie3);
                Console.Out.WriteLine(cResponse.ResponseMessage);
                Assert.IsTrue(cResponse.ResponseCode == ResponseCodeEnum.ResponseOk);
            }
        }

        [TestMethod()]
        public void GenerateBillForCustomer1_Positive()
        {
            using (CustomerService.CustomerManagementClient cClient = new CustomerService.CustomerManagementClient())
            {
                ResponseEnvelope<Customer> cResponse = cClient.GetAllCustomers();
                Console.Out.WriteLine(cResponse.ResponseMessage);
                Assert.IsTrue(cResponse.ResponseCode == ResponseCodeEnum.ResponseOk);

                Customer customer = cResponse.List.First();
                Console.Out.WriteLine(String.Format("Generating bill for customer 1 {0}", customer.UniqueNumber));
                ResponseEnvelope<MovieRentalItem> mResponse = cClient.GenerateBill(customer);
                foreach (var item in mResponse.List)
                {
                    Console.Out.WriteLine(string.Format("Rented On - {0}, Returned on - {1}, Bill - {2}, Points - {3}"
                        , item.RentedDate.ToLongDateString(), item.ReturnDate.ToLongDateString(), item.RentalBill.ToString(), item.RenterPoints.ToString()));
                }
                Assert.IsTrue(mResponse.ResponseCode == ResponseCodeEnum.ResponseOk);
            }
        }


        [TestMethod()]
        public void GenerateBillForCustomer2_Positive()
        {
            using (CustomerService.CustomerManagementClient cClient = new CustomerService.CustomerManagementClient())
            {
                ResponseEnvelope<Customer> cResponse = cClient.GetAllCustomers();
                Console.Out.WriteLine(cResponse.ResponseMessage);
                Assert.IsTrue(cResponse.ResponseCode == ResponseCodeEnum.ResponseOk);

                Customer customer = cResponse.List.Skip(1).First();
                Console.Out.WriteLine(String.Format("Generating bill for customer 2 {0}", customer.UniqueNumber));
                ResponseEnvelope<MovieRentalItem> mResponse = cClient.GenerateBill(customer);
                foreach (var item in mResponse.List)
                {
                    Console.Out.WriteLine(string.Format("Rented On - {0}, Returned on - {1}, Bill - {2}, Points - {3}"
                        , item.RentedDate.ToLongDateString(), item.ReturnDate.ToLongDateString(), item.RentalBill.ToString(), item.RenterPoints.ToString()));
                }
                Assert.IsTrue(mResponse.ResponseCode == ResponseCodeEnum.ResponseOk);
            }
        }

    }
}
