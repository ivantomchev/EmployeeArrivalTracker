namespace EmployeeArrivalTracker.Client.Models.DTO
{
    using System;
    using System.Collections.Generic;

    public class EmployeeDTO
    {
        private IEnumerable<string> teams;

        public EmployeeDTO()
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
    }
}