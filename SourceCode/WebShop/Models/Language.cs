using System;
using System.Collections.Generic;

namespace WebShop.Models;

public partial class Language
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
