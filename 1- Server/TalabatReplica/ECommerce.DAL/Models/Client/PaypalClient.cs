using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ECommerce.DAL.Models.Client
{

    /// <summary>
    /// Since the official Paypal SDK for .NET is deprecated then
    /// will PayPal HTTP client to access the Paypal REST API
    /// </summary>
    public sealed class PaypalClient
    {
        public string Mode { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string BaseUrl => Mode == "Live"
            ? "https://api-m.paypal.com"
            : "https://api-m.sandbox.paypal.com";

        public PaypalClient(string clientId, string clientSecret, string mode)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Mode = mode;
        }

        
    }
}
