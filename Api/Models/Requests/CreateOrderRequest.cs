using System.ComponentModel.DataAnnotations;

namespace Api.Models.Requests;

public class CreateOrderRequest
{
	[Required]
	public required Guid CustomerId { get; set; }

	[Required]
	public required Address DeliveryAddress { get; set; }

	[Required]
	public required List<OrderLine> OrderLines { get; set; }
}
