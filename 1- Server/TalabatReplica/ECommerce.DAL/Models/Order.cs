using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Models
{
    public class Order
    {
        public int orderID { get; set; }
        public int itemID { get; set; }
        public MenuItem item { get; set; }
        public string UserID { get; set; } = string.Empty;
       public IdentityUser users { get; set; }
        public int totalPrice { get; set; }
    }
}
