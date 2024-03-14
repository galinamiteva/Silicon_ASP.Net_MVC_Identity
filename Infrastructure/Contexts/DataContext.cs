
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)

{
    public DbSet<AddressEntity> Addresses { get; set; }= null!;
    public DbSet<UserEntity> Users { get; set; } = null!;

    public DbSet<FeatureEntity> Features { get; set; }
    public DbSet<FeatureItemEntity> FeaturesItems { get; set; }
}
