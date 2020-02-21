using Autofac;
using finalpractice2.Models;
using finalproject2.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalpractice2.Areas.Admin.Models
{
    public class ManagerViewModel
    {
        public int Id { get; set; }
        private IManagerService _managerService;

        public ManagerViewModel()
        {
            _managerService = Startup.AutofacContainer.Resolve<IManagerService>();
        }

        public ManagerViewModel(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public object GetManagers(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _managerService.GetManager(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.ID.ToString(),
                                record.Name,
                                record.ID.ToString()
                        }
                    ).ToArray()

            };
        }

        public void Delete(int id)
        {
           _managerService.DeleteManager(id);
        }
    }
}
