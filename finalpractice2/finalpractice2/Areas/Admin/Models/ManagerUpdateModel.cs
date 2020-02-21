using Autofac;
using finalproject2.Core.Entities;
using finalproject2.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalpractice2.Areas.Admin.Models
{
    public class ManagerUpdateModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private IManagerService _managerService;

        public ManagerUpdateModel()
        {
            _managerService = Startup.AutofacContainer.Resolve<IManagerService>();
        }

        public ManagerUpdateModel(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public void AddNewManager()
        {
            try
            {
                _managerService.AddNewManager(new Manager
                {
                    Name = this.Name
                });

                Notification = new NotificationModel("Success!", "Category successfuly created", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to create category, please try again",
                    NotificationType.Fail);
            }
        }

        public void EditManager()
        {
            try
            {
                _managerService.EditCategory(new Manager
                {
                    ID = this.Id,
                    Name = this.Name
                });

                Notification = new NotificationModel("Success!", "Category successfuly updated", NotificationType.Success);
            }
            catch (InvalidOperationException iex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update category, please provide valid name",
                    NotificationType.Fail);
            }
            catch (Exception ex)
            {
                Notification = new NotificationModel(
                    "Failed!",
                    "Failed to update category, please try again",
                    NotificationType.Fail);
            }
        }

        public void Load(int id)
        {
            var category = _managerService.GetManager(id);
            if (category != null)
            {
                Id = category.ID;
                Name = category.Name;
            }
        }
    }
}
