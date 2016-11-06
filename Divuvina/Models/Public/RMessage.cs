using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Divuvina.Models.Public
{
    public class RMessage
    {
        public bool Result { get; set; }
        public string MessageId { get; set; }
        public string ErrorMessage { get; set; }
        public string SystemMessage { get; set; }

    }
}