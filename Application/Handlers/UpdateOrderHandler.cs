using Application.Commands;
using Application.ExternalInterfaces;

namespace Application.Handlers;

public interface IUpdateOrderHandler
{
	public Task HandleAsync(UpdateOrderCommand command);
}

public class UpdateOrderHandler(IOrderRepository orderRepository) : IUpdateOrderHandler
{
	private readonly IOrderRepository _orderRepository = orderRepository;

	public async Task HandleAsync(UpdateOrderCommand command)
	{
		throw new NotImplementedException();
	}
}
