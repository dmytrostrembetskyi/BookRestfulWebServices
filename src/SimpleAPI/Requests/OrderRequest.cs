using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleAPI.Requests
{
    public class OrderRequest
    {
        [Required] public IEnumerable<string> ItemsIds { get; set; }

        [Required]
        [StringLength(3)]
        [Currency]
        public string Currency { get; set; }
    }
}