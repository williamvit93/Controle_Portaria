using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaTecnologia.ControlePortaria.Domain;

namespace WaTecnologia.ControlePortaria.Repository.EntityFrameWork
{
    public class EncomendaRepository
    {
        public ControlePortariaContext DB;
        public EncomendaRepository()
        {
            DB = new ControlePortariaContext();
        }
        public List<Encomenda> Listar()
        {
            
            var encomendas = DB.Encomendas.ToList();
            return encomendas;
        }

        public Encomenda BuscarPorId(int id)
        {
            return DB.Encomendas.Find(id);
        }

        public void Editar(Encomenda encomenda)
        {
            DB.Entry(encomenda).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }


        public List<Encomenda> FiltrarPorParametros(Encomenda parametros)
        {
            return DB.Encomendas.Where(e =>
            e.NomeRemetente.Contains(parametros.NomeRemetente)
            && (e.NumApartamento == parametros.NumApartamento || parametros.NumApartamento ==0)
            && (e.Torre == parametros.Torre || string.IsNullOrEmpty(parametros.Torre))
            ).ToList();
        }

        public void Inserir(Encomenda encomenda)
        {
            DB.Encomendas.Add(encomenda);
            DB.SaveChanges();
        }


        public void Remover(int id)
        {
            var encomenda = BuscarPorId(id);
            encomenda.Ativo = false;
            Editar(encomenda);
        }
    }
}

