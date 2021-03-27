using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaTecnologia.ControlePortaria.Domain;

namespace WaTecnologia.ControlePortaria.Repository.EntityFrameWork
{
    public class EncomendaConfig : EntityTypeConfiguration<Encomenda>
    {
        public EncomendaConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.NomeRemetente);
            Property(x => x.NomeRetirada).IsOptional();
            Property(x => x.NumApartamento);
            Property(x => x.StatusEntrega);
            Property(x => x.Torre);
            Property(x => x.DocRetirada).IsOptional();
            Property(x => x.Ativo);
            Property(x => x.DataEntrega).IsOptional();
            Property(x => x.DataRecebimento);

            ToTable("dbo.Encomendas");
        }
    }
}
