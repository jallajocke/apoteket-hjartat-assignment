namespace Domain.Models;

public class Order(Guid customerId, Address deliveryAddress, Guid? orderId = null)
{
	public Guid OrderId { get; private set; } = orderId ?? Guid.NewGuid();

	public readonly Guid CustomerId = customerId != Guid.Empty ? customerId : throw new ArgumentException("Guid cannot be empty.", nameof(customerId));

	public Address DeliveryAddress = deliveryAddress ?? throw new ArgumentNullException(nameof(deliveryAddress));

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

	public void RemoveProducts(Guid productId)
	{
		var existingProductLine = _orderLines.SingleOrDefault(l => l.ProductId == productId);
		if (existingProductLine == null) throw new ArgumentException($"No order line exists with product id: '{productId}'.", nameof(productId));

		_orderLines.Remove(existingProductLine);
	}

	public void UpdateDeliveryAddress(Address newAddress)
	{
		ArgumentNullException.ThrowIfNull(newAddress);

		DeliveryAddress = newAddress;
	}
}
