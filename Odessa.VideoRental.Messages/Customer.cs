#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#endregion

namespace Odessa.VideoRental.Messages
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public String FirstName
        {
            get;
            set;
        }

        [DataMember]
        public String LastName
        {
            get;
            set;
        }

        [DataMember]
        public DateTime RegistrationDate
        {
            get;
            set;
        }

        [DataMember]
        public string UniqueNumber
        {
            get;
            set;
        }

        [DataMember]
        public Address BillingAddress
        {
            get;
            set;
        }

        [DataMember]
        public Address ShippingAddress
        {
            get;
            set;
        }

        [DataMember]
        public List<MovieRentalItem> MovieRentalHistory
        {
            get;
            set;
        }

        [DataMember]
        public int Id
        {
            get;
            set;
        }


    }
}
