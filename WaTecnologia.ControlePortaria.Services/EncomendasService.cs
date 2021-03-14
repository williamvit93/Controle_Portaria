using System.Collections.Generic;
using WaTecnologia.ControlePortaria.Domain;
using WaTecnologia.ControlePortaria.Repository;
using System;

namespace WaTecnologia.ControlePortaria.Services
{
    public class EncomendasService
    {
        private EncomendasRepository encomendasRepository;
        public EncomendasService()
        {
            encomendasRepository = new EncomendasRepository();
        }

        public void Inserir(EncomendaModel encomenda)
        {
            encomenda.DataRecebimento = DateTime.Now;
            encomenda.Ativo = true;
            encomendasRepository.Inserir(encomenda);
        }

        public List<EncomendaModel> Listar()
        {
            return encomendasRepository.Listar();
        }

        public EncomendaModel BuscarPorId(int id)
        {
            return encomendasRepository.BuscarPorId(id);
        }

        public void Remover(int id)
        {
            encomendasRepository.Remover(id);
        }

        public void Editar(EncomendaModel encomenda)
        {
            var encomendaAtual =  encomendasRepository.BuscarPorId(encomenda.Id);

            encomendaAtual.DataEntrega = DateTime.Now;
            encomendaAtual.StatusEntrega = true;
            encomendaAtual.NomeRetirada = encomenda.NomeRetirada;
            encomendaAtual.DocRetirada = encomenda.DocRetirada;

            encomendasRepository.Editar(encomendaAtual);
        }
        public List<EncomendaModel>FiltraPorParametros(EncomendaModel parametros)
        {
            return encomendasRepository.FiltrarPorParametros(parametros);
        }
    }
}
