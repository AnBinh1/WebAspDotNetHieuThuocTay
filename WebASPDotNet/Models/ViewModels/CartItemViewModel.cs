namespace WebASPDotNet.Models.ViewModels
{
	public class CartItemViewModel
	{
		public List<TblCart> CartItems { get; set; }
		public decimal GrandTotal { get; set; }
	}
}
