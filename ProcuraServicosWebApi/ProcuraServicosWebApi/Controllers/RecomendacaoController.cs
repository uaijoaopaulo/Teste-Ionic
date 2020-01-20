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
    [RoutePrefix("api/Recomendacao")]
    public class RecomendacaoController : ApiController
    {

        RecomendacaoRepository _RR;

        public RecomendacaoRepository RR
        {
            get
            {
                if (_RR == null)
                    _RR = new RecomendacaoRepository();
                return _RR;
            }
            set
            {
                _RR = value;
            }
        }

        [HttpGet]
        [Route("Search")]
        public HttpResponseMessage Get()
        {
            try
            {
                var recomendacao = RR.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, recomendacao);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("SearchByID/{idRecomendacao}")]
        public HttpResponseMessage GetById(int idRecomendacao)
        {
            try
            {
                var recomendacao = RR.GetOneById(idRecomendacao);
                return Request.CreateResponse(HttpStatusCode.OK, recomendacao);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("SearchByIDUsuario/{idUsuario}")]
        public HttpResponseMessage GetByIdUsuario(int idUsuario)
        {
            try
            {
                var recomendacao = RR.GetOneByIdUsuario(idUsuario);
                return Request.CreateResponse(HttpStatusCode.OK, recomendacao);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Post(RecomendacaoUsuario entity)
        {
            if (ModelState.IsValid)
                try
                {
                    RR.Save(entity);
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                    throw;
                }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Formato incorreto!");
        }

        [HttpPut]
        [Route("Change/{idRecomedacao}")]
        public HttpResponseMessage Put(int idRecomedacao, RecomendacaoUsuario entity)
        {
            if (ModelState.IsValid)
                try
                {
                    var recomedacao = RR.GetOneById(idRecomedacao);

                    entity.id = recomedacao.id;
                    RR.Save(entity);
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                    throw;
                }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Formato incorreto!");
        }

        [HttpDelete]
        [Route("Delete/{idRecomendacao}")]
        public HttpResponseMessage Delete(int idRecomendacao)
        {
            try
            {
                RR.Delete(idRecomendacao);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                throw;
            }
        }
    }
}
