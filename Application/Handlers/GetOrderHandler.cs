using Application.ExternalInterfaces;
using Domain.Models;

namespace Application.Handlers;

public interface IGetOrderHandler
{
	public Task<Order> HandleAsync(Guid orderId);
}

public class GetOrderHandler(IOrderRepository orderRepository) : IGetOrderHandler
{
	private readonly IOrderRepository _orderRepository = orderRepository;

	public async Task<Order> HandleAsync(Guid orderId)
	{
		var order = await _orderRepository.GetOrderAsync(orderId);
		if (order == null) throw new Exception("Temporary");

		return order;
	}
}
