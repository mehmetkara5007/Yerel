using System;
using Yerel.Core.Entities;

namespace Yerel.Entities
{
    public class Category : IEntity
    {
        public Category()
        {
        }
        public int category_id { get; set; }
     
        public string category_name { get; set; }
      
    }
}
