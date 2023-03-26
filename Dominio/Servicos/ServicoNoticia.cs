using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class ServicoNoticia : IServicoNoticia
    {
        private readonly INoticia _inoticia;

        public ServicoNoticia(INoticia inoticia)
        {
            _inoticia = inoticia;
        }

        public  async Task AdicionarNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidarPropriedadeString(noticia.Titulo, "Titulo");
            var validarInformacoes = noticia.ValidarPropriedadeString(noticia.Informacao, "Informacao");
            if(validarTitulo & validarTitulo)
            {
                noticia.Ativo = true;
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                await _inoticia.Adiciona(noticia);
            }
        }

        public async Task AtualizarNoticia(Noticia noticia)
        {
            var validarTitulo = noticia.ValidarPropriedadeString(noticia.Titulo, "Titulo");
            var validarInformacoes = noticia.ValidarPropriedadeString(noticia.Informacao, "Informacao");
            if (validarTitulo & validarTitulo)
            {
                noticia.Ativo = true;
                noticia.DataAlteracao = DateTime.Now;
                noticia.DataCadastro = DateTime.Now;
                await _inoticia.Atualizar(noticia);
            }
        }

        public Task ExcluirNoticia(Noticia noticia)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Noticia>> ListarNoticias()
        {
            return await _inoticia.ListarNoticias(x => x.Ativo);
        }
    }
}
