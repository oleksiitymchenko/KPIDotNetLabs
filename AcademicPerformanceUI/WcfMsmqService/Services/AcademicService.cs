using DataAccess.Models;
using DataAccess.SqlDbConnection;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.ServiceModel;
using WcfMsmqService.Interfaces;

namespace WcfMsmqService.Services
{
    public class AcademicService:IAcademicService
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\olexi\TestDb.mdf;Integrated Security=True;Connect Timeout=30";
        public static Lazy<SqlDbConnectionUnitOfWork> UnitOfWork = new Lazy<SqlDbConnectionUnitOfWork>(() => new SqlDbConnectionUnitOfWork(connectionString));

        #region drivers

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void CreateSubject(string driver)
        {
            try
            {
                Console.WriteLine("Recieved subject: " + driver);

                _ = UnitOfWork.Value.SubjectRepostitory.CreateAsync(JsonConvert.DeserializeObject<Subject>(driver)).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void UpdateSubject(string driver)
        {
            try
            {
                Console.WriteLine("Recieved updated subject: " + driver);
                var driverObj = JsonConvert.DeserializeObject<Subject>(driver);

                var guid = driverObj.Id;
                var item = UnitOfWork.Value.SubjectRepostitory.GetAllEntitiesAsync().Result.Where(x => x.Id == guid).FirstOrDefault();

                item.Name = driverObj.Name;
                item.FinalTestType = driverObj.FinalTestType;
                item.Hours = driverObj.Hours;

                _ = UnitOfWork.Value.SubjectRepostitory.UpdateAsync(item).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void RemoveSubject(string driverId)
        {
            try
            {
                Console.WriteLine("Remove subject with id: " + driverId);
                var guid = Guid.Parse(driverId);
                UnitOfWork.Value.SubjectRepostitory.DeleteAsync(guid);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        #endregion

        #region shifts

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void CreateSiG(string shift)
        {
            try
            {
                Console.WriteLine("Recieved sig: " + shift);

                _ = UnitOfWork.Value.SubjectInGroupRepository.CreateAsync(JsonConvert.DeserializeObject<SubjectInGroup>(shift)).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void UpdateSiG(string shift)
        {
            try
            {
                Console.WriteLine("Recieved updated sig: " + shift);
                var shiftObj = JsonConvert.DeserializeObject<SubjectInGroup>(shift);

                var guid = shiftObj.Id;
                var item = UnitOfWork.Value.SubjectInGroupRepository.GetAllEntitiesAsync().Result.FirstOrDefault(x => x.Id == guid);

                item.GroupId = shiftObj.GroupId;
                item.SubjectId = shiftObj.SubjectId;

                _ = UnitOfWork.Value.SubjectInGroupRepository.UpdateAsync(item).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void RemoveSiG(string shiftId)
        {
            try
            {
                Console.WriteLine("Remove sig with id: " + shiftId);
                var guid = Guid.Parse(shiftId);
                _ = UnitOfWork.Value.SubjectInGroupRepository.DeleteAsync(guid).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        #endregion

        #region routes

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void CreateGroup(string route)
        {
            try
            {
                Console.WriteLine("Recieved Group: " + route);

                var routeObj = JsonConvert.DeserializeObject<Group>(route);


                _ = UnitOfWork.Value.GroupRepository.CreateAsync(routeObj).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void UpdateGroup(string route)
        {
            try
            {
                Console.WriteLine("Recieved updated Group: " + route);
                var routeObj = JsonConvert.DeserializeObject<Group>(route);

                var guid = routeObj.Id;

                var item = UnitOfWork.Value.GroupRepository.GetAllEntitiesAsync().Result.FirstOrDefault(x => x.Id == guid);

                item.GroupName = routeObj.GroupName;
                item.StudyYear = routeObj.StudyYear;
                item.MaxStudents = routeObj.MaxStudents;


                _ = UnitOfWork.Value.GroupRepository.UpdateAsync(item).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);

            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void RemoveGroup(string routeId)
        {
            try
            {
                Console.WriteLine("Remove Group with id: " + routeId);
                var guid = Guid.Parse(routeId);
                _ = UnitOfWork.Value.GroupRepository.DeleteAsync(guid).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        #endregion
    }
}
