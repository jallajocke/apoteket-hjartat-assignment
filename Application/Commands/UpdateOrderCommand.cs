using Domain.Models;

namespace Application.Commands;

public class UpdateOrderCommand
{
	public required Guid OrderId { get; set; }
	public required Address? NewDeliveryAddress { get; set; }
	public required List<OrderLine> AddOrderLines { get; set; }
	public required List<Guid> RemoveProductIds { get; set; }
}
