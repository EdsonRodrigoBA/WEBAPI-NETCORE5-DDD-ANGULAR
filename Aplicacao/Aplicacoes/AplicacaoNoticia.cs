using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoNoticia : IAplicacaoNoticia
    {
        private readonly INoticia _inoticia;
        private readonly IServicoNoticia _iservicoNoticia;

        public AplicacaoNoticia(INoticia inoticia, IServicoNoticia iservicoNoticia)
        {
            _inoticia = inoticia;
            _iservicoNoticia = iservicoNoticia;
        }

        public async Task Adiciona(Noticia objetc)
        {
            await _inoticia.Adiciona(objetc);
        }
        public async Task Atualizar(Noticia objetc)
        {
            await _inoticia.Atualizar(objetc);
        }
        public async Task Excluir(Noticia objetc)
        {
            await _inoticia.Excluir(objetc);
        }

        public async Task<List<Noticia>> ListarTodos()
        {
            return await _inoticia.ListarTodos();

        }
        public async Task<Noticia> BuscarPorId(int Id)
        {
            return await _inoticia.BuscarPorId(Id);
        }



        public async Task AdicionarNoticia(Noticia noticia)
        {
            await _iservicoNoticia.AdicionarNoticia(noticia);
        }

        public async Task AtualizarNoticia(Noticia noticia)
        {
            await _iservicoNoticia.AtualizarNoticia(noticia);
        }

        public async Task ExcluirNoticia(Noticia noticia)
        {
            await _iservicoNoticia.ExcluirNoticia(noticia);
        }

        public async Task<List<Noticia>> ListarNoticias()
        {
            return await _iservicoNoticia.ListarNoticias();
        }


    }
}
