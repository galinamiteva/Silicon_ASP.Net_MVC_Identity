

namespace Infrastructure.Models;

public class AddressModel
{
    public int Id { get; set; }
    public string Addressline_1 { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
