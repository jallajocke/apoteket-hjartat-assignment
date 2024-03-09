namespace Infrastructure.OrderPersistance.Models;

public class OrderLine()
{
	public required Guid ProductId { get; set; }
	public required int Quantity { get; set; }
}
