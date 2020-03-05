using System;
using Yerel.Core.Entities;

namespace Yerel.Entities
{
    public class Stock : IEntity
    {
        public Stock    ()
        {
        }
        public int store_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
  
    }
}
