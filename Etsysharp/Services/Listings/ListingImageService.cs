using Etsysharp.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Services
{
    public class ListingImageService : BaseHttpService<ListingImage>
    {
        public ListingImageService(OauthCredentials oAuthCredentials) : base(oAuthCredentials)
        {

        }
    }
}
