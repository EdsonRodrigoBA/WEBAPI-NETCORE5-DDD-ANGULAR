using Dominio.Interfaces.Generics;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface INoticia : IGenericos<Noticia>
    {
        Task<List<Noticia>> ListarNoticias(Expression<Func<Noticia,bool>> expressaoNoticia);
        Task<List<Noticia>> ListarNoticiasCustomizado();
    }
}
