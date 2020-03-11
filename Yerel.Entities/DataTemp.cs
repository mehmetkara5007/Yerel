using System;
using Yerel.Core.Entities;

namespace Yerel.Entities
{
    public class DataTemp : IEntity
    {
        public DataTemp()
        {
            SaveDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string DataAws { get; set; }
        public DateTime SaveDate { get; set; }
    }
}
