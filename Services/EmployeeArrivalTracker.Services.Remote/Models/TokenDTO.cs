namespace EmployeeArrivalTracker.Services.Remote.Models
{
    using System;

    public class TokenDTO
    {
        public string Token { get; set; }

        //[JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Expires { get; set; }
    }
}
