using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _1_praktiskais.Models;

public partial class Bmi
{
    [Key]
    public string Id { get; set; } = null!;
    [Required]
    public decimal? Augums { get; set; }
    [Required]
    public decimal? Svars { get; set; }
}
