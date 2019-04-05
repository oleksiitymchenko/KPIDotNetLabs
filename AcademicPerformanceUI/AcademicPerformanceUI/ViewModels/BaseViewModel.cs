using Services.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DataAccess.Interfaces;
using Services;

namespace AcademicPerformanceUI.ViewModels
{
    public abstract class BaseViewModel<Entity>:INotifyPropertyChanged where Entity: IEntity
    {
        public BaseViewModel()
        {
            Entities = new ObservableCollection<Entity>(Repository.GetAllEntitiesAsync().Result);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ObservableCollection<Entity> _Entities;
        public Entity _SelectedEntity;

        protected virtual IUnitOfWork UnitOfWork
        {
            get => UnitOfWorkFactory.GetUnitOfWork();
        }

        protected virtual IRepository<Entity> Repository
        {
            get => UnitOfWork.GetRepositoryByEntityType<Entity>();
        }

        public virtual Entity SelectedEntity
        {
            get => _SelectedEntity;
            set => SetProperty(ref _SelectedEntity, value);
        }

        public virtual ObservableCollection<Entity> Entities
        {
            get => _Entities;
            set => SetProperty(ref _Entities, value);
        }

        public async virtual void AddData()
        {
            var newEntity = (Entity)_SelectedEntity.Clone();
            newEntity.Id = Guid.NewGuid();
            Entities.Add(newEntity);
            await Repository.CreateAsync(newEntity);
            var x  = (IEntity)newEntity;
            SelectedEntity = Repository.CreateEmptyObject();
        }

        public async virtual void RemoveData()
        {
            await Repository.DeleteAsync(_SelectedEntity.Id);
            Entities.Remove(_SelectedEntity);
            SelectedEntity = Repository.CreateEmptyObject();
        }

        public async virtual void UpdateData()
        {
            await Repository.UpdateAsync(SelectedEntity);
            SelectedEntity = Repository.CreateEmptyObject();
        }
        public abstract void LoadConnectedData();

        public virtual void SaveEntity()
        {
            var service = SerializationServiceFactory.GetSerializationService();
            service.SerializeEntity(SelectedEntity, $"{typeof(Entity)}");
        }

        public virtual async void SaveAllEntities()
        {
            var service = SerializationServiceFactory.GetSerializationService();
            List<Entity> entities = new List<Entity>();

            foreach (var item in Entities)
            {
                await Repository.CreateAsync(item);
            }
            service.SerializeEntity(entities, $"{typeof(Entity)}List");
        }

        public virtual void DeserializeList(string path)
        {
            var service = SerializationServiceFactory.GetSerializationService();
            List<Entity> entities = new List<Entity>();
            entities = service.DeserizalizeEntity<List<Entity>>(path);
            Repository.ReplaceCollection(entities);
            LoadConnectedData();
        }
    }
}
