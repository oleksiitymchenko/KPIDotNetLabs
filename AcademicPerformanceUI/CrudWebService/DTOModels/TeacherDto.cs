using System;

namespace CrudWebService.DTOModels
{
    public class TeacherDto : IBaseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public Guid SubjectId { get; set; }
    }
}
