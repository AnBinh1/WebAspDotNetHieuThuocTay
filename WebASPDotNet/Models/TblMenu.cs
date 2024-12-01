using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebASPDotNet.Models;

public partial class TblMenu
{
    public int MenuId { get; set; }
    [Required(ErrorMessage ="yêu cầu nhập Tên Menu")]	
	public string Title { get; set; }

    public string Alias { get; set; }
    [Required(ErrorMessage ="yêu cầu nhập mô tả Menu")]
    public string Description { get; set; }
    [Required(ErrorMessage ="yêu cầu nhâp cấp Menu")]
    public int? Levels { get; set; }
   
    public int? ParentId { get; set; }
    [Required(ErrorMessage ="yêu cầu nhập vị trí Menu")]
    public int? Position { get; set; }
    
    public bool IsActive { get; set; }
}
