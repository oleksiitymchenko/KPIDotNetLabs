using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.InMemoryDb
{
    public static class InMemoryLists
    {
        static InMemoryLists()
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
    }
}
