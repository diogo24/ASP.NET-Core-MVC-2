using Chapter18_DependencyInjection.Infrastructure;
using Chapter18_DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace Chapter18_DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        //public ViewResult Index() => View(new MemoryRepository().Products);

        //public IRepository Repository { get; set; } = new MemoryRepository();

        //public IRepository Repository { get; } = TypeBroker.Repository;

        private IRepository repository;
        private ProductTotalizer totalizer;

        public HomeController(IRepository repo, ProductTotalizer total)
        {
            repository = repo;
            totalizer = total;
        }

        //public ViewResult Index()
        //{
        //    ViewBag.HomeController = repository.ToString();
        //    ViewBag.Totalizer = totalizer.Repository.ToString();
        //    //ViewBag.Total = totalizer.Total;
        //    return View(repository.Products);
        //}

        public ViewResult Index([FromServices]ProductTotalizer _totalizer) {

            IRepository _repository = HttpContext.RequestServices.GetService<IRepository>();

            ViewBag.HomeController = _repository.ToString();
            ViewBag.Totalizer = _totalizer.Repository.ToString();
            //ViewBag.Total = totalizer.Total;
            return View(_repository.Products);
        }
    }
}
