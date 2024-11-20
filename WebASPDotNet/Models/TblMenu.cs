using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblMenu
{
    public int MenuId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public int? Levels { get; set; }

    public int? ParentId { get; set; }

    public int? Position { get; set; }

    public bool IsActive { get; set; }
}
