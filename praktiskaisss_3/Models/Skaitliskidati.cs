using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _1_praktiskais.Models;

public partial class Skaitliskidati
{
    [Key]
    public string Id { get; set; } = null!;
    [Required]
    public decimal? Telefons { get; set; }
    [Required]
    public decimal? Perskods { get; set; }
}
