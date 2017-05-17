namespace EmployeeArrivalTracker.Client.Models.ViewModels
{
    using DTO;
    using System;

    public class EmployeeIndexViewModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Role { get; set; }

        public DateTime? ArrivalDate { get; set; }

        public static EmployeeIndexViewModel MapFromEntity(EmployeeDTO employee)
        {
            return new EmployeeIndexViewModel
            {
                Name = employee.Name,
                SurName = employee.SurName,
                Age = employee.Age,
                Email = employee.Email,
                Role = employee.Role,
                ArrivalDate = employee.ArrivalDate
            };
        }
    }
}