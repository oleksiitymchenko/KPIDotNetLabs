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
            try
            {
                var newEntity = (Entity)_SelectedEntity.Clone();
                newEntity.Id = Guid.NewGuid();

                var res = await Repository.CreateAsync(newEntity);
                if (res == null) return;

                Entities.Add(newEntity);
                var x = (IEntity)newEntity;
                SelectedEntity = Repository.CreateEmptyObject();
            }
            catch (Exception ex) 
            {
            }
        }

        public async virtual void RemoveData()
        {
            try
            {
                var result  = await Repository.DeleteAsync(_SelectedEntity.Id);
                if (!result) return;

                Entities.Remove(_SelectedEntity);
                SelectedEntity = Repository.CreateEmptyObject();
            }
            catch (Exception)
            {
            }
        }

        public async virtual void UpdateData()
        {
            try
            {
                var res = await Repository.UpdateAsync(SelectedEntity);
                if (res == null) return;
                SelectedEntity = Repository.CreateEmptyObject();
            }
            catch (Exception ex)
            {
            }
        }
        public abstract void LoadConnectedData();

        public virtual void SaveEntity()
        {
            try
            {
                var service = SerializationServiceFactory.GetSerializationService();
                service.SerializeEntity(SelectedEntity, $"{typeof(Entity)}");
            }
            catch (Exception)
            {
            }
        }

        public virtual async void SaveAllEntities()
        {
            try
            {
                var service = SerializationServiceFactory.GetSerializationService();
                List<Entity> entities = new List<Entity>();

                foreach (var item in Entities)
                {
                    await Repository.CreateAsync(item);
                }
                service.SerializeEntity(entities, $"{typeof(Entity)}List");
            }
            catch (Exception)
            {

            }
        }

        public virtual void DeserializeList(string path)
        {
            try
            {
                var service = SerializationServiceFactory.GetSerializationService();
                List<Entity> entities = new List<Entity>();
                entities = service.DeserizalizeEntity<List<Entity>>(path);
                Repository.AddCollection(entities);
                LoadConnectedData();
            }
            catch (Exception)
            {

            }
        }
    }
}
