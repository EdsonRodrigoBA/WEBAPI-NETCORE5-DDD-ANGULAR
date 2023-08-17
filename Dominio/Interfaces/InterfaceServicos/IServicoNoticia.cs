using Entidades.Entidades;
using Entidades.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServicos
{
    public interface IServicoNoticia
    {
        Task AdicionarNoticia(Noticia noticia);

        Task AtualizarNoticia(Noticia noticia);
        Task ExcluirNoticia(Noticia noticia);
        Task<List<Noticia>> ListarNoticias();
        Task<List<NoticiaViewModel>> ListarNoticiasCustomizado();

    }
}
