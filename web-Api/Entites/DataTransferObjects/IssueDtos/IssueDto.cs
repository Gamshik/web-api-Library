using Entites.DataTransferObjects.BookDtos;
using Entites.DataTransferObjects.ReaderDtos;

namespace Entites.DataTransferObjects.IssueDtos
{
    public class IssueDto
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfReturn { get; set; }

        public BookDto? Book { get; set; }

        public ReaderDto? Reader { get; set; }
    }
}
