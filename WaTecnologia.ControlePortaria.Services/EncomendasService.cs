using System.Collections.Generic;
using WaTecnologia.ControlePortaria.Domain;

using System;
using WaTecnologia.ControlePortaria.Repository.EntityFrameWork;

namespace WaTecnologia.ControlePortaria.Services
{
    public class EncomendasService
    {
        private EncomendaRepository encomendasRepository;
        public EncomendasService()
        {
            encomendasRepository = new EncomendaRepository();
        }

        public void Inserir(Encomenda encomenda)
        {
            encomenda.DataRecebimento = DateTime.Now;
            encomenda.Ativo = true;
            encomendasRepository.Inserir(encomenda);
        }

        public List<Encomenda> Listar()
        {
            return encomendasRepository.Listar();
        }

        public Encomenda BuscarPorId(int id)
        {
            return encomendasRepository.BuscarPorId(id);
        }

        public void Remover(int id)
        {
            encomendasRepository.Remover(id);
        }

        public void Editar(Encomenda encomenda)
        {
            var encomendaAtual =  encomendasRepository.BuscarPorId(encomenda.Id);

            encomendaAtual.DataEntrega = DateTime.Now;
            encomendaAtual.StatusEntrega = true;
            encomendaAtual.NomeRetirada = encomenda.NomeRetirada;
            encomendaAtual.DocRetirada = encomenda.DocRetirada;

            encomendasRepository.Editar(encomendaAtual);
        }
        public List<Encomenda>FiltraPorParametros(Encomenda parametros)
        {
            return encomendasRepository.FiltrarPorParametros(parametros);
        }
    }
}
