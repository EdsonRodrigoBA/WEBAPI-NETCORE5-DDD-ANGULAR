using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Generics
{
    public interface IGenericos <T> where T : class
    {
        Task Adiciona(T objetc);
        Task Atualizar(T objetc);
        Task Excluir(T objetc);
        Task<T> BuscarPorId(int Id);
        Task<List<T>> ListarTodos();

    }
}
