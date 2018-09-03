using Dealership.BLL;
using System.Web.Mvc;

namespace Dealership.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var models = _unitOfWork.Models.GetAll();

            return View(models);
        }

        [HttpPost]
        public ActionResult AddModel()
        {
            _unitOfWork.Models.Add(new DomainEntities.Model
            {
                MakeId = 1,
                Name = "MDX",
            });
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}