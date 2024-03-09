using Api.Mappers;
using Api.Models;
using Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IGetAllOrdersHandler getAllOrdersHandler) : ControllerBase
{
	private readonly IGetAllOrdersHandler _getAllOrdersHandler = getAllOrdersHandler;

	[HttpGet]
	public async Task<IEnumerable<Order>> GetAllOrdersAsync()
	{
		var result = await _getAllOrdersHandler.HandleAsync();
		var orders = result.Select(OrderMapper.Map);

		return orders;
	}
}
