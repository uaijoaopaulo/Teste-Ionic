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
    [RoutePrefix("api/AvaliacaoItem")]
    public class AvaliacaoItemController : ApiController
    {
        AvaliacaoItemRepository _AIR;

        public AvaliacaoItemRepository AIR
        {
            get
            {
                if (_AIR == null)
                    _AIR = new AvaliacaoItemRepository();
                return _AIR;
            }
            set
            {
                _AIR = value;
            }
        }

        [HttpGet]
        [Route("SearchAll/{idAvaliacaoItem}")]
        public HttpResponseMessage GetAll(int idAvaliacaoItem)
        {
            try
            {
                var Avaliacoes = AIR.GetAll(idAvaliacaoItem);
                return Request.CreateResponse(HttpStatusCode.OK, Avaliacoes);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
                throw;
            }
            
        }

        [HttpGet]
        [Route("Search/{idAvaliacaoItem}")]
        public HttpResponseMessage Get(int idAvaliacaoItem)
        {
            try
            {
                var avaliacao = AIR.GetOne(idAvaliacaoItem);
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
        public HttpResponseMessage Post(AvaliacaoItem entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AIR.Save(entity);
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
        [Route("Change/{idAvaliacaoItem}")]
        public HttpResponseMessage Put(int idAvaliacaoItem, AvaliacaoItem entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var avaliacao = AIR.GetOne(idAvaliacaoItem);

                    entity.Id = avaliacao.Id;
                    AIR.Save(entity);
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
        [Route("Delete/{idAvaliacaoItem}")]
        public HttpResponseMessage Delete(int idAvaliacaoItem)
        {
            try
            {
                AIR.Delete(idAvaliacaoItem);
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
