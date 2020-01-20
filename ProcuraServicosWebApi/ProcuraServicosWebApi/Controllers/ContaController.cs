using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProcuraServicosWebApi.Models;
using ProcuraServicosWebApi.Repository;

namespace ProcuraServicosWebApi.Controllers
{
    [RoutePrefix("api/Conta")]
    public class ContaController : ApiController
    {
        ContaRepository _CR;

        public ContaRepository CR
        {
            get
            {
                if (_CR == null)
                    _CR = new ContaRepository();
                return _CR;
            }
            set
            {
                _CR = value;
            }
        }

        [HttpGet]
        [Route("Search/{idConta}")]
        public HttpResponseMessage Get(int idConta)
        {
            try
            {
                var conta = CR.GetOne(idConta);

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

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(Conta conta)
        {
            try
            {
                CR.Save(conta);
                return Request.CreateResponse(HttpStatusCode.OK + ". Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + ". Usuário não cadastrado, há algo errado! " + ex.Message);
                throw;
            }
        }

        [HttpPut]
        [Route("Change/{idConta}")]
        public HttpResponseMessage Change(int idConta, Conta conta)
        {
            try
            {
                var aconta = CR.GetOne(idConta);

                conta.Id = aconta.Id;
                CR.Save(conta);
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
        [Route("Delete/{idConta}")]
        public HttpResponseMessage Delete(int idConta)
        {
            try
            {
                CR.Delete(idConta);
                return Request.CreateResponse(HttpStatusCode.OK + ". Usuário Desativado com sucesso! ");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + ". Não foi possivel desativar o usuario => " + ex);
            }
        }
    }
}
