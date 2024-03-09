using Application.ExternalInterfaces;
using Domain.Models;

namespace Application.Handlers;

public interface IGetAllOrdersHandler
{
	public Task<List<Order>> HandleAsync();
}

public class GetAllOrdersHandler(IOrderRepository orderRepository) : IGetAllOrdersHandler
{
	private readonly IOrderRepository _orderRepository = orderRepository;

	public async Task<List<Order>> HandleAsync()
	{
		var orders = await _orderRepository.GetAllOrdersAsync();

		return orders;
	}
}
