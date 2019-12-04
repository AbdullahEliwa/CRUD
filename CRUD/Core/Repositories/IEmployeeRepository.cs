using CRUD.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}