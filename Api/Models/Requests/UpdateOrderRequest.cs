namespace Api.Models.Requests;

public class UpdateOrderRequest
{
	/// <summary>
	/// Change the address to where the order should be delivered.
	/// </summary>
	public Address? NewDeliveryAddress { get; set; }

	/// <summary>
	/// New order lines to be added.
	/// </summary>
	public List<OrderLine>? AddOrderLines { get; set; }

	/// <summary>
	/// Product ids of order lines that should be removed.
	/// </summary>
	public List<Guid>? RemoveProductIds { get; set; }
}
