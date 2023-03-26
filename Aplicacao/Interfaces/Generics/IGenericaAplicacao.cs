using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces.Generics
{
    public interface IGenericaAplicacao <T> where T : class
    {
        Task Adiciona(T objetc);
        Task Atualizar(T objetc);
        Task Excluir(T objetc);
        Task<T> BuscarPorId(int Id);
        Task<List<T>> ListarTodos();
    }
}
