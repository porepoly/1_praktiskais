using System;
using System.Collections.Generic;

namespace _1_praktiskais.Models;

public partial class Bmi
{
    public string Id { get; set; } = null!;

    public decimal? Augums { get; set; }

    public decimal? Svars { get; set; }
}
