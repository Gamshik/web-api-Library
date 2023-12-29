namespace Entites.DataTransferObjects.IssueDtos
{
    public class IssueForCreateDto
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfReturn { get; set; }

        public int? BookId { get; set; }

        public int? ReaderId { get; set; }
    }
}
