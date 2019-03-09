using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess
{
    public static class ObjectLists
    {
        public static List<Group> Groups = new List<Group>();
        public static List<Student> Students = new List<Student>();
        public static List<Subject> Subjects = new List<Subject>();
        public static List<Teacher> Teachers = new List<Teacher>();
        public static List<Test> Tests = new List<Test>();
        public static List<SubjectInGroup> SubjectInGroups = new List<SubjectInGroup>();
        public static List<TestResult> TestResults = new List<TestResult>();
    }
}
