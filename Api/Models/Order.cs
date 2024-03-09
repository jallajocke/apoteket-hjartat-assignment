namespace Api.Models;

public class Order
{
	public Guid OrderId { get; set; }

	public Guid CustomerId { get; set; }

	public Address DeliveryAddress { get; set; }

	public IEnumerable<OrderLine> OrderLines { get; set; }
}
