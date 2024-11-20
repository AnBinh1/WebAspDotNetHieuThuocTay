using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblCustomer
{
    public int CustomerId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string? Avatar { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? LastLogin { get; set; }

    public bool IsActive { get; set; }
}
