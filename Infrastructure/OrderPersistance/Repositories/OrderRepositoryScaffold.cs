using Application.ExternalInterfaces;
using Domain.Models;
using Infrastructure.OrderPersistance.Mappers;
using Infra = Infrastructure.OrderPersistance.Models;

namespace Infrastructure.OrderPersistance.Repositories;

// Note that this is just a scaffold and should NEVER be used in a live environment!
public class OrderRepositoryScaffold : IOrderRepository
{
	private readonly List<Infra.Order> _orders = [
		new Infra.Order
		{
			OrderId = Guid.NewGuid(),
			CustomerId = Guid.NewGuid(),
			DeliveryAddress = new Infra.Address
			{
				Name = "1",
				Street = "2",
				City = "3",
				ZipCode = "g",
			},
			OrderLines = [new Infra.OrderLine { ProductId = Guid.NewGuid(), Quantity = 3 }],
		}];

	public async Task CreateOrderAsync(Order order)
	{
		_orders.Add(OrderMapper.Map(order));
	}

	public async Task<List<Order>> GetAllOrdersAsync()
	{
		return _orders.Select(OrderMapper.Map).ToList();
	}

	public async Task<Order?> GetOrderAsync(Guid orderId)
	{
		var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
		if (order == null) return null;

		return OrderMapper.Map(order);
	}
}
