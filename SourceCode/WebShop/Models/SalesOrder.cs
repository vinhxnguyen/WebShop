using System;
using System.Collections.Generic;

namespace WebShop.Models;

public partial class SalesOrder
{
    public int OrderId { get; set; }

    public string? OrderNumber { get; set; }

    public string Customer { get; set; } = null!;

    public string AddressLine1 { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? DeliveryAddress { get; set; }

    public string? BillingAddress { get; set; }

    public string? Description { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
