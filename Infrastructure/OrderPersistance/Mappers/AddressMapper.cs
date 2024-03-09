using Domain.Models;
using Infra = Infrastructure.OrderPersistance.Models;

namespace Infrastructure.OrderPersistance.Mappers;

public class AddressMapper
{
	public static Infra.Address Map(Address address)
	{
		return new Infra.Address
		{
			Name = address.Name,
			Street = address.Street,
			City = address.City,
			ZipCode = address.ZipCode,
		};
	}

	public static Address Map(Infra.Address address)
	{
		return new Address
		{
			Name = address.Name,
			Street = address.Street,
			City = address.City,
			ZipCode = address.ZipCode,
		};
	}
}
