using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public int? CategoryId { get; set; }

    public string? Description { get; set; }

    public string? Detail { get; set; }

    public string? Image { get; set; }

    public int? AccountId { get; set; }

    public bool IsActive { get; set; }

    public virtual TblCategory? Category { get; set; }

    public virtual ICollection<TblBlogComment> TblBlogComments { get; set; } = new List<TblBlogComment>();
}
