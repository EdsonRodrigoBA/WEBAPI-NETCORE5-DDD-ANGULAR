using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioNoticia : RepositorioGenerico<Noticia>, INoticia
    {
        private readonly DbContextOptions<Contexto> _contexto;
        public RepositorioNoticia()
        {
            _contexto = new DbContextOptions<Contexto>();

        }
        public async Task<List<Noticia>> ListarNoticias(Expression<Func<Noticia, bool>> expressaoNoticia)
        {
            using(var banco = new Contexto(_contexto))
            {
                return await banco.noticias.Where(expressaoNoticia).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Noticia>> ListarNoticiasCustomizado()
        {
            using (var banco = new Contexto(_contexto))
            {
                var listaNoticia = await (from noticia in banco.noticias

                                          join usuario in banco.ApplicationUsers

                                          on noticia.UserId equals usuario.Id
                                          select new Noticia
                                          {
                                              Id = noticia.Id,
                                              Informacao = noticia.Informacao,
                                              Titulo = noticia.Titulo,
                                              DataCadastro = noticia.DataCadastro,
                                              ApplicationUser = usuario
                                          }
                                    ).AsNoTracking().ToListAsync();

                return listaNoticia;


            }
        }
    }
}
