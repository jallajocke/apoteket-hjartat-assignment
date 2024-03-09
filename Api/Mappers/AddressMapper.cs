using Domain.Models;
using ApiModels = Api.Models;

namespace Api.Mappers;

public class AddressMapper
{
	public static ApiModels.Address Map(Address address)
	{
		return new ApiModels.Address
		{
			Name = address.Name,
			Street = address.Street,
			City = address.City,
			ZipCode = address.ZipCode,
		};
	}
}
