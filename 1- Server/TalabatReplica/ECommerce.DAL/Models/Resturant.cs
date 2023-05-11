using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Models
{
    public class Resturant
    {
      
        public int ResturantID { get; set; }
      
        public string Location { get; set; } = string.Empty;
       
        public string Name { get; set; } = string.Empty;
        public string? Photo { get; set; }
    
        public string Description { get; set; } = string.Empty;

        public string? EmailAddress { get; set; }

        public string phoneNum { get; set; } = string.Empty;

        public virtual List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
