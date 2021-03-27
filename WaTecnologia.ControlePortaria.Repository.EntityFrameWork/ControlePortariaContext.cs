using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaTecnologia.ControlePortaria.Domain;

namespace WaTecnologia.ControlePortaria.Repository.EntityFrameWork
{
   public class ControlePortariaContext : DbContext
    {
        public ControlePortariaContext() : base ("PortariaDB")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Encomenda> Encomendas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EncomendaConfig());
        }


    }
}
