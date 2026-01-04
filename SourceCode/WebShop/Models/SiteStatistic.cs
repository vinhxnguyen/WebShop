using System;
using System.Collections.Generic;

namespace WebShop.Models;

public partial class SiteStatistic
{
    public int StatisticId { get; set; }

    public long VisitCounter { get; set; }
}
