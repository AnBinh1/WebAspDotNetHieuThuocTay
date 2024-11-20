using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string? Alias { get; set; }

    public string Description { get; set; } = null!;

    public int? Position { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<TblBlog> TblBlogs { get; set; } = new List<TblBlog>();

    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
