using Application.ExternalInterfaces;

namespace Application.Handlers;

public interface IDeleteOrderHandler
{
	public Task HandleAsync(Guid orderId);
}

public class DeleteOrderHandler(IOrderRepository orderRepository) : IDeleteOrderHandler
{
	private readonly IOrderRepository _orderRepository = orderRepository;

	public Task HandleAsync(Guid orderId)
	{
		return _orderRepository.RemoveOrderAsync(orderId);
	}
}
