namespace Domain.Models;

public class Order
{
	public required Guid OrderId { get; set; }

	public required Guid CustomerId { get; set; }

	public required Address DeliveryAddress { get; set; }

	public required List<OrderLine> OrderLines { get; set; }
}
