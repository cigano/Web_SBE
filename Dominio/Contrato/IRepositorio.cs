using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Contrato
{
    public interface IRepositorio<T> where T : class
    {
        void Salvar(T entidade);

        void Excluir(T entidade);

        IQueryable<T> ListarTodos();

        T ListarPorId(int id);
    }
}
