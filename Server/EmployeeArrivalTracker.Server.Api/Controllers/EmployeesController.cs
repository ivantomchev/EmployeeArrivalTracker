namespace EmployeeArrivalTracker.Server.Api.Controllers
{
    using Models;
    using Services.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        private readonly EmployeesService employeesService;
        private readonly TokensService tokensService;

        public EmployeesController()
        {
            this.employeesService = new EmployeesService();
            this.tokensService = new TokensService();
        }

        [HttpGet]
        [Route("arrived")]
        public IHttpActionResult Get()
        {
            var arrivedEmployeesResponseModel = this.employeesService.GetAllArrived().Select(e => EmployeeResponseModel.CreateMapFromEntity(e));

            return Ok(arrivedEmployeesResponseModel);
        }

        [HttpPost]
        public IHttpActionResult Post(IEnumerable<EmployeeRequestModel> model)
        {
            var tokenHeader = this.Request.Headers.GetValues("X-Fourth-Token").FirstOrDefault();
            if (string.IsNullOrEmpty(tokenHeader))
            {
                return Unauthorized();
            }

            var token = this.tokensService.GetByContent(tokenHeader);
            if (token != null && token.ExpirationDate < DateTime.Now)
            {
                return Unauthorized();
            }

            foreach (var employee in model)
            {
                var currentEmployee = this.employeesService.GetById(employee.EmployeeId + 1);
                currentEmployee.ArrivalDate = employee.When;
                this.employeesService.Update(currentEmployee, false);
            }

            this.employeesService.SaveChanges();

            return Ok();
        }
    }
}
