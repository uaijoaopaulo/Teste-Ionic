using ProcuraServicosWebApi.Models;
using ProcuraServicosWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProcuraServicosWebApi.Controllers
{
    [RoutePrefix("api/Avaliacao")]
    public class AvaliacaoController : ApiController
    {
        AvaliacaoRepository _AR;

        public AvaliacaoRepository AR
        {
            get
            {
                if (_AR == null)
                    _AR = new AvaliacaoRepository();
                return _AR;
            }
            set
            {
                _AR = value;
            }
        }

        [HttpGet]
        [Route("SearchAll/{Funcao}/{idAvaliacao}")]
        public HttpResponseMessage Get(string Funcao, int idAvaliacao)
        {
            try
            {
                var Avaliacoes = AR.GetAll(Funcao, idAvaliacao);
                return Request.CreateResponse(HttpStatusCode.OK, Avaliacoes);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
                throw;
            }

        }

        [HttpGet]
        [Route("Search/{idAvaliacao}")]
        public HttpResponseMessage Get(int idAvaliacao)
        {
            try
            {
                var avaliacao = AR.GetOne(idAvaliacao);
                return Request.CreateResponse(HttpStatusCode.OK, avaliacao);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
                throw;
            }
        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Post(Avaliacao entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AR.Save(entity);
                    return Request.CreateResponse(HttpStatusCode.Accepted);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado: " + ex.Message);
                    throw;
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Modelo em formato errado.");
        }

        [HttpPut]
        [Route("Change/{idAvaliacao}")]
        public HttpResponseMessage Put(int idAvaliacao, Avaliacao entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var avaliacao = AR.GetOne(idAvaliacao);

                    entity.id = avaliacao.id;
                    AR.Save(entity);
                    return Request.CreateResponse(HttpStatusCode.Accepted);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo ocorreu: " + ex.Message);
                    throw;
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Formato fora de padrão");
        }

        [HttpDelete]
        [Route("Delete/{idAvaliacao}")]
        public HttpResponseMessage Delete(int idAvaliacao)
        {
            try
            {
                AR.Delete(idAvaliacao);
                return Request.CreateResponse(HttpStatusCode.OK + " Deletado!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Não excluido!, " + ex.Message);
                throw;
            }
        }
    }
}
