using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebASPDotNet.Repository.Validation;

namespace WebASPDotNet.Models;

public partial class TblBlog
{
    public int BlogId { get; set; }
    [Required(ErrorMessage ="yêu cầu nhập Tiêu Đề Blog")]
    public string Title { get; set; }

    public string Alias { get; set; }
	[Required, Range(1, int.MaxValue, ErrorMessage = "yêu cầu chọn 1 loại danh mục sản phẩm")]
	public int? CategoryId { get; set; }
	[Required(ErrorMessage = "yêu cầu nhập mô tả Blog")]
	public string Description { get; set; }
	[Required(ErrorMessage = "yêu cầu nhập Chi Tiết Blog")]
	public string Detail { get; set; }

    public string Image { get; set; }="noimage.jpg";
	[NotMapped]
	[FileExtension]
	public IFormFile ImageUpload { get; set; }
	public int? AccountId { get; set; }

    public bool IsActive { get; set; }

    public virtual TblCategory Category { get; set; }

    public virtual ICollection<TblBlogComment> TblBlogComments { get; set; } = new List<TblBlogComment>();
}
