using Domain.Models;

namespace Application.Commands;

public class CreateOrderCommand
{
	public required Guid CustomerId { get; set; }
	public required Address DeliveryAddress { get; set; }
	public required List<OrderLine> OrderLines { get; set; }
}
