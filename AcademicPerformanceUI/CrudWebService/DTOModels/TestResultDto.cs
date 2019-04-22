using System;

namespace CrudWebService.DTOModels
{
    public class TestResultDto : IBaseDto
    {
        public Guid Id { get; set; }

        public int Mark { get; set; }

        public Guid TestId { get; set; }

        public Guid StudentId { get; set; }
    }
}
