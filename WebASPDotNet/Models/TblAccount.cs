using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblAccount
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime LastLogin { get; set; }

    public bool IsActive { get; set; }

    public virtual TblRole Role { get; set; } = null!;

    public virtual ICollection<TblProductReview> TblProductReviews { get; set; } = new List<TblProductReview>();
}
