namespace Entites.DataTransferObjects.BookDtos
{
    public class BookForCreateDto
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Genre { get; set; }

        public int? AuthorId { get; set; }
    }
}
