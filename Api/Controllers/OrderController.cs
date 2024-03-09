using Api.ErrorHandling;
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
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
	[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetail))]
	public async Task<ActionResult<Order>> GetOrderAsync([FromRoute] Guid orderId)
	{
		var result = await _getOrderHandler.HandleAsync(orderId);
		var order = OrderMapper.Map(result);

		return Ok(order);
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Order>))]
	public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersAsync()
	{
		var result = await _getAllOrdersHandler.HandleAsync();
		var orders = result.Select(OrderMapper.Map);

		return Ok(orders);
	}
}
