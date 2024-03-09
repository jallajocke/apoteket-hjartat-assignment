using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class Address
{
	/// <example>Jane Doe</example>
	[Required]
	public required string Name { get; set; }

	/// <example>Coolstreet 7</example>
	[Required]
	public required string Street { get; set; }

	/// <example>12345</example>
	[Required]
	public required string ZipCode { get; set; }

	/// <example>Sometown</example>
	[Required]
	public required string City { get; set; }
}
