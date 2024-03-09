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

	private static Address GetAddress() => new Address
	{
		Name = "John Doe",
		Street = "Coolstreet 7",
		ZipCode = "12345",
		City = "Sometown",
	};
}
