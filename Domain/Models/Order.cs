namespace Domain.Models;

public class Order
{
	public readonly Guid OrderId;

	public readonly Guid CustomerId;

	public Address DeliveryAddress { get; private set; }

	public Order(Guid customerId, Address deliveryAddress, Guid? orderId = null)
	{
		ArgumentNullException.ThrowIfNull(deliveryAddress);
		if (customerId == Guid.Empty) throw new ArgumentException("Guid cannot be empty.", nameof(customerId));
		if (orderId == Guid.Empty) throw new ArgumentException("Guid cannot be empty.", nameof(orderId));

		OrderId = orderId ?? Guid.NewGuid();
		CustomerId = customerId;
		DeliveryAddress = deliveryAddress;
	}

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
