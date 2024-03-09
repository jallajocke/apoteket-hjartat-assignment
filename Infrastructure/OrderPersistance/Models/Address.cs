namespace Infrastructure.OrderPersistance.Models;

public class Address
{
	public required string Name { get; set; }
	public required string Street { get; set; }
	public required string ZipCode { get; set; }
	public required string City { get; set; }
}
