using Domain.Models;

namespace Application.ExternalInterfaces;

public interface IOrderRepository
{
	public Task CreateOrderAsync(Order order);
	public Task<List<Order>> GetAllOrdersAsync();
	public Task<Order?> GetOrderAsync(Guid orderId);
}
