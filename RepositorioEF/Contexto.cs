using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Dominio;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RepositorioEF
{
    public class Contexto : DbContext
    {
        public DbSet<SBE_ST_BannerRotativo> BannerRotativo { get; set; }
        public DbSet<SBE_ST_CorpoDocente> CorpoDocente { get; set; }
        public DbSet<SBE_ST_Curso> Curso { get; set; }
        public DbSet<SBE_ST_Livro> Livro { get; set; }
        public DbSet<SBE_ST_Parceiro> Parceiro { get; set; }
        public DbSet<SBE_ST_VideoCurso> VideoCurso { get; set; }
        public DbSet<SBE_ST_Usuario> Usuario { get; set; }
        public DbSet<SBE_ST_ActionsLog> ActionsLog { get; set; }
        
        

        public Contexto()
            : base("BancoDados")
        {
            Database.SetInitializer<Contexto>(null);
        }

        

    }
}
