namespace Entites.DataTransferObjects.BookDtos
{
    public class BookForUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Genre { get; set; }

        public int? AuthorId { get; set; }
    }
}
