﻿using Domain.Models;
using Infra = Infrastructure.OrderPersistance.Models;

namespace Infrastructure.OrderPersistance.Mappers;

public static class OrderMapper
{
	public static Infra.Order Map(Order order)
	{
		return new Infra.Order
		{
			OrderId = order.OrderId,
			CustomerId = order.CustomerId,
			DeliveryAddress = AddressMapper.Map(order.DeliveryAddress),
			OrderLines = order.OrderLines.Select(OrderLineMapper.Map),
		};
	}

	public static Order Map(Infra.Order infraOrder)
	{
		var address = AddressMapper.Map(infraOrder.DeliveryAddress);
		var order = new Order(infraOrder.CustomerId, address, infraOrder.OrderId);

		infraOrder.OrderLines
			.Select(OrderLineMapper.Map)
			.ToList()
			.ForEach(order.AddLine);

		return order;
	}
}
