using Application.Commands;
using Application.ExternalInterfaces;
using Domain.Models;

namespace Application.Handlers;

public interface ICreateOrderHandler
{
	public Task<Order> HandleAsync(CreateOrderCommand command);
}

public class CreateOrderHandler(IOrderRepository orderRepository) : ICreateOrderHandler
{
	private readonly IOrderRepository _orderRepository = orderRepository;

	public async Task<Order> HandleAsync(CreateOrderCommand command)
	{
		var order = new Order(command.CustomerId, command.DeliveryAddress);
		command.OrderLines.ForEach(order.AddLine);

		await _orderRepository.CreateOrderAsync(order);
		return order;
	}
}
