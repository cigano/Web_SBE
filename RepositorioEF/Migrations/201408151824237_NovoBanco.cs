namespace RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SBE_ST_ActionsLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Controller = c.String(),
                        Action = c.String(),
                        Data = c.DateTime(nullable: false),
                        Post = c.String(),
                        Usuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SBE_ST_BannerRotativo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 90),
                        SubTitulo = c.String(nullable: false, maxLength: 320),
                        Link = c.String(nullable: false, maxLength: 150),
                        Imagem = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SBE_ST_CorpoDocente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imagem = c.String(nullable: false, maxLength: 50),
                        Nome = c.String(nullable: false, maxLength: 65),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SBE_ST_Curso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiniBanner = c.String(nullable: false, maxLength: 50),
                        Categoria = c.String(nullable: false, maxLength: 25),
                        Banner = c.String(nullable: false, maxLength: 50),
                        Titulo = c.String(nullable: false, maxLength: 150),
                        SubTitulo = c.String(nullable: false, maxLength: 300),
                        Data = c.DateTime(nullable: false),
                        Inicio = c.String(nullable: false, maxLength: 90),
                        Local = c.String(nullable: false, maxLength: 90),
                        Conteudo = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SBE_ST_VideoCurso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiniBanner = c.String(),
                        Banner = c.String(),
                        Titulo = c.String(),
                        SubTitulo = c.String(),
                        Profissao = c.String(),
                        Conteudo = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SBE_ST_Livro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imagem = c.String(nullable: false, maxLength: 50),
                        Titulo = c.String(nullable: false, maxLength: 150),
                        SubTitulo = c.String(maxLength: 300),
                        Conteudo = c.String(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SBE_ST_Parceiro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                        Logo = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SBE_ST_Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                        Login = c.String(nullable: false, maxLength: 30),
                        Senha = c.String(nullable: false, maxLength: 15),
                        Ativo = c.Boolean(nullable: false),
                        BannerRotativo = c.Boolean(nullable: false),
                        CorpoDocente = c.Boolean(nullable: false),
                        Curso = c.Boolean(nullable: false),
                        Livro = c.Boolean(nullable: false),
                        Parceiro = c.Boolean(nullable: false),
                        VideoCurso = c.Boolean(nullable: false),
                        Usuario = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SBE_ST_CursoSBE_ST_CorpoDocente",
                c => new
                    {
                        SBE_ST_Curso_Id = c.Int(nullable: false),
                        SBE_ST_CorpoDocente_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SBE_ST_Curso_Id, t.SBE_ST_CorpoDocente_Id })
                .ForeignKey("dbo.SBE_ST_Curso", t => t.SBE_ST_Curso_Id, cascadeDelete: true)
                .ForeignKey("dbo.SBE_ST_CorpoDocente", t => t.SBE_ST_CorpoDocente_Id, cascadeDelete: true)
                .Index(t => t.SBE_ST_Curso_Id)
                .Index(t => t.SBE_ST_CorpoDocente_Id);
            
            CreateTable(
                "dbo.SBE_ST_VideoCursoSBE_ST_CorpoDocente",
                c => new
                    {
                        SBE_ST_VideoCurso_Id = c.Int(nullable: false),
                        SBE_ST_CorpoDocente_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SBE_ST_VideoCurso_Id, t.SBE_ST_CorpoDocente_Id })
                .ForeignKey("dbo.SBE_ST_VideoCurso", t => t.SBE_ST_VideoCurso_Id, cascadeDelete: true)
                .ForeignKey("dbo.SBE_ST_CorpoDocente", t => t.SBE_ST_CorpoDocente_Id, cascadeDelete: true)
                .Index(t => t.SBE_ST_VideoCurso_Id)
                .Index(t => t.SBE_ST_CorpoDocente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SBE_ST_VideoCursoSBE_ST_CorpoDocente", "SBE_ST_CorpoDocente_Id", "dbo.SBE_ST_CorpoDocente");
            DropForeignKey("dbo.SBE_ST_VideoCursoSBE_ST_CorpoDocente", "SBE_ST_VideoCurso_Id", "dbo.SBE_ST_VideoCurso");
            DropForeignKey("dbo.SBE_ST_CursoSBE_ST_CorpoDocente", "SBE_ST_CorpoDocente_Id", "dbo.SBE_ST_CorpoDocente");
            DropForeignKey("dbo.SBE_ST_CursoSBE_ST_CorpoDocente", "SBE_ST_Curso_Id", "dbo.SBE_ST_Curso");
            DropIndex("dbo.SBE_ST_VideoCursoSBE_ST_CorpoDocente", new[] { "SBE_ST_CorpoDocente_Id" });
            DropIndex("dbo.SBE_ST_VideoCursoSBE_ST_CorpoDocente", new[] { "SBE_ST_VideoCurso_Id" });
            DropIndex("dbo.SBE_ST_CursoSBE_ST_CorpoDocente", new[] { "SBE_ST_CorpoDocente_Id" });
            DropIndex("dbo.SBE_ST_CursoSBE_ST_CorpoDocente", new[] { "SBE_ST_Curso_Id" });
            DropTable("dbo.SBE_ST_VideoCursoSBE_ST_CorpoDocente");
            DropTable("dbo.SBE_ST_CursoSBE_ST_CorpoDocente");
            DropTable("dbo.SBE_ST_Usuario");
            DropTable("dbo.SBE_ST_Parceiro");
            DropTable("dbo.SBE_ST_Livro");
            DropTable("dbo.SBE_ST_VideoCurso");
            DropTable("dbo.SBE_ST_Curso");
            DropTable("dbo.SBE_ST_CorpoDocente");
            DropTable("dbo.SBE_ST_BannerRotativo");
            DropTable("dbo.SBE_ST_ActionsLog");
        }
    }
}
