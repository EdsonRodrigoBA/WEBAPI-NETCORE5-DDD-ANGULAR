using Entidades.Notificacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("tb_noticias")]
    public class Noticia : Notifica
    {

        [Column("NTC_ID")]
        public int Id { get; set; }

        [Column("NTC_TITULO")]
        [MaxLength(250,ErrorMessage ="O titulo deve conter apenas 250 caracrteres.")]
        public string Titulo { get; set; }

        [Column("NTC_INFORMACAO")]
        [MaxLength(250, ErrorMessage = "A informação deve conter apenas 250 caracrteres.")]
        public string Informacao { get; set; }
        
        [Column("NTC_ATIVO")]
        public bool Ativo { get; set; }

        [Column("NTC_DATACADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Column("NTC_DATAALTERACAO")]
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order =1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
