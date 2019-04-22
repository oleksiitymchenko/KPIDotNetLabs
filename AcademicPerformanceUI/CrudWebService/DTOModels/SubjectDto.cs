using System;

namespace CrudWebService.DTOModels
{
    public class SubjectDto : IBaseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public FinalTestType FinalTestType { get; set; }

        public double Hours { get; set; }
    }
}
