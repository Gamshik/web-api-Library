namespace Entites.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Genre { get; set; }

        public int? AuthorId { get; set; }
        public Author? Author { get; set; }

        public IEnumerable<Issue>? Issues { get; set; }
    }
}
