using ECommerce.DAL.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Reposatory.Repo
{
    public interface IPayPalRepo
    {
         Task<AuthResponse> Authenticate();

         Task<CreateOrderResponse> CreateOrder(string value, string currency, string reference);

         Task<CaptureOrderResponse> CaptureOrder(string orderId);

    }
}
