using Application.Commands;
using Application.ExternalInterfaces;
using Domain.ErrorHandling;

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
		var order = await _orderRepository.GetOrderAsync(command.OrderId);
		if (order == null) throw new OrderNotFoundException(command.OrderId, $"Order not found in repository for id: '{command.OrderId}'.");

		command.RemoveProductIds.ForEach(order.RemoveProducts);
		command.AddOrderLines.ForEach(order.AddLine);
		if (command.NewDeliveryAddress != null)
		{
			order.UpdateDeliveryAddress(command.NewDeliveryAddress);
		}

		await _orderRepository.UpdateOrderAsync(order);
	}
}
