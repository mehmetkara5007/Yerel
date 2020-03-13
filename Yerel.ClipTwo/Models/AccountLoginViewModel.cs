using System.Collections.Generic;
using Yerel.Entities;

namespace Yerel.ClipTwo.Models
{
    public class AccountLoginViewModel
    {
        public List<string> Data { get; set; }
        public string Token { get; set; }
        public User User { get; set; }

    }
}