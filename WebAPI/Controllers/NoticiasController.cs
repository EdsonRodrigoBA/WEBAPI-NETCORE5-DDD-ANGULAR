using Aplicacao.Interfaces;
using Entidades.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        private readonly IAplicacaoNoticia _iaplicacaoNoticia;

        public NoticiasController(IAplicacaoNoticia iaplicacaoNoticia)
        {
            _iaplicacaoNoticia = iaplicacaoNoticia;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/ListarNoticias")]
        public async Task<IActionResult> ListarNoticias()
        {
            var noticias = await _iaplicacaoNoticia.ListarNoticias();
            return Ok(noticias);
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/ListarNoticiasCustomizado")]
        public async Task<IActionResult> ListarNoticiasCustomizada()
        {
            var noticias = await _iaplicacaoNoticia.ListarNoticiasCustomizado();
            return Ok(noticias);
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/AdicionarNoticia")]
        public async Task<IActionResult> AdicionarNoticia(NoticiaModel model)
        {
            var noticia = new Noticia();
            noticia.Titulo = model.Titulo;
            noticia.Informacao = model.Titulo;
            noticia.UserId = RetornarUsuarioLogado();
            await _iaplicacaoNoticia.AdicionarNoticia(noticia);
            
            return Ok(noticia.notificacoes);
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPut("/api/AtualizarNoticia")]
        public async Task<IActionResult> AtualizarNoticia(NoticiaModel model)
        {
            var noticia = await _iaplicacaoNoticia.BuscarPorId(model.IdNoticia);
            if(noticia == null)
            {
                return BadRequest("Noticia Invalida");
            }

            noticia.Titulo = model.Titulo;
            noticia.Informacao = model.Titulo;
            noticia.UserId = RetornarUsuarioLogado();
            await _iaplicacaoNoticia.AtualizarNoticia(noticia);

            return Ok(noticia.notificacoes);
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/ExcluirNoticia")]
        public async Task<IActionResult> ExcluirNoticia(NoticiaModel model)
        {
            var noticia = await _iaplicacaoNoticia.BuscarPorId(model.IdNoticia);
            if (noticia == null)
            {
                return BadRequest("Noticia Invalida");
            }

         
            await _iaplicacaoNoticia.ExcluirNoticia(noticia);

            return Ok(noticia.notificacoes);
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/BuscarPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var noticia = await _iaplicacaoNoticia.BuscarPorId(id);
            if (noticia == null)
            {
                return BadRequest("Noticia Invalida");
            }

            return Ok(noticia);
        }
        private  String RetornarUsuarioLogado()
        {
            if(User != null)
            {
                var IdUsuario = User.FindFirst("IdUsuario").Value;
                return IdUsuario;
            }
            return String.Empty;
        }
    }
}
