using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _1_praktiskais.Models;

public partial class Login
{
    [Key]
    public string Id { get; set; } = null!;
    [Required]
    public string? Epasts { get; set; }
    [Required]
    public string? Parole { get; set; }
}
