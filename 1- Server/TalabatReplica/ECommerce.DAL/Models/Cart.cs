using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int itemID { get; set; }
        public MenuItem item { get; set; }
        public  string UserID { get; set; }
        public IdentityUser users { get; set; }
        public string Quantity { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
