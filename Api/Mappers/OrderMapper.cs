using Domain.Models;
using ApiModels = Api.Models;

namespace Api.Mappers;

public static class OrderMapper
{
	public static ApiModels.Order Map(Order order)
	{
		return new ApiModels.Order
		{
			OrderId = order.OrderId,
			CustomerId = order.CustomerId,
			DeliveryAddress = AddressMapper.Map(order.DeliveryAddress),
			OrderLines = order.OrderLines.Select(OrderLineMapper.Map),
		};
	}
}
