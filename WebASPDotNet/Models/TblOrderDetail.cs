using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblOrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual TblOrder? Order { get; set; }

    public virtual TblProduct? Product { get; set; }
}
