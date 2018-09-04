using Dealership.BLL;
using Dealership.DAL;
using System.Web.Mvc;

namespace Dealership.WebApp.Controllers
{
    public class ModelsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public ModelsController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDBContext());
        }
        // GET: Models
        public ActionResult Index()
        {
            var models = _unitOfWork.Models.GetAllWithMakers();
            return View(models);
        }
    }
}