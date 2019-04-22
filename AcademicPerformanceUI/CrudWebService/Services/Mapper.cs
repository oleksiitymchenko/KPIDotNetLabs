using DataAccess.Interfaces;
using Model = DataAccess.Models;
using System;
using DataAccess.Models;
using CrudWebService.DTOModels;

namespace CrudWebService.Services
{
    public class Mapper
    {
        public IEntity MapToModel(IBaseDto entity)
        {
            if (entity == null) throw new FormatException();
            var dtoTypeName = entity.GetType().Name;
            switch (dtoTypeName)
            {
                case "GroupDto":
                    {
                        var groupDto = (GroupDto)entity;
                        var id = groupDto.Id;
                        var a = groupDto.GroupName;
                        var x = groupDto.MaxStudents;
                        var s = groupDto.StudyYear;
                        return new Group() { Id = groupDto.Id, GroupName = groupDto.GroupName, MaxStudents = groupDto.MaxStudents, StudyYear = groupDto.StudyYear };
                    }
                case "StudentDto":
                    {
                        var dtoEntity = (StudentDto)(IBaseDto)entity;
                        return new Student() { Id = dtoEntity.Id, FirstName = dtoEntity.FirstName, LastName = dtoEntity.LastName, PhoneNumber = dtoEntity.PhoneNumber, GroupId = dtoEntity.GroupId };
                    }
                case "SubjectDto":
                    {
                        var dtoEntity = (SubjectDto)(IBaseDto)entity;
                        var enumInt = (int)dtoEntity.FinalTestType;
                        return new Subject()
                        {
                            Id = dtoEntity.Id,
                            FinalTestType = (Model.FinalTestType)enumInt,
                            Hours = dtoEntity.Hours,
                            Name = dtoEntity.Name
                        };
                    }
                case "SubjectInGroupDto":
                    {
                        var dtoEntity = (SubjectInGroupDto)(IBaseDto)entity;
                        return new SubjectInGroup()
                        {
                            Id = dtoEntity.Id,
                            GroupId = dtoEntity.GroupId,
                            SubjectId = dtoEntity.SubjectId
                        };
                    }
                case "TeacherDto":
                    {
                        var dtoEntity = (TeacherDto)(IBaseDto)entity;
                        return new Teacher()
                        {
                            Id = dtoEntity.Id,
                            FirstName = dtoEntity.FirstName,
                            LastName = dtoEntity.LastName,
                            PhoneNumber = dtoEntity.PhoneNumber,
                            SubjectId = dtoEntity.SubjectId
                        };
                    }
                case "TestDto":
                    {
                        var dtoEntity = (TestDto)(IBaseDto)entity;
                        return new Test()
                        {
                            Id = dtoEntity.Id,
                            Date = dtoEntity.Date,
                            Name = dtoEntity.Name,
                            Theme = dtoEntity.Theme,
                            TeacherId = dtoEntity.TeacherId
                        };
                    }
                case "TestResultDto":
                    {
                        var dtoEntity = (TestResultDto)(IBaseDto)entity;
                        return new TestResult()
                        {
                            Id = dtoEntity.Id,
                            Mark = dtoEntity.Mark,
                            TestId = dtoEntity.TestId,
                            StudentId = dtoEntity.StudentId
                        };
                    }
                default: throw new NotSupportedException();
            }
        }

        public IBaseDto MapToDto<T>(IEntity entity)
        {
            var dtoTypeName = entity.GetType().Name;
            switch (dtoTypeName)
            {
                case "Group":
                    {
                        var groupDto = (Group)entity;
                        return new GroupDto() { Id = groupDto.Id, GroupName = groupDto.GroupName, MaxStudents = groupDto.MaxStudents, StudyYear = groupDto.StudyYear };
                    }
                case "Student":
                    {
                        var dtoEntity = (Student)entity;
                        return new StudentDto() { Id = dtoEntity.Id, FirstName = dtoEntity.FirstName, LastName = dtoEntity.LastName, PhoneNumber = dtoEntity.PhoneNumber, GroupId = dtoEntity.GroupId };
                    }
                case "Subject":
                    {
                        var dtoEntity = (Subject)entity;
                        var enumInt = (int)dtoEntity.FinalTestType;
                        return new SubjectDto()
                        {
                            Id = dtoEntity.Id,
                            FinalTestType = (DTOModels.FinalTestType)enumInt,
                            Hours = dtoEntity.Hours,
                            Name = dtoEntity.Name
                        };
                    }
                case "SubjectInGroup":
                    {
                        var dtoEntity = (SubjectInGroup)entity;
                        return new SubjectInGroupDto()
                        {
                            Id = dtoEntity.Id,
                            GroupId = dtoEntity.GroupId,
                            SubjectId = dtoEntity.SubjectId
                        };
                    }
                case "Teacher":
                    {
                        var dtoEntity = (Teacher)entity;
                        return new TeacherDto()
                        {
                            Id = dtoEntity.Id,
                            FirstName = dtoEntity.FirstName,
                            LastName = dtoEntity.LastName,
                            PhoneNumber = dtoEntity.PhoneNumber,
                            SubjectId = dtoEntity.SubjectId
                        };
                    }
                case "Test":
                    {
                        var dtoEntity = (Test)entity;
                        return new TestDto()
                        {
                            Id = dtoEntity.Id,
                            Date = dtoEntity.Date,
                            Name = dtoEntity.Name,
                            Theme = dtoEntity.Theme,
                            TeacherId = dtoEntity.TeacherId
                        };
                    }
                case "TestResult":
                    {
                        var dtoEntity = (TestResult)entity;
                        return new TestResultDto()
                        {
                            Id = dtoEntity.Id,
                            Mark = dtoEntity.Mark,
                            TestId = dtoEntity.TestId,
                            StudentId = dtoEntity.StudentId
                        };
                    }
                default: throw new NotSupportedException();
            }
        }
    }
}