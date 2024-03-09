using Api.Mappers;
using Api.Models;
using Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IGetOrderHandler getOrderHandler, IGetAllOrdersHandler getAllOrdersHandler) : ControllerBase
{
	private readonly IGetOrderHandler _getOrderHandler = getOrderHandler;
	private readonly IGetAllOrdersHandler _getAllOrdersHandler = getAllOrdersHandler;


	[HttpGet("{orderId:guid}")]
	public async Task<ActionResult<Order>> GetOrderAsync([FromRoute] Guid orderId)
	{
		var result = await _getOrderHandler.HandleAsync(orderId);
		var order = OrderMapper.Map(result);

		return Ok(order);
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersAsync()
	{
		var result = await _getAllOrdersHandler.HandleAsync();
		var orders = result.Select(OrderMapper.Map);

		return Ok(orders);
	}
}
