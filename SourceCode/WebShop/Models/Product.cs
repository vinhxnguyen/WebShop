using System;
using System.Collections.Generic;

namespace WebShop.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductNumber { get; set; } = null!;

    public string? Name { get; set; }

    public string? ShortDesc { get; set; }

    public string? Description { get; set; }

    public string? Unit { get; set; }

    public double UnitPrice { get; set; }

    public double? Oldprice { get; set; }

    public int CategoryId { get; set; }

    public bool IsPromotion { get; set; }

    public bool IsFeatured { get; set; }

    public byte[]? SmallImage { get; set; }

    public byte[]? BigImage { get; set; }

    public bool IsInstock { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;
}
