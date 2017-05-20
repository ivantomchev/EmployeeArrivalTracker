namespace EmployeeArrivalTracker.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        private ICollection<Team> teams;

        public Employee()
        {
            this.teams = new HashSet<Team>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Role { get; set; }

        [Index]
        public DateTime? ArrivalDate { get; set; }

        public int? ManagerId { get; set; }

        public virtual Employee Manager { get; set; }

        public virtual ICollection<Team> Teams
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
    }
}
