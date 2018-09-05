using Dealership.BLL;
using System.Web.Mvc;


namespace Dealership.App.Controllers
{
    public class ModelsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public ModelsController(IUnitOfWork unitOfWork)
        {
            //_unitOfWork = new UnitOfWork(new ApplicationDBContext());
            _unitOfWork = unitOfWork;
        }
        // GET: Models
        public ActionResult Index()
        {
            var models = _unitOfWork.Models.GetAllWithMakers();
            return View(models);
        }
    }
}