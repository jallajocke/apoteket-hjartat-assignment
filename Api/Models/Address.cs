using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class Address
{
	[Required]
	public required string Name { get; set; }

	[Required]
	public required string Street { get; set; }

	[Required]
	public required string ZipCode { get; set; }

	[Required]
	public required string City { get; set; }
}
