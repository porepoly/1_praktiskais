using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _1_praktiskais.Models;

public partial class Lietotaj
{
    [Key]
    public string Id { get; set; } = null!;
    [Required]
    public string? Vards { get; set; }
    [Required]
    public string? Uzvards { get; set; }

}
