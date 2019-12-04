using CRUD.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }

        int Complete();
    }
}