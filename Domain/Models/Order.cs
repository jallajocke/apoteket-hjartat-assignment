namespace Domain.Models;

public class Order(Guid? orderId = null)
{
	public Guid OrderId { get; private set; } = orderId ?? Guid.NewGuid();

	public required Guid CustomerId { get; init; }

	public required Address DeliveryAddress { get; init; }

	public required List<OrderLine> OrderLines { get; init; }
}
