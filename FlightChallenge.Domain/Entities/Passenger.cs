using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightChallenge.Domain.Entities
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PassportNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
