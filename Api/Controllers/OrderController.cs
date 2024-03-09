using Api.ErrorHandling;
using Api.Mappers;
using Api.Models;
using Api.Models.Requests;
using Application.Commands;
using Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(ICreateOrderHandler createOrderHandler, IUpdateOrderHandler updateOrderHandler, IGetOrderHandler getOrderHandler, IGetAllOrdersHandler getAllOrdersHandler) : ControllerBase
{
	private readonly IGetOrderHandler _getOrderHandler = getOrderHandler;
	private readonly IGetAllOrdersHandler _getAllOrdersHandler = getAllOrdersHandler;
	private readonly ICreateOrderHandler _createOrderHandler = createOrderHandler;
	private readonly IUpdateOrderHandler _updateOrderHandler = updateOrderHandler;

	/// <summary>
	/// Creates a new order
	/// </summary>
	/// <response code="201">Returns a newly created order.</response>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Order))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetail))]
	public async Task<ActionResult<Order>> CreateOrderAsync([FromBody] CreateOrderRequest request)
	{
		var command = new CreateOrderCommand
		{
			CustomerId = request.CustomerId,
			DeliveryAddress = AddressMapper.Map(request.DeliveryAddress),
			OrderLines = request.OrderLines.Select(OrderLineMapper.Map).ToList(),
		};

		var result = await _createOrderHandler.HandleAsync(command);

		var order = OrderMapper.Map(result);
		return CreatedAtRoute(nameof(GetOrderAsync), new { order.OrderId }, order);
	}

	/// <summary>
	/// Updates an existing order
	/// </summary>
	/// <remarks>Removing product ids will be executed before adding new ones.</remarks>
	/// <response code="204">Order has been updated.</response>
	[HttpPatch("{orderId:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetail))]
	[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetail))]
	public async Task<ActionResult> UpdateOrderAsync([FromRoute] Guid orderId, [FromBody] UpdateOrderRequest request)
	{
		var command = new UpdateOrderCommand
		{
			OrderId = orderId,
			AddOrderLines = request.AddOrderLines?.Select(OrderLineMapper.Map).ToList() ?? [],
			RemoveProductIds = request.RemoveProductIds ?? [],
			NewDeliveryAddress = AddressMapper.Map(request.NewDeliveryAddress),
		};

		await _updateOrderHandler.HandleAsync(command);

		return NoContent();
	}


	[HttpGet("{orderId:guid}", Name = nameof(GetOrderAsync))]
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
