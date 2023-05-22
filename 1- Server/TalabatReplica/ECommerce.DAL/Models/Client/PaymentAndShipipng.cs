using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ECommerce.DAL.Models.Client
{
    public sealed class Payments
    {
        public List<Capture> captures { get; set; }
    }

    public sealed class Shipping
    {
        public Address address { get; set; }
    }

}
