using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebASPDotNet.Models;

public partial class TblCategory
{
    public int CategoryId { get; set; }
    [Required(ErrorMessage ="Yêu cầu nhập tên danh mục sản phẩm")]
    public string Title { get; set; } = null!;

    public string Alias { get; set; }
	[Required(ErrorMessage ="Yêu cầu nhập mô tả danh mục sản phẩm")]
	public string Description { get; set; } = null!;
	[Required(ErrorMessage ="Yêu cầu nhập vị trí")]
	public int Position { get; set; }
	public bool IsActive { get; set; }

    public virtual ICollection<TblBlog> TblBlogs { get; set; } = new List<TblBlog>();

    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
