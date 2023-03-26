using Entidades.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Configuracoes
{
    public class Contexto : IdentityDbContext<ApplicationUser>
    {

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }
        public DbSet<Noticia> noticias { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(x => x.Id);
            base.OnModelCreating(builder);  
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);

            }
        }
        public String ObterStringConexao()
        {
            return "Server=DESKTOP-6VTUT16\\SQLEXPRESS; Database=API_DDD_NET5_554544; User Id =exattoSite; Password =832285;Max Pool Size=2024";
        }
    }
}
