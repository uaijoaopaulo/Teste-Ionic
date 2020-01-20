using ProcuraServicosWebApi.Models;
using ProcuraServicosWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace ProcuraServicosWebApi.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        UsuarioRepository _UR;

        public UsuarioRepository UR
        {
            get
            {
                if (_UR == null)
                    _UR = new UsuarioRepository();
                return _UR;
            }
            set
            {
                _UR = value;
            }
        }

        [HttpGet]
        [Route("Search/{idUsuario}")]
        public HttpResponseMessage Get(int idUsuario)
        {
            try
            {
                var conta = UR.GetOne(idUsuario);

                if (conta == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ". Conta não encontrada");
                }
                else if (!conta.status)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ". A conta foi permanentemente desativada. ");

                return Request.CreateResponse(HttpStatusCode.OK, conta);


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ". Erro inesperado no servidor => " + ex);
            }

        }

        [HttpGet]
        [Route("RecuperarSenha/{entity}")]
        public bool RecuperaEmail(string entity)
        {
            try
            {
                Usuario user = UR.GetOne(entity);
                if (user == null)
                    return false;

                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("unnamed.suporte@gmail.com", "unnamedsenha123");

                MailMessage mail = new MailMessage();
                mail.Sender = new System.Net.Mail.MailAddress("unnamed.suporte@gmail.com", "unNamed");
                mail.From = new MailAddress(user.email, "Recuperação de Senha");
                mail.To.Add(new MailAddress(user.email, "Recuperação de Senha"));
                mail.Subject = "Recuperação de Senha Para unNamed";
                string Body = "Email";
                mail.Body = Body;
                mail.Priority = MailPriority.High;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;

                try
                {
                    client.Send(mail);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        [HttpPost]
        [Route("Save")]
        public bool Save(Usuario usuario)
        {
            if (ModelState.IsValid)
                try
                {
                    UR.Save(usuario);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    throw;
                }
            else
                return false;
        }

        [HttpPost]
        [Route("Logar")]
        public IHttpActionResult Logar(Usuario usuario)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    bool logou = UR.Logar(usuario);
                    if (logou)
                    {
                        var usuarioLogado = UR.GetOne(usuario);

                        return Ok(usuarioLogado);
                    }
                    else
                        return BadRequest("Usuário ou senha estão incorretos.");
                }
                else
                    return BadRequest( ModelState + " Não foi possível cadastrar o usuário.");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        return BadRequest(". Solicitação não atendida. " + ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        [HttpPut]
        [Route("Change/{idUsuario}")]
        public HttpResponseMessage Change(int id, Usuario usuario)
        {
            try
            {
                UR.Save(usuario);
                return Request.CreateResponse(HttpStatusCode.Created + ". Usuário alterado com sucesso!");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest + ". Solicitação não atendida. " + ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        [HttpDelete]
        [Route("Delete/{idUsuario}")]
        public HttpResponseMessage Delete(int idUsuario)
        {
            try
            {
                UR.Delete(idUsuario);
                return Request.CreateResponse(HttpStatusCode.OK + ". Usuário Desativado com sucesso! ");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + ". Não foi possivel desativar o usuario => " + ex);
            }
        }
    }
}
