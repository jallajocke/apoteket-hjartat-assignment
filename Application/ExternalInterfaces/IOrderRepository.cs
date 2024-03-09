using Domain.Models;

namespace Application.ExternalInterfaces;

public interface IOrderRepository
{
	public Task<List<Order>> GetAllOrdersAsync();
}
