namespace Domain.Models;

public class Order(Guid? orderId = null)
{
	public Guid OrderId { get; private set; } = orderId ?? Guid.NewGuid();

	public required Guid CustomerId { get; init; }

	public required Address DeliveryAddress { get; init; }

	// invariant: every line's ProductId is unique
	private readonly List<OrderLine> _orderLines = [];
	public IReadOnlyList<OrderLine> OrderLines => _orderLines.AsReadOnly();

	public void AddLine(OrderLine line)
	{
		var existingProductLine = _orderLines.SingleOrDefault(l => l.ProductId == line.ProductId);
		if (existingProductLine == null)
		{
			_orderLines.Add(line);
			return;
		}
		_orderLines.Remove(existingProductLine);

		var quantity = existingProductLine.Quantity + line.Quantity;
		var newLine = new OrderLine(line.ProductId, quantity);
		_orderLines.Add(newLine);
	}
}
