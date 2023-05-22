using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Models.Client
{
    public class Amount
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }

    public sealed class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }
    }

    public sealed class Name
    {
        public string given_name { get; set; }
        public string surname { get; set; }
    }

    public sealed class SellerProtection
    {
        public string status { get; set; }
        public List<string> dispute_categories { get; set; }
    }

    public sealed class SellerReceivableBreakdown
    {
        public Amount gross_amount { get; set; }
        public PaypalFee paypal_fee { get; set; }
        public Amount net_amount { get; set; }
    }

    public sealed class Paypal
    {
        public Name name { get; set; }
        public string email_address { get; set; }
        public string account_id { get; set; }
    }

    public sealed class PaypalFee
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }

    public class Address
    {
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string admin_area_2 { get; set; }
        public string admin_area_1 { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
    }

    public sealed class Payer
    {
        public Name name { get; set; }
        public string email_address { get; set; }
        public string payer_id { get; set; }
    }

    public sealed class PaymentSource
    {
        public Paypal paypal { get; set; }
    }
}

