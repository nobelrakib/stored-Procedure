using finalproject2.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace finalproject2.Core.Contexts
{
    public interface IPracticeContext
    {
        DbSet<Manager> Managers { get; set; }
    }
}
