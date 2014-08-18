using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using RepositorioEF;
using Dominio.Contrato;


namespace Aplicacao
{
    public class ParceiroAplicacao
    {
        private readonly IRepositorio<SBE_ST_Parceiro> repositorio;

        public ParceiroAplicacao(IRepositorio<SBE_ST_Parceiro> repo)
        {
            repositorio = repo;
        }

        public void Salvar(SBE_ST_Parceiro parceiro)
        {
            repositorio.Salvar(parceiro);
        }

        public void Excluir(SBE_ST_Parceiro parceiro)
        {
            repositorio.Excluir(parceiro);
        }

        public IQueryable<SBE_ST_Parceiro> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public SBE_ST_Parceiro ListarPorId(int id)
        {
            return repositorio.ListarPorId(id);
        }
    }
}
