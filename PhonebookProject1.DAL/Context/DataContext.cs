using Microsoft.EntityFrameworkCore;

namespace PhonebookProject1.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<PhoneBook> Phones { get; set; }
        public DbSet<Entry> Entries { get; set; }
    }
}
