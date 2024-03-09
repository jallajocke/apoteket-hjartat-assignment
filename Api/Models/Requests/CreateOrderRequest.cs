using System.ComponentModel.DataAnnotations;

namespace Api.Models.Requests;

public class CreateOrderRequest
{
	/// <summary>
	/// Id of the customer.
	/// </summary>
	[Required]
	[RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "CustomerId cannot be empty.")]
	public required Guid CustomerId { get; set; }

	/// <summary>
	/// The address to where the order should be delivered.
	/// </summary>
	[Required]
	public required Address DeliveryAddress { get; set; }

	/// <summary>
	/// Order lines containing products and quantity.
	/// </summary>
	[Required]
	public required List<OrderLine> OrderLines { get; set; }
}
