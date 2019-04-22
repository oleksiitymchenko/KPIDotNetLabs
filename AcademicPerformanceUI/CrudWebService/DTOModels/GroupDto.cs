using System;

namespace CrudWebService.DTOModels
{
    public class GroupDto: IBaseDto
    {
        public Guid Id { get; set; }

        public string GroupName { get; set; }

        public int MaxStudents { get; set; }

        public int StudyYear { get; set; }
    }
}
