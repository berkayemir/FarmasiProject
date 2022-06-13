using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class UpdateCartDto
    {
        public string CartId { get; set; }
        public int Quantity { get; set; }
    }
}
