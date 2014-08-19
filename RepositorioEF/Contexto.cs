using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Dominio;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RepositorioEF
{
    public class Contexto : DbContext
    {
        public override int SaveChanges()
        {
            /* ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;

            //Find all Entities that are Added/Modified that inherit from my EntityBase
            IEnumerable<ObjectStateEntry> objectStateEntries =
                from e in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                where
                    e.IsRelationship == false &&
                    e.Entity != null &&
                    typeof(IEntityBase).IsAssignableFrom(e.Entity.GetType())
                select e;

            var currentTime = DateTime.Now;

            foreach (var entry in objectStateEntries)
            {
                dynamic entityBase = entry.Entity;

                if (entry.State == EntityState.Added || entityBase.CreatedOn == DateTime.MinValue)
                {
                    entityBase.CreatedOn = currentTime;
                }

                entityBase.LastModified = currentTime;
            } */

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

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
