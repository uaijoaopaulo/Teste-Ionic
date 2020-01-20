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
    [RoutePrefix("api/Promocao")]
    public class PromocaoController : ApiController
    {
        PromocaoRepository _PR;

        public PromocaoRepository PR
        {
            get
            {
                if (_PR == null)
                    _PR = new PromocaoRepository();
                return _PR;
            }
            set
            {
                _PR = value;
            }
        }

        [HttpGet]
        [Route("Search/{idProduto}")]
        public HttpResponseMessage GetAll(int idProduto)
        {
            try
            {
                var promocao = PR.GetAll(idProduto);
                return Request.CreateResponse(HttpStatusCode.OK, promocao);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("Search/{idPromocao}")]
        public HttpResponseMessage Get(int idPromocao)
        {
            try
            {
                var promocao = PR.GetAll(idPromocao);
                return Request.CreateResponse(HttpStatusCode.OK, promocao);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Post(Promocao promocao)
        {
            try
            {
                PR.Save(promocao);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                throw;
            }
        }

        [HttpPut]
        [Route("Change/{idPromocao}")]
        public HttpResponseMessage Put(int idPromocao, Promocao entity)
        {
            try
            {
                var promocao = PR.GetOne(idPromocao);
                entity.id = promocao.id;
                PR.Save(entity);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                throw;
            }
        }

        [HttpDelete]
        [Route("Delete/{idPromocao}")]
        public HttpResponseMessage Delete(int idPromocao)
        {
            try
            {
                PR.Delete(idPromocao);
                return Request.CreateResponse(HttpStatusCode.OK + " Promoção Deletada!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                throw;
            }
        }
    }
}
