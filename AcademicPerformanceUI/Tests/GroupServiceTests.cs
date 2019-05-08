using System;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.MockRepositories;
using WcfRestService;
using WcfRestService.ServiceInterfaces;

namespace Tests
{
    [TestClass]
    public class GroupServiceTests
    {
        private readonly IGroupService groupService;
        private readonly Group testGroup = new Group() { Id = Guid.NewGuid(), GroupName = "Test", StudyYear = 3, MaxStudents = 30 };
        public GroupServiceTests()
        {
            groupService = new GroupService(new GroupRepositoryMock());
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
