using System;
using System.Collections.Generic;

namespace EAD_Project_D1.Models
{
    public partial class Vechile
    {
        public int Id { get; set; }
        public string? Divername { get; set; }
        public int Number { get; set; }
        public string Type { get; set; } = null!;
    }
}
