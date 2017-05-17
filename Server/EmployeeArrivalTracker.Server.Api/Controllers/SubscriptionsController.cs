namespace EmployeeArrivalTracker.Server.Api.Controllers
{
    using Data.Models;
    using Services.Data;
    using Services.Remote;
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    [RoutePrefix("api/subscriptions")]
    public class SubscriptionsController : ApiController
    {
        private readonly SubscriptionsService subscriptionsService;
        private readonly TokensService tokensService;
        private readonly EmployeesService employeesService;

        public SubscriptionsController()
        {
            this.subscriptionsService = new SubscriptionsService();
            this.tokensService = new TokensService();
            this.employeesService = new EmployeesService();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Subscribe(DateTime date)
        {
            var token = await this.subscriptionsService.Subscribe(date, "http://localhost:61081/api/employees");
            if (token == null)
            {
                return BadRequest();
            }

            this.tokensService.Add(new Token { Content = token.Token, ExpirationDate = token.Expires });
            this.employeesService.ResetArrivalDate();

            return Ok();
        }
    }
}
