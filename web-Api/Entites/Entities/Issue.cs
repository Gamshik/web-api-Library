namespace Entites.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfReturn { get; set; }

        public int? BookId { get; set; }
        public Book? Book { get; set; }

        public int? ReaderId { get; set; }
        public Reader? Reader { get; set; }
    }
}
