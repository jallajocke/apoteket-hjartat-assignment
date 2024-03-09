namespace Domain.ErrorHandling;

public class OrderNotFoundException(Guid orderId, string? message = null) : Exception(message)
{
	public readonly Guid OrderId = orderId;
}

public class OrderLineNotFoundException(Guid productId, string? message = null) : Exception(message)
{
	public readonly Guid ProductId = productId;
}
