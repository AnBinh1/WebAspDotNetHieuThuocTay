using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblOrder
{
    public int OrderId { get; set; }

    public string Code { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int TotalAmount { get; set; }

    public int Quanlity { get; set; }

    public int OrderStatusId { get; set; }

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();
}
