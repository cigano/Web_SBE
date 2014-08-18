using System.Collections.Generic;
using Dominio;

namespace RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RepositorioEF.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepositorioEF.Contexto context)
        {
            context.Usuario.AddOrUpdate(u => u.Login, 
                new SBE_ST_Usuario
                {
                    Login = "cigano",
                    Senha = "123",
                    Ativo = true,
                    Nome = "Cigano Morrison Mendez",
                    BannerRotativo = true,
                    CorpoDocente = true,
                    Curso = true,
                    Livro = true,
                    Parceiro = true,
                    Usuario = true,
                    VideoCurso = true
                });
        }
    }
}
