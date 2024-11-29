using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebASPDotNet.Repository.Validation;

namespace WebASPDotNet.Models;

public partial class TblProduct
{
    public int ProductId { get; set; }
	[Required(ErrorMessage ="yêu cầu nhập tên sản phẩm")]
	public string Name { get; set; } = null!;
	
	public string Alias { get; set; } = null!;
	[Required(ErrorMessage = "yêu cầu nhập Chi Tiết sản phẩm")]
	public string Details { get; set; }
	[Required(ErrorMessage = "yêu cầu nhập mô tả sản phẩm")]
	public string Description { get; set; } = null!;
	[Required( ErrorMessage = "yêu cầu nhập Giá sản phẩm")]
	[Range(0.01 , double.MaxValue)]
	[Column(TypeName = "decimal(10.3)")]
	public decimal Price { get; set; }
	public decimal? PriceSale { get; set; }
	public int? Quantity { get; set; }
	[Required,Range(1,int.MaxValue,ErrorMessage ="yêu cầu chọn 1 loại sản phẩm")]
	public int CategoryId { get; set; }


	public string Image { get; set; } = "noimage.jpg";
	[NotMapped]
	[FileExtension]
	public IFormFile ImageUpload {get; set; }
    public DateTime? CreatedDate { get; set; }

    public virtual TblCategory Category { get; set; } = null!;

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();

    public virtual ICollection<TblProductReview> TblProductReviews { get; set; } = new List<TblProductReview>();
}
