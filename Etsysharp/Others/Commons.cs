using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp
{
    public static class Urls
    {
        public static readonly string baseUrl = "https://openapi.etsy.com/v2/";
    }
    public class Commons
    {

    }
    public enum Permissions
    {
        email_r,
        listings_r,
        listings_w,
        listings_d,
        transactions_r,
        transactions_w,
        billing_r,
        profile_r,
        profile_w,
        address_r,
        address_w,
        favorites_rw,
        shops_rw,
        cart_rw,
        recommend_rw,
        feedback_r,
        treasury_r,
        treasury_w

    }
    
}
