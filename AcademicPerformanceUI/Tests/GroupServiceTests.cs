using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.MockRepositories;
using WcfRestService;
using WcfRestService.DTOModels;
using WcfRestService.ServiceInterfaces;

namespace Tests
{
    [TestClass]
    public class GroupServiceTests
    {
        private readonly IGroupService groupService;
        private GroupRepositoryMock repositoryMock = new GroupRepositoryMock();
        private readonly GroupDto testGroup = new GroupDto() { Id = Guid.NewGuid(), GroupName = "Test", StudyYear = 3, MaxStudents = 30 };
        public GroupServiceTests()
        {
            groupService = new GroupService(repositoryMock);
        }

        [TestMethod]
        public void Get_group_collection_returns_according_type()
        {
            groupService.CreateEntity(testGroup);
            var list = groupService.GetEntities();
            Assert.IsInstanceOfType(list, typeof(List<GroupDto>));
        }

        [TestMethod]
        public void Add_group_to_collection_not_empty()
        {
            groupService.CreateEntity(testGroup);
            var list = groupService.GetEntities();
            Assert.IsTrue(list.Count > 0);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Collection_returns_empty_if_nothing_added()
        {
            var list = groupService.GetEntities();
            Assert.IsTrue(list.Count == 0);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Clear_collection_returns_empty()
        {
            repositoryMock.Clear();
            var list = groupService.GetEntities();
            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod]
        public void Add_group_to_collection_returns_equal()
        {
            groupService.CreateEntity(testGroup);
            var list = groupService.GetEntities();
            var firstOrDefault = groupService.GetEntities().FirstOrDefault();
            Assert.IsTrue(testGroup.Id == firstOrDefault.Id);
            Assert.IsTrue(testGroup.GroupName == firstOrDefault.GroupName);
            Assert.IsTrue(testGroup.StudyYear == firstOrDefault.StudyYear);
            Assert.IsTrue(testGroup.MaxStudents == firstOrDefault.MaxStudents);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Remove_group_count_less()
        {
            groupService.CreateEntity(testGroup);
            groupService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName ="123", MaxStudents = 1, StudyYear = 2});
            groupService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var newId = Guid.NewGuid();
            groupService.CreateEntity(new GroupDto() { Id = newId, GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var previousCount = groupService.GetEntities().Count;
            groupService.DeleteEntity(newId.ToString());
            Assert.AreEqual(previousCount-1, groupService.GetEntities().Count);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Remove_group_item_removed()
        {
            groupService.CreateEntity(testGroup);
            groupService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            groupService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var newId = Guid.NewGuid();
            groupService.CreateEntity(new GroupDto() { Id = newId, GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var previousCount = groupService.GetEntities().Count;
            groupService.DeleteEntity(newId.ToString());
            Assert.IsNull(groupService.GetEntities().FirstOrDefault(item => item.Id == newId));
            repositoryMock.Clear();
        }


        [TestMethod]
        public void Update_group_collection_count_save()
        {
            groupService.CreateEntity(testGroup);
            groupService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            groupService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var newId = Guid.NewGuid();
            var entity = groupService.CreateEntity(new GroupDto() { Id = newId, GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var previousCount = groupService.GetEntities().Count;
            entity.GroupName = "12321321";
            var countOld = groupService.GetEntities().Count;
            groupService.UpdateEntity(entity);
            var countNew = groupService.GetEntities().Count;
            Assert.AreEqual(countNew, countOld);
            repositoryMock.Clear();
        }

        [TestMethod]
        public void Update_group_in_collection_name_changed()
        {
            groupService.CreateEntity(testGroup);
            groupService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            groupService.CreateEntity(new GroupDto() { Id = Guid.NewGuid(), GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            var newId = Guid.NewGuid();
            var entity = groupService.CreateEntity(new GroupDto() { Id = newId, GroupName = "123", MaxStudents = 1, StudyYear = 2 });
            entity.GroupName = "12321321";
            groupService.UpdateEntity(entity);

            Assert.AreEqual(entity.GroupName, groupService.GetEntities().FirstOrDefault(item => item.Id == newId).GroupName);

            repositoryMock.Clear();
        }
    }
}
