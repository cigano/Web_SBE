using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Aplicacao;

namespace UI_Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            var bdCorpoDocente = CorpoDocenteAplicacaoConstrutor.CorpoDocenteAplicacaoEF();
            var bdCurso = CursoAplicacaoConstrutor.CursoAplicacaoEF();

            var c = bdCurso.ListarPorId(2);

            c.Coordenacao = bdCorpoDocente.ListarTodos().ToList().Where(x => x.Nome == "Jao" || x.Nome =="Edu").ToList() ;
            bdCurso.Salvar(c);

            var cursos = bdCurso.ListarTodos();
            foreach (var curso in cursos)
            {
                Console.WriteLine(curso.Titulo);
                foreach (var coordenacao in curso.Coordenacao)
                {
                    Console.WriteLine(coordenacao.Nome);
                }
                Console.WriteLine("\n\n");
            }
            Console.ReadKey();

        }
    }
}
