namespace EmployeeArrivalTracker.Client.Controllers 
{
    using Models.ViewModels;
    using RestSharp;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Subscribe(SubscribeInpuModel model)
        {
            var client = new RestClient("http://localhost:61081/api");
            IRestRequest request = new RestRequest("subscriptions", Method.POST);
            request.Parameters.Add(new Parameter { Name = "date", Value = model.Date.ToString("yyyy-MM-dd"), Type = ParameterType.QueryString });

            var response = await client.ExecuteTaskAsync(request).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Employees");
            }

            return RedirectToAction("Index");
        }
    }
}