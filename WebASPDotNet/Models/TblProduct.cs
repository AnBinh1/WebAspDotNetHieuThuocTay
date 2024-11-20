using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public string? Details { get; set; }

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal? PriceSale { get; set; }

    public int? Quantity { get; set; }

    public int CategoryId { get; set; }

    public string Image { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual TblCategory Category { get; set; } = null!;

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();

    public virtual ICollection<TblProductReview> TblProductReviews { get; set; } = new List<TblProductReview>();
}
