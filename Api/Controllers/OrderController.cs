using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
	[HttpGet]
	public IEnumerable<Order> GetAllOrders()
	{
		var domainOrder = new Domain.Models.Order
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
		var order = OrderMapper.Map(domainOrder);

		return [order];
	}
}
