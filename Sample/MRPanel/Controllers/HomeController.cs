using Domain;
using GenericRepository;
using Microsoft.AspNetCore.Mvc;
using MRPanel.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MRPanel.Controllers
{
    public class HomeController : Controller
    {
        readonly IUnitOfWork<Person> unitOfWork;

        public HomeController(IUnitOfWork<Person> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var list = await unitOfWork.Repository.All();

            return View(list);
        }

        [HttpGet]
        public IActionResult Get() => View("Post");

        [HttpPost]
        public async Task<IActionResult> Post(Person person)
        {
            await unitOfWork.Repository.Add(person);

            await unitOfWork.Commit();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
