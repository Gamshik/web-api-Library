﻿namespace Entites.DataTransferObjects.ReaderDtos
{
    public class ReaderForUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
    }
}