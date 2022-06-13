using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Cart
    {
        public string Id { get; set; } = $"cart:{Guid.NewGuid()}";
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
