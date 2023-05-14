using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Models.IdentityModels
{
    // to return token for user after registeration success
    public class AuthModel
    {
        public string Message { get; set; } //message to user know register success or feil 
        public bool IsAuthenticated { get; set; } // flag to check this user already registered or not
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } // Roles assigned to this user
        public string Token { get; set; } // combine secure key , hash key , ....
        public DateTime ExpiresOn { get; set; } // Token expire date
    }
}
