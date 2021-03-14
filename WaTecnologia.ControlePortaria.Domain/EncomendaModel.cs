using System;

namespace WaTecnologia.ControlePortaria.Domain
{
    public class EncomendaModel
    {
        public int Id { get; set; }
        public string NomeRemetente { get; set; }
        public int NumApartamento { get; set; }
        public string Torre { get; set; }
        public DateTime DataRecebimento { get; set; }
        public bool Ativo { get; set; }
        public string DocRetirada { get; set; }
        public string NomeRetirada { get; set; }
        public DateTime? DataEntrega { get; set; }
        public bool StatusEntrega { get; set; }
    }
}
