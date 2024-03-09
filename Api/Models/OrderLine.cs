using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class OrderLine()
{
	/// <summary>
	/// The id of the product.
	/// </summary>
	[Required]
	public required Guid ProductId { get; set; }

	/// <summary>
	/// The quantity of the product.
	/// </summary>
	/// <example>3</example>
	[Required]
	[Range(1, int.MaxValue)]
	public required int Quantity { get; set; }
}
