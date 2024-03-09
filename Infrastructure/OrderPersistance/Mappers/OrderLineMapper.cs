using Domain.Models;
using Infra = Infrastructure.OrderPersistance.Models;

namespace Infrastructure.OrderPersistance.Mappers;

public class OrderLineMapper
{
	public static Infra.OrderLine Map(OrderLine line)
	{
		return new Infra.OrderLine
		{
			ProductId = line.ProductId,
			Quantity = line.Quantity,
		};
	}

	public static OrderLine Map(Infra.OrderLine line)
	{
		return new OrderLine(line.ProductId, line.Quantity);
	}
}
