

using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class AddressRepostory(DataContext context) : Repo<AddressEntity>(context)
{
    private readonly DataContext _context = context;
}
