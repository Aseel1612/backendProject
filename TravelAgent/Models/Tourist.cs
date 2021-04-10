using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TravelAgent.Models
{
    public class Tourist
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string CreditCardNumber { get; set; }
        public DateTime? CreditCardValidFrom { get; set; }
        public DateTime? CreditCardExpireEnd { get; set; }
        public string CreditCardName { get; set; }
        public int? CreditCardCVVNumber { get; set; }
    }
}
