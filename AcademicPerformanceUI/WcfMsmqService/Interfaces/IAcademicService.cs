using System.ServiceModel;

namespace WcfMsmqService.Interfaces
{
    [ServiceContract]
    public interface IAcademicService
    {
        #region drivers
        [OperationContract(IsOneWay = true)]
        void CreateSubject(string Subject);

        [OperationContract(IsOneWay = true)]
        void UpdateSubject(string updatedSubject);

        [OperationContract(IsOneWay = true)]
        void RemoveSubject(string SubjectId);
        #endregion

        #region shifts
        [OperationContract(IsOneWay = true)]
        void CreateGroup(string Group);

        [OperationContract(IsOneWay = true)]
        void UpdateGroup(string updatedGroup);

        [OperationContract(IsOneWay = true)]
        void RemoveGroup(string GroupId);
        #endregion

        #region routes
        [OperationContract(IsOneWay = true)]
        void CreateSiG(string SiG);

        [OperationContract(IsOneWay = true)]
        void UpdateSiG(string updatedSiG);

        [OperationContract(IsOneWay = true)]
        void RemoveSiG(string SiGId);
        #endregion
    }
}
