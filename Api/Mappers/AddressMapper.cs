using Domain.Models;
using System.Diagnostics.CodeAnalysis;
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

	[return: NotNullIfNotNull(nameof(address))]
	public static Address? Map(ApiModels.Address? address)
	{
		if (address == null) return null;

		return new Address
		{
			Name = address.Name,
			Street = address.Street,
			City = address.City,
			ZipCode = address.ZipCode,
		};
	}
}
