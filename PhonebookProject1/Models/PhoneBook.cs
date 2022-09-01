namespace PhonebookProject1.Models
{
    public class PhoneBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Entry> Entries { get; set; }
    }
}
