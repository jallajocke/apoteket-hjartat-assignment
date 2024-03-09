using Domain.Models;

namespace Tests.Domain;

public class OrderTests
{
	[Test]
	public void Constructor_WithAllParametersValid_ReturnOrder()
	{
		// Arrange
		var customerId = Guid.NewGuid();
		var address = GetAddress();
		var orderId = Guid.NewGuid();

		// Act
		var result = new Order(customerId, address, orderId);

		// Assert
		Assert.That(result, Is.Not.Null);
		Assert.Multiple(() =>
		{
			Assert.That(result.CustomerId, Is.EqualTo(customerId));
			Assert.That(result.DeliveryAddress, Is.EqualTo(address));
			Assert.That(result.OrderId, Is.EqualTo(orderId));
			Assert.That(result.OrderLines, Is.Empty);
		});
	}

	[Test]
	public void Constructor_WithoutOrderId_GeneratesNewOrderId()
	{
		// Arrange
		var customerId = Guid.NewGuid();
		var address = GetAddress();

		// Act
		var result = new Order(customerId, address);

		// Assert
		Assert.That(result, Is.Not.Null);
		Assert.Multiple(() =>
		{
			Assert.That(result.CustomerId, Is.EqualTo(customerId));
			Assert.That(result.DeliveryAddress, Is.EqualTo(address));
			Assert.That(result.OrderId, Is.Not.EqualTo(Guid.Empty));
			Assert.That(result.OrderLines, Is.Empty);
		});
	}

	[Test]
	public void Constructor_WithEmptyOrderId_Throws()
	{
		// Arrange
		var customerId = Guid.NewGuid();
		var address = GetAddress();
		var orderId = Guid.Empty;

		// Act & Assert
		Assert.Throws<ArgumentException>(() => new Order(customerId, address, orderId));
	}

	[Test]
	public void Constructor_WithEmptyCustomerId_Throws()
	{
		// Arrange
		var customerId = Guid.Empty;
		var address = GetAddress();

		// Act & Assert
		Assert.Throws<ArgumentException>(() => new Order(customerId, address));
	}

	[Test]
	public void Constructor_WithAddressNull_Throws()
	{
		// Arrange
		var customerId = Guid.NewGuid();
		Address address = null!;

		// Act & Assert
		Assert.Throws<ArgumentNullException>(() => new Order(customerId, address));
	}


	[Test]
	public void AddLines_SingleLine_UpdatesOrderLines()
	{
		// Arrange
		var order = GetEmptyOrder();
		var productId = Guid.NewGuid();
		var quantity = 5;
		var line = new OrderLine(productId, quantity);

		// Act
		order.AddLine(line);

		// Assert
		Assert.That(order.OrderLines, Has.Count.EqualTo(1));
		Assert.That(order.OrderLines[0], Is.EqualTo(line));
	}

	[Test]
	public void AddLines_MultipleLines_UpdatesOrderLines()
	{
		// Arrange
		var order = GetEmptyOrder();
		var lines = new List<OrderLine>
		{
			new OrderLine(Guid.NewGuid(), 5),
			new OrderLine(Guid.NewGuid(), 3),
		};

		// Act
		lines.ForEach(order.AddLine);

		// Assert
		Assert.That(order.OrderLines, Has.Count.EqualTo(2));
	}

	[Test]
	public void AddLines_MultipleLinesOfSameProductId_AddsOneLineWithSumOfQuantity()
	{
		// Arrange
		var order = GetEmptyOrder();
		var productId = Guid.NewGuid();
		var lines = new List<OrderLine>
		{
			new OrderLine(productId, 5),
			new OrderLine(productId, 3),
			new OrderLine(productId, 7),
		};

		// Act
		lines.ForEach(order.AddLine);

		// Assert
		Assert.That(order.OrderLines, Has.Count.EqualTo(1));
		var line = order.OrderLines[0];
		Assert.Multiple(() =>
		{
			Assert.That(line.ProductId, Is.EqualTo(productId));
			Assert.That(line.Quantity, Is.EqualTo(15));
		});
	}

	private static Order GetEmptyOrder() => new Order(Guid.NewGuid(), GetAddress());

	private static Address GetAddress() => new Address
	{
		Name = "John Doe",
		Street = "Coolstreet 7",
		ZipCode = "12345",
		City = "Sometown",
	};
}
