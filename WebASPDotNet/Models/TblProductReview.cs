using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblProductReview
{
    public int ReviewId { get; set; }

    public int? ProductId { get; set; }

    public int? AccountId { get; set; }

    public int? Star { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual TblAccount? Account { get; set; }

    public virtual TblProduct? Product { get; set; }
}
