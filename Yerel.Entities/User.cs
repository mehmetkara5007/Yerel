using System;
using Yerel.Core.Entities;

namespace Yerel.Entities
{
    public class User : IEntity
    {
        public User    ()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
      }
}
