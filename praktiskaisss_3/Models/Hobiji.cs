using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _1_praktiskais.Models;

public partial class Hobiji
{
    [Key]
    public string Id { get; set; } = null!;
    [Required]
    public string? Hobijs { get; set; }
    [Required]
    public string? Skola { get; set; }
}
