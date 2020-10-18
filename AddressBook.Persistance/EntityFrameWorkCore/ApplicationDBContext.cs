using AddressBook.Domain.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Persistance.EntityFrameWorkCore
{
    public class ApplicationDBContext : DbContext
    {

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactDetail> ContactDetails { get; set; }

        public DbSet<ContactType> ContactTypes { get; set; }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
