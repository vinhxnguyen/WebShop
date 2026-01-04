using System;
using System.Collections.Generic;

namespace WebShop.Models;

public partial class OrderProduct
{
    public int OrderProductId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public double Price { get; set; }

    public byte Quantity { get; set; }

    public double Total { get; set; }

    public virtual SalesOrder Order { get; set; } = null!;
}
