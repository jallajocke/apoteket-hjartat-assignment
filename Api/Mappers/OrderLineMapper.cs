using Domain.Models;
using ApiModels = Api.Models;

namespace Api.Mappers;

public class OrderLineMapper
{
	public static ApiModels.OrderLine Map(OrderLine line)
	{
		return new ApiModels.OrderLine
		{
			ProductId = line.ProductId,
			Quantity = line.Quantity,
		};
	}
}
