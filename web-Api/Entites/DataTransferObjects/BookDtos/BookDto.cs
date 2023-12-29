using Entites.DataTransferObjects.AuthorDtos;

namespace Entites.DataTransferObjects.BookDtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Genre { get; set; }

        public AuthorDto? Author { get; set; }
    }
}
