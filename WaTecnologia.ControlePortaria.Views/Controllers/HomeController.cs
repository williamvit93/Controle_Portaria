using System.Web.Mvc;
using WaTecnologia.ControlePortaria.Services;
using WaTecnologia.ControlePortaria.Domain;

namespace WaTecnologia.ControlePortaria.Views.Controllers
{
    public class HomeController : Controller
    {
        private EncomendasService encomendasService;
        public HomeController()
        {
            encomendasService = new EncomendasService();
        }
        public ActionResult Index()
        {
            var encomendas = encomendasService.Listar();
            return View(encomendas);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Insert(Encomenda encomenda)
        {
            encomendasService.Inserir(encomenda);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult RegisterWithdrawal(Encomenda encomenda)
        {
            encomendasService.Editar(encomenda);
            return RedirectToAction("Index");
        }
        
        public ActionResult FiltraPorParametros(Encomenda parametros)
        {
           var encomendas= encomendasService.FiltraPorParametros(parametros);
            return View("Index", encomendas);       
        }
    }
}