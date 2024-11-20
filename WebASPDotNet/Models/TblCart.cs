using System;
using System.Collections.Generic;

namespace WebASPDotNet.Models;

public partial class TblCart
{
    public int CartId { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal Total
    {
        get { return Quantity * Price; }
        set { }
	}

    public string Image { get; set; } = null!;

    public TblCart()
    {

    }
    public TblCart(TblProduct product)
    {
        CartId = product.ProductId;
        Name = product.Name;
        Price = product.Price;
        Quantity = 1; 
        Image = product.Image;
    }
}
