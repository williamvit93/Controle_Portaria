using System.Collections.Generic;
using System.Web.Http;
using WaTecnologia.ControlePortaria.Domain;
using WaTecnologia.ControlePortaria.Services;

namespace WaTecnologia.ControlePortaria.WebAPI.Controllers
{
    public class EncomendasController : ApiController
    {
        private readonly EncomendasService encomendaService;
        public EncomendasController()
        {
            encomendaService = new EncomendasService();
        }
        // GET: api/Encomendas
        [HttpGet]
        public List<Encomenda> Get()
        {
            return encomendaService.Listar();
        }

        // GET: api/Encomendas/5
        [HttpGet]
        public Encomenda Get(int id)
        {
            return encomendaService.BuscarPorId(id);
        }

        // GET: api/Encomendas
        [HttpPatch]
        public List<Encomenda> Get([FromBody] Encomenda encomenda)
        {
            return encomendaService.FiltraPorParametros(encomenda);
        }

        // POST: api/Encomendas
        [HttpPost]
        public void Post([FromBody] Encomenda value)
        {
            encomendaService.Inserir(value);
        }

        // PUT: api/Encomendas/5
        [HttpPut]
        public void Put(int id, [FromBody] Encomenda encomenda)
        {
            encomenda.Id = id;
            encomendaService.Editar(encomenda);
        }

        // DELETE: api/Encomendas/5
        [HttpDelete]
        public void Delete(int id)
        {
            encomendaService.Remover(id);
        }
    }
}
