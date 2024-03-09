using Application.ExternalInterfaces;
using Domain.Models;

namespace Infrastructure.OrderPersistance.Repositories;

// Note that this is just a scaffold and should NEVER be used in a live environment!
public class OrderRepositoryScaffold : IOrderRepository
{
	private readonly List<Order> _orders = [
		new Domain.Models.Order
		{
			OrderId = Guid.NewGuid(),
			CustomerId = Guid.NewGuid(),
			DeliveryAddress = new Domain.Models.Address
			{
				Name = "1",
				Street = "2",
				City = "3",
				ZipCode = "g",
			},
			OrderLines = [new Domain.Models.OrderLine(Guid.NewGuid(), 3)],
		}];

	public async Task<List<Order>> GetAllOrdersAsync()
	{
		return _orders;
	}
}
