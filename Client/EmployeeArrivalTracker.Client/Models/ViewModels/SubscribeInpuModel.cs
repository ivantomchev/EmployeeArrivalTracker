namespace EmployeeArrivalTracker.Client.Models.ViewModels 
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SubscribeInpuModel 
    {
        [Required]
        public DateTime Date { get; set; }
    }
}