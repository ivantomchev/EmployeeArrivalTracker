namespace EmployeeArrivalTracker.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Token
    {

        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime ExpirationDate { get; set; }

        //[NotMapped]
        //public bool IsExpired
        //{
        //    get
        //    {
        //        return this.ExpirationDate < DateTime.Now;
        //    }
        //}
    }
}
