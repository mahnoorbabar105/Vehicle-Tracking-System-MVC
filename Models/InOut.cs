using System;
using System.Collections.Generic;

namespace EAD_Project_D1.Models
{
    public partial class InOut
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Time { get; set; }
        public string Inout1 { get; set; } = null!;
    }
}
