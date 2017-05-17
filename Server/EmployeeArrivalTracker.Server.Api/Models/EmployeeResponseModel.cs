namespace EmployeeArrivalTracker.Server.Api.Models
{
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeResponseModel
    {
        private IEnumerable<string> teams;

        public EmployeeResponseModel()
        {
            this.teams = new List<string>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Role { get; set; }

        public DateTime? ArrivalDate { get; set; }

        public string Manager { get; set; }

        public IEnumerable<string> Teams
        {
            get
            {
                return this.teams;
            }
            set
            {
                this.teams = value;
            }
        }

        public static EmployeeResponseModel CreateMapFromEntity(Employee employee)
        {
            return new EmployeeResponseModel
            {
                Id = employee.Id,
                Name = employee.Name,
                SurName = employee.SurName,
                Age = employee.Age,
                Email = employee.Email,
                ArrivalDate = employee.ArrivalDate,
                Manager = employee.Manager == null ? null : employee.Manager.Name,
                Role = employee.Role,
                Teams = employee.Teams.Select(t => t.Name)
            };
        }
    }
}