using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class CustomerContactsRepository(DataContext context) : BaseRepository<CustomerContactsEntity>(context), ICustomerContactsRepository

{
    private readonly DataContext _context = context;
}
