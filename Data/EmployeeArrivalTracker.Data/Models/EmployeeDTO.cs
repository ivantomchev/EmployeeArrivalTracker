namespace EmployeeArrivalTracker.Data.Models
{ 
    using System.Collections.Generic;

    internal class EmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public ICollection<string> Teams { get; set; }

        public int? ManagerId { get; set; }
    }
}
