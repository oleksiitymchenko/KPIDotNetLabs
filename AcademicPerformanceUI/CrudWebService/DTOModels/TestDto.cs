using System;

namespace CrudWebService.DTOModels
{
    public class TestDto : IBaseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Theme { get; set; }

        public DateTime Date { get; set; }

        public Guid TeacherId { get; set; }
    }
}
