﻿using Aplicacao.Interfaces;
using Entidades.Entidades;
using Entidades.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Token;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAplicacaoUsuario _iaplicacaoUsuario;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsuarioController(IAplicacaoUsuario iaplicacaoUsuario, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _iaplicacaoUsuario = iaplicacaoUsuario;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CriarToken")]
        public async Task<IActionResult> CriarToken([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha))
                return Unauthorized();

            var resultado = await _iaplicacaoUsuario.ExisteUsuario(login.email, login.senha);
            if (resultado)
            {
                var IdUsuario = await _iaplicacaoUsuario.RetornaIdUsuario(login.email);

                var token = new TokenJWTBuilder()
                     .AddSecurityKey(JwtSecuriryKey.Create("Secret_Key-12345678"))
                 .AddSubject("Empresa - Dev API Noticias")
                 .AddIssuer("Teste.Securiry.Bearer")
                 .AddAudience("Teste.Securiry.Bearer")
                 .AddClaim("IdUsuario", IdUsuario)
                 .AddExpiry(5)
                 .Builder();

                return Ok(token.value);
            }
            else
            {
                return Unauthorized();
            }

        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionaUsuario")]
        public async Task<IActionResult> AdicionaUsuario([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha))
                return Ok("Falta alguns dados");

            var resultado = await
                _iaplicacaoUsuario.AdicionarUsuario(login.email, login.senha, login.idade, login.celular);

            if (resultado)
                return Ok("Usuário Adicionado com Sucesso");
            else
                return Ok("Erro ao adicionar usuário");
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CriarTokenIdentity")]
        public async Task<IActionResult> CriarTokenIdentity([FromBody] Login login)
        {
            try
            {

         
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha))
                return Unauthorized();
            var user = await _userManager.FindByEmailAsync(login.email);
            if(user == null)
            {
                return Unauthorized();

            }
            var resultado = await
                _signInManager.PasswordSignInAsync(user, login.senha, false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                var IdUsuario = await _iaplicacaoUsuario.RetornaIdUsuario(login.email);

                var token = new TokenJWTBuilder()
                     .AddSecurityKey(JwtSecuriryKey.Create("Secret_Key-12345678"))
                 .AddSubject("Empresa - Dev API Noticias")
                 .AddIssuer("Teste.Securiry.Bearer")
                 .AddAudience("Teste.Securiry.Bearer")
                 .AddClaim("IdUsuario", IdUsuario)
                 .AddExpiry(5)
                 .Builder();

                return Ok(token.value);
            }
            else
            {
                return Unauthorized();
            }
            }catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionaUsuarioIdentity")]
        public async Task<IActionResult> AdicionaUsuarioIdentity([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha))
                return Ok("Falta alguns dados");

            var user = new ApplicationUser
            {
                UserName = login.email,
                Email = login.email,
                Celular = login.celular,
                TipoUsuario = TipoUsuario.Comum,
            };
            var resultado = await _userManager.CreateAsync(user, login.senha);

            if (resultado.Errors.Any())
            {
                return Ok(resultado.Errors);
            }

            // Geração de Confirmação caso precise
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            // retorno email 
           // code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var resultado2 = await _userManager.ConfirmEmailAsync(user, code);

            if (resultado2.Succeeded)
                return Ok("Usuário Adicionado com Sucesso");
            else
                return Ok("Erro ao confirmar usuários");

        }

    }
}
