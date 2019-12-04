using CRUD.Core.Domain;
using CRUD.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD.DataAccessLayer.Repositories
{
    public class EmployeeRepository :Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context)
            : base(context) {  }


    }
}