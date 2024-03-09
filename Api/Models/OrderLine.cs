using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class OrderLine()
{
	[Required]
	public required Guid ProductId { get; set; }

	[Required]
	[Range(1, int.MaxValue)]
	public required int Quantity { get; set; }
}
