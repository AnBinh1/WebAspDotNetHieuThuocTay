using System.ComponentModel.DataAnnotations;

namespace WebASPDotNet.Repository.Validation
{
	public class FileExtensionAttribute:ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value is IFormFile file)
			{
				var extension = Path.GetExtension(file.FileName);
				string[] extensions = { "jpg", "png" };
				bool result = extensions.Any(x => extension.EndsWith(x));
				if (!result)
				{
					return new ValidationResult("Chỉ chấp nhận tệp định dạng jpg hoặc png");
				}
			}
			return ValidationResult.Success;
		}
	}
}
