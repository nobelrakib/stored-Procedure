using finalproject2.Core.Entities;
using finalproject2.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace finalproject2.Core.Services
{
    public class ManagerService : IManagerService
    {
        private IPracticeUnitOfWork _storeUnitOfWork;

        public ManagerService(IPracticeUnitOfWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddNewManager(Manager manager)
        {
            if (manager == null || string.IsNullOrWhiteSpace(manager.Name))
                throw new InvalidOperationException("Category name is missing");

            _storeUnitOfWork.ManagerRepositroy.Add(manager);
            _storeUnitOfWork.Save();
        }

        public void DeleteManager(int id)
        {
            _storeUnitOfWork.ManagerRepositroy.Remove(id);
            _storeUnitOfWork.Save();
        }

        public void EditCategory(Manager manager)
        {
            var oldmanager = _storeUnitOfWork.ManagerRepositroy.GetById(manager.ID);
            oldmanager.Name = manager.Name;
            _storeUnitOfWork.Save();
        }

        public IEnumerable<Manager> GetManager(
            int pageIndex,
            int pageSize,
            string searchText,
            out int total,
            out int totalFiltered)
        {
            return _storeUnitOfWork.ManagerRepositroy.Get(
                out total,
                out totalFiltered,
                x => x.Name.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }

        public Manager GetManager(int id)
        {
            return _storeUnitOfWork.ManagerRepositroy.GetById(id);
        }
    }
}
