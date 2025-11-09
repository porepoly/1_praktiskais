using System;
using System.Collections.Generic;

namespace _1_praktiskais.Models;

public partial class Login
{
    public string Id { get; set; } = null!;

    public string? Epasts { get; set; }

    public string? Parole { get; set; }
}
