using Aplicacao.Aplicacoes;
using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Dominio.Interfaces.Generics;
using Dominio.Interfaces.InterfaceServicos;
using Dominio.Servicos;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infraestrutura.Repositorio;
using Infraestrutura.Repositorio.Genericos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Token;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<Contexto>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("CON_PROJECT_DDDNET5")
            )
            );

            services.AddDefaultIdentity<ApplicationUser>(options => 
            { 
                options.SignIn.RequireConfirmedAccount = false;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider; 
            
            })
                .AddEntityFrameworkStores<Contexto>().AddDefaultTokenProviders();

            services.AddScoped(typeof(IGenericos<>), typeof(RepositorioGenerico<>));
            services.AddScoped<INoticia, RepositorioNoticia>();
            services.AddScoped<IUsuario, RepositorioUsuario>();

            // SERVI�O DOMINIO
            services.AddScoped<IServicoNoticia, ServicoNoticia>();

            // INTERFACE APLICA��O
            services.AddScoped<IAplicacaoNoticia, AplicacaoNoticia>();
            services.AddScoped<IAplicacaoUsuario, AplicacaoUsuario>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(option =>
       {
           option.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = false,
               ValidateAudience = false,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,

               ValidIssuer = "Teste.Securiry.Bearer",
               ValidAudience = "Teste.Securiry.Bearer",
               IssuerSigningKey = JwtSecuriryKey.Create("Secret_Key-12345678")
           };

           option.Events = new JwtBearerEvents
           {
               OnAuthenticationFailed = context =>
               {
                   Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                   return Task.CompletedTask;
               },
               OnTokenValidated = context =>
               {
                   Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                   return Task.CompletedTask;
               }
           };
       });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
            var urlCliente1 = "https://dominiocliente.com.br";
            var urlCliente2 = "https://dominiocliente.com.br";

            app.UseCors(b => b.WithOrigins(urlCliente1, urlCliente2));
            */
            #region Novo
                        var urlCliente3 = "http://localhost:4200";
                        app.UseCors(x => x
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader().WithOrigins(urlCliente3));
            #endregion
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
