using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelBookStore.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery (this HttpRequest request) =>
            // as long it as it value, request query string, otherwise (: ) path.toString 
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
