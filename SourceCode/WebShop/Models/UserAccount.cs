using System;
using System.Collections.Generic;

namespace WebShop.Models;

public partial class UserAccount
{
    public int UserId { get; set; }

    public int UserGroupId { get; set; }

    public int Status { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public string? AddressLine1 { get; set; }

    public bool? Gender { get; set; }

    public bool Builtin { get; set; }

    public DateTime CreatedOn { get; set; }

    public int CreatedBy { get; set; }

    public virtual UserGroup UserGroup { get; set; } = null!;
}
