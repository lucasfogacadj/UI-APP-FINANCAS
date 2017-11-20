using Microsoft.AspNetCore.Mvc;
using finlab.Repositorio;
using finlab.Dominio;
namespace fin.ui.Controllers
{
    public class MembersController : Controller
    {
          private IMembersRepository _repository; 
        private ICityRepository _repositoryCity;
        public MembersController(
            IMembersRepository repository,
            ICityRepository repositoryCity)
        {
            _repository = repository;
            _repositoryCity = repositoryCity;
        }
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }       


        public IActionResult Create()
        {
            ViewBag.City = _repositoryCity.GetAll();
            return View();
        }  

        [HttpPost]
        public IActionResult Create(Members members)
        {
            _repository.Create(members);
            return RedirectToAction("Index");
        }           
        }
    }
