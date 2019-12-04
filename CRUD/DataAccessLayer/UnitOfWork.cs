using CRUD.Core;
using CRUD.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context, IEmployeeRepository employees)
        {
            this._context = context;
            this.Employees = employees;
        }
        public IEmployeeRepository Employees { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}