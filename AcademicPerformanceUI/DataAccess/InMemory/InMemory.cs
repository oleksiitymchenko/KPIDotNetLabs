using DataAccess.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public static class InMemory
    {

        static InMemory()
        {
            Groups = new List<Group>();
            Students = new List<Student>();
            Subjects = new List<Subject>();
            Tests = new List<Test>();
            SubjectInGroups = new List<SubjectInGroup>();
            TestResults = new List<TestResult>();
            Teachers = new List<Teacher>();

            Groups.Add(new Group()
            {
                Id = Guid.NewGuid(),
                GroupName = "Test",
                StudyYear = 2,
                MaxStudents = 30
            });
        }
        public static List<Group> Groups;
        public static List<Student> Students;
        public static List<Subject> Subjects;
        public static List<Teacher> Teachers;
        public static List<Test> Tests;
        public static List<SubjectInGroup> SubjectInGroups;
        public static List<TestResult> TestResults;

        public static IEntity CreateNew(Type type)
        {
            if (type == typeof(Group)) return new Group();
            if (type == typeof(Student)) return new Student();
            if (type == typeof(Subject)) return new Subject();
            if (type == typeof(Teacher)) return new Teacher();
            if (type == typeof(Test)) return new Test();
            if (type == typeof(SubjectInGroup)) return new SubjectInGroup();
            if (type == typeof(TestResult)) return new TestResult();

            throw new Exception("No such types");
        }

        public static void AddData(IEntity entity)
        {
            switch (entity)
            {
                case Group group:                   Groups.Add(group); break;
                case Student student:               Students.Add(student); break;
                case Subject subject:               Subjects.Add(subject); break;
                case Teacher teacher:               Teachers.Add(teacher); break;
                case Test test:                     Tests.Add(test); break;
                case SubjectInGroup subjectInGroup: SubjectInGroups.Add(subjectInGroup); break;
                case TestResult testResult:         TestResults.Add(testResult); break;
                default:  throw new Exception("There is no such type");
            }
        }

        public static void RemoveData(IEntity entity)
        {
            Students = Students.Where(x => x.Id != entity.Id)
                               .ToList();
            Groups = Groups.Where(x => x.Id != entity.Id)
                               .ToList();
            Subjects = Subjects.Where(x => x.Id != entity.Id)
                               .ToList();
            Teachers = Teachers.Where(x => x.Id != entity.Id)
                               .ToList();
            Tests = Tests.Where(x => x.Id != entity.Id)
                               .ToList();
            SubjectInGroups = SubjectInGroups.Where(x => x.Id != entity.Id)
                               .ToList();
            TestResults = TestResults.Where(x => x.Id != entity.Id)
                               .ToList();
        }

        public static void UpdateData(IEntity entity)
        {
            switch (entity)
            {
                case Group group:
                    {
                        var oldEntity = Groups.Find(o => o.Id == entity.Id);
                        oldEntity = (Group)entity.Clone();
                        break;
                    }
                case Student student:
                    {
                        var oldEntity = Students.Find(o => o.Id == entity.Id);
                        oldEntity = (Student)entity.Clone();
                        break;
                    }
                case Subject subject:
                    {
                        var oldEntity = Subjects.Find(o => o.Id == entity.Id);
                        oldEntity = (Subject)entity.Clone();
                        break;
                    }
                case Teacher teacher:
                    {
                        var oldEntity = Teachers.Find(o => o.Id == entity.Id);
                        oldEntity = (Teacher)entity.Clone();
                        break;
                    }
                case Test test:
                    {
                        var oldEntity = Tests.Find(o => o.Id == entity.Id);
                        oldEntity = (Test)entity.Clone();
                        break;
                    }
                case SubjectInGroup subjectInGroup:
                    {
                        var oldEntity = SubjectInGroups.Find(o => o.Id == entity.Id);
                        oldEntity = (SubjectInGroup)entity.Clone();
                        break;
                    }
                case TestResult testResult:
                    {
                        var oldEntity = TestResults.Find(o => o.Id == entity.Id);
                        oldEntity = (TestResult)entity.Clone();
                        break;
                    }
                default: throw new Exception("There is no such type");
            }

            
        }
        public static void ReplaceCollection<T>(List<T> entities) where T: IEntity
        {
            var type = typeof(T);
            if (type == typeof(Group))
            {
                Groups.Clear();
            }
            if (type == typeof(Student))
            {
                Students.Clear();
            }
            if (type == typeof(Subject))
            {
                Subjects.Clear();
            }
            if (type == typeof(Teacher))
            {
                Teachers.Clear();
            }
            if (type == typeof(Test))
            {
                Tests.Clear();
            }
            if (type == typeof(SubjectInGroup))
            {
                SubjectInGroups.Clear();
            }
            if (type == typeof(TestResult))
            {
                TestResults.Clear();
            }
            entities.ForEach(item => AddData(item));
            //throw new Exception("No such types");
        }
    }
}
