namespace EmployeeArrivalTracker.Client.Controllers
{
    using Models.DTO;
    using Models.ViewModels;
    using Newtonsoft.Json;
    using RestSharp;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class EmployeesController : Controller
    {
        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var client = new RestClient("http://localhost:61081/api");
            IRestRequest request = new RestRequest("employees/arrived", Method.GET);

            var response = await client.ExecuteTaskAsync(request).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseModel = JsonConvert.DeserializeObject<IEnumerable<EmployeeDTO>>(response.Content);
                var viewModel = responseModel.Select(x => EmployeeIndexViewModel.MapFromEntity(x));

                return View(viewModel);
            }

            return View();
        }
    }
}