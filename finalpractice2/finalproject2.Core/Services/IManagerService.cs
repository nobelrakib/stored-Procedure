using finalproject2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace finalproject2.Core.Services
{
    public interface IManagerService
    {
        void AddNewManager(Manager manager);
        void DeleteManager(int id);
        void EditCategory(Manager manager);
        IEnumerable<Manager> GetManager(
           int pageIndex,
           int pageSize,
           string searchText,
           out int total,
           out int totalFiltered);
        Manager GetManager(int id);
    }
}
