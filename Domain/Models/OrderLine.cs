namespace Domain.Models;

public class OrderLine(Guid productId, int quantity)
{
	public readonly Guid ProductId = productId != Guid.Empty
		? productId
		: throw new ArgumentException("Id cannot be empty guid.", nameof(productId));

	public readonly int Quantity = quantity > 0
		? quantity
		: throw new ArgumentOutOfRangeException(nameof(quantity), "Value must be greater than zero.");
}
