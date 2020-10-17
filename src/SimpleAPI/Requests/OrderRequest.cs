using System.Collections.Generic;

namespace SimpleAPI.Requests
{
    public class OrderRequest
    {
        public IEnumerable<string> ItemsIds { get; set; }
        public string Currency { get; set; }
    }
}