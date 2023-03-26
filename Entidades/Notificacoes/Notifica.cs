using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Notificacoes
{
    public class Notifica
    {
        [NotMapped]
        public string NomePropriedade { get; set; }
        public string Mensagem { get; set; }
        public List<Notifica> notificacoes { get; set; }
        public Notifica()
        {
            notificacoes = new List<Notifica>();
        }

        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if(String.IsNullOrWhiteSpace(valor) || String.IsNullOrWhiteSpace(nomePropriedade))
            {
                notificacoes.Add(new Notifica
                {
                    Mensagem= "Campo obrigatório.",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            
                return true;
        }

        public bool ValidarPropriedadeDecimal(decimal valor, string nomePropriedade)
        {
            if (valor <1 || String.IsNullOrWhiteSpace(nomePropriedade))
            {
                notificacoes.Add(new Notifica
                {
                    Mensagem = "Campo obrigatório.",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }

            return true;
        }
    }
}
