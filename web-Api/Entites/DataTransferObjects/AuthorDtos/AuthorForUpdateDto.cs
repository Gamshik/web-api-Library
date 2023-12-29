namespace Entites.DataTransferObjects.AuthorDtos
{
    public class AuthorForUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string? Biography { get; set; }
    }
}
