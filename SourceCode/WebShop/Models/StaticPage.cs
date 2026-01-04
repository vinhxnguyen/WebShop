using System;
using System.Collections.Generic;

namespace WebShop.Models;

public partial class StaticPage
{
    public int PageId { get; set; }

    public string PageTitle { get; set; } = null!;

    public string LanguageId { get; set; } = null!;

    public string PageContent { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }
}
