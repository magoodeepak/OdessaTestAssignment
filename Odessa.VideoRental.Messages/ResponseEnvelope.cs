using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Odessa.VideoRental.Messages
{
    [DataContract()]
    public class ResponseEnvelope<TEntity>
    {
        [DataMember()]
        public string ResponseMessage
        {
            get;
            set;
        }

        [DataMember()]
        public ResponseCodeEnum ResponseCode
        {
            get;
            set;
        }

        [DataMember()]
        public List<TEntity> List
        {
            get;
            set;
        }
    }
}
