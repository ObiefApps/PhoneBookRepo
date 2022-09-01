using Microsoft.EntityFrameworkCore;

namespace PhonebookProject1.Models
{
    public static class SeedDb
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                if (context.Phones.Any())
                {
                    return;
                }
                context.Phones.AddRange(new PhoneBook
                {
                    Name = "Sample1",
                    Entries = new List<Entry>{  new Entry { Mobile = "071212354373", Name = "Sam"},
                    new Entry { Mobile = "08023132515", Name = "John"} }
                });
                // Look for any movies.
                if (context.Entries.Any())
                {
                    return;   // DB has been seeded
                }

                context.Entries.AddRange(
                    new Entry { Mobile = "090212354373", Name = "Sam", PhoneBookId = 2 },
                    new Entry { Mobile = "07023132515", Name = "John", PhoneBookId = 2 },
                    new Entry { Mobile = "091264364723", Name = "fred", PhoneBookId = 2 });


                context.SaveChanges();

            }
        }
    }
}
