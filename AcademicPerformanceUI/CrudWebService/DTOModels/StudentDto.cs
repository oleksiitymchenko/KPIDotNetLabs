using System;

namespace CrudWebService.DTOModels
{
    public class StudentDto : IBaseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public Guid GroupId { get; set; }
    }
}
