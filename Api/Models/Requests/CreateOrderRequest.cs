using System.ComponentModel.DataAnnotations;

namespace Api.Models.Requests;

public class CreateOrderRequest
{
	/// <summary>
	/// Id of the customer.
	/// </summary>
	[Required]
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
