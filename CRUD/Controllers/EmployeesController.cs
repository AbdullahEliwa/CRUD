using CRUD.Core;
using CRUD.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        #region Read Operations
        // GET: Employees
        public ActionResult Index()
        {
            var employees = _unitOfWork.Employees.GetAll();
            return View(employees);
        }

        public ActionResult GetEmployee(int id)
        {
            var employee = _unitOfWork.Employees.Get(id);
            if (employee is null)
                return HttpNotFound();
            return View(employee);
        }
        #endregion

        #region Create operation
        public ActionResult CreateEmployee()
        {
            var employee = new Employee { EmployeeId = 0 };
            return View("EmployeeForm", employee);
        }
        #endregion

        #region Edit operation
        public ActionResult EditEmployee(int id)
        {
            var employee = _unitOfWork.Employees.Get(id);
            if (employee is null)
                return HttpNotFound();
            return View("EmployeeForm", employee);
        }
        #endregion

        #region Save 
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
                return View("EmployeeForm", employee);
            if (employee.EmployeeId == 0)
            {
                employee.HireDate = DateTime.UtcNow.AddHours(2);
                _unitOfWork.Employees.Add(employee);
            }
            else
            {
                var employeeInDb = _unitOfWork.Employees.Get(employee.EmployeeId);
                employeeInDb.FirstName = employee.FirstName;
                employeeInDb.LastName = employee.LastName;

            }
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        #endregion


        #region Delete Operation
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _unitOfWork.Employees.Get(id);
            if (employee is null)
                return HttpNotFound();
            _unitOfWork.Employees.Delete(employee);
            _unitOfWork.Complete();
            return RedirectToAction("Index");

        }
        #endregion
    }
}