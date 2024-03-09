namespace Domain.Models;

public class Order
{
	public Guid OrderId { get; set; }

	public Guid CustomerId { get; set; }

	public Address DeliveryAddress { get; set; }

	public List<OrderLine> OrderLines { get; set; }
}
