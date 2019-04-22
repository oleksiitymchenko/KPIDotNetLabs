using System;

namespace CrudWebService.DTOModels
{
    public class SubjectInGroupDto : IBaseDto
    {
        public Guid Id { get; set; }

        public Guid SubjectId { get; set; }

        public Guid GroupId { get; set; }
    }
}
