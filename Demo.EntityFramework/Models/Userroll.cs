using System;
using System.Collections.Generic;

namespace Demo.EntityFramework.Models
{
    public partial class Userroll
    {
        public int RollId { get; set; }
        public string RollType { get; set; } = null!;
    }
}
