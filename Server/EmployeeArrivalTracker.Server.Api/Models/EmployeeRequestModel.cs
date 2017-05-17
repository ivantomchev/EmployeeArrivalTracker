namespace EmployeeArrivalTracker.Server.Api.Models
{
    using System;

    public class EmployeeRequestModel
    {
        public int EmployeeId { get; set; }

        public DateTime When { get; set; }
    }
}