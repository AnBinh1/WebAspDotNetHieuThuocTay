using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblBlogComment
{
    public int CommentId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? Detail { get; set; }

    public int? BlogId { get; set; }

    public bool IsActive { get; set; }

    public virtual TblBlog? Blog { get; set; }
}
