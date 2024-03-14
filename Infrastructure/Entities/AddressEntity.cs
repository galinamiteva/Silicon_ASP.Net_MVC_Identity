
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }
    

    public string Addressline_1 { get; set; } = null!;
    public string? Addressline_2 { get; set; }

    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;


    public string? UserId { get; set; }
    public ICollection<UserEntity> Users { get; set; } = [];
}
