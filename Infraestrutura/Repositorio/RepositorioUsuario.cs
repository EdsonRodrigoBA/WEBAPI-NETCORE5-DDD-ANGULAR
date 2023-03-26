using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioUsuario : RepositorioGenerico<ApplicationUser>, IUsuario
    {
        private readonly DbContextOptions<Contexto> _contexto;
        public RepositorioUsuario()
        {
            _contexto = new DbContextOptions<Contexto>();

        }
        public async Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular)
        {
            try
            {
                using (var banco = new Contexto(_contexto))
                {
                   await  banco.ApplicationUsers.AddAsync(new ApplicationUser()
                    {
                        Email= email,
                        PasswordHash = senha,
                        Idade = idade,
                        Celular = celular
                    });
                    await banco.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;

        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            try
            {
                using (var banco = new Contexto(_contexto))
                {
                    var retorno = await banco.ApplicationUsers.AsNoTracking()
                                            .AnyAsync(x => x.Email.Equals(email) & x.PasswordHash.Equals(senha));
                    return retorno;
                };
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
