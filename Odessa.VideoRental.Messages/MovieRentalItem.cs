using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Odessa.VideoRental.Messages
{
 
    [DataContract]
    public class MovieRentalItem
    {
        [DataMember]
        public DateTime RentedDate
        {
            get;
            set;
        }

        [DataMember]
        public DateTime ReturnDate
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

        [DataMember]
        public Movie Movie
        {
            get;
            set;
        }

        [DataMember]
        public Customer Customer
        {
            get;
            set;
        }

        [DataMember]
        public string MovieRentalItemUID
        {
            get;
            set;
        }

        [DataMember]
        public double RentalBill
        {
            get;
            set;
        }

        [DataMember]
        public int RenterPoints
        {
            get;
            set;
        }
    }
}
