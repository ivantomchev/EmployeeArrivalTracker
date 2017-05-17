namespace EmployeeArrivalTracker.Services.Data
{
    using EmployeeArrivalTracker.Data.Models;
    using EmployeeArrivalTracker.Data.Repositories;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeesService
    {
        private readonly DbRepository<Employee> employeesRepository;

        public EmployeesService()
        {
            this.employeesRepository = new DbRepository<Employee>();
        }

        public Employee GetById(int employeeId)
        {
            return this.employeesRepository.GetById(employeeId);
        }

        public void Update(Employee employee, bool saveChanges)
        {
            this.employeesRepository.Update(employee);
            if (saveChanges)
            {
                this.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return this.employeesRepository.All();
        }

        public IEnumerable<Employee> GetAllArrived()
        {
            var arrivedEmployees = this.employeesRepository
                .All(false)
                .Where(e => e.ArrivalDate != null);

            return arrivedEmployees;
        }

        public void ResetArrivalDate()
        {
            var employees = this.GetAllArrived();
            foreach (var employee in employees)
            {
                employee.ArrivalDate = null;
                this.employeesRepository.Update(employee);
            }

            this.employeesRepository.SaveChanges();
        }

        public void SaveChanges()
        {
            this.employeesRepository.SaveChanges();
        }
    }
}
