using Aplicacao.Interfaces;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Aplicacoes
{
    public class AplicacaoUsuario : IAplicacaoUsuario
    {

        private readonly IUsuario _iusuario;

        public AplicacaoUsuario(IUsuario iusuario)
        {
            _iusuario = iusuario;
        }

        public async Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular)
        {
            return await _iusuario.AdicionarUsuario(email, senha, idade, celular);
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            return await _iusuario.ExisteUsuario(email, senha);
        }
    }
}
