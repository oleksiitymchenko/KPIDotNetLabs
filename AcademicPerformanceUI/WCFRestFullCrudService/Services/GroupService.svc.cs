using System;
using System.Collections.Generic;
using WCFRestFullCrudService.DTOModels;

namespace WCFRestFullCrudService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class GroupService : IGroupService // BaseService<Group>,
    {
        public Group CreateEntity(Group entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(string id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetEntities()
        {
            return new List<Group>() { new Group() { GroupName = "asdasdsa", MaxStudents = 20, StudyYear = 2 },
            new Group() { GroupName = "11111", MaxStudents = 11, StudyYear = 1 }};
        }

        public bool UpdateEntity(Group entity)
        {
            throw new NotImplementedException();
        }

        string IGroupService.GetEntities()
        {
            return "TESTETEASDASDASDASDS";
        }
    }
}