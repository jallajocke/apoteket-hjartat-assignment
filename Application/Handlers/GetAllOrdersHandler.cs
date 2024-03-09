using Domain.Models;

namespace Application.Handlers;

public interface IGetAllOrdersHandler
{
	public Task<List<Order>> HandleAsync();
}

public class GetAllOrdersHandler : IGetAllOrdersHandler
{
	public async Task<List<Order>> HandleAsync()
	{
		var order = new Domain.Models.Order
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
		};

		return [order];
	}
}
