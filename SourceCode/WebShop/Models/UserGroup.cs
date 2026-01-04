using System;
using System.Collections.Generic;

namespace WebShop.Models;

public partial class UserGroup
{
    public int UserGroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public string? Description { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
