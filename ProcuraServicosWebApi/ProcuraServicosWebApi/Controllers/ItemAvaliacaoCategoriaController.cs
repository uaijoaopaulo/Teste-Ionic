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
    public class ItemAvaliacaoCategoriaController : ApiController
    {
        ItemAvaliacaoCategoriaRepository _IACR;

        public ItemAvaliacaoCategoriaRepository IACR
        {
            get
            {
                if (_IACR == null)
                    _IACR = new ItemAvaliacaoCategoriaRepository();
                return _IACR;
            }
            set
            {
                _IACR = value;
            }
        }

        [HttpGet]
        [Route("SearchAll/{idCategoria}")]
        public HttpResponseMessage GetAll(int idCategoria)
        {
            try
            {
                var itens = IACR.GetAll(idCategoria);
                return Request.CreateResponse(HttpStatusCode.OK, itens);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, " Algo esta errado! " + ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("Search/{idItem}")]
        public HttpResponseMessage Get(int idItem)
        {
            try
            {
                var itens = IACR.GetOne(idItem);
                return Request.CreateResponse(HttpStatusCode.OK, itens);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, " Algo esta errado! " + ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Post(ItemAvaliacaoCategoria entity)
        {
            if (ModelState.IsValid)
                try
                {
                    IACR.Save(entity);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, " Algo esta errado! " + ex.Message);
                    throw;
                }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, " Fora do Formato!");
        }

        [HttpPut]
        [Route("Change/{idItem}")]
        public HttpResponseMessage Put(int idItem, ItemAvaliacaoCategoria entity)
        {
            if (ModelState.IsValid)
                try
                {
                    var item = IACR.GetOne(idItem);
                    entity.id = item.id;
                    IACR.Save(entity);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, " Algo esta errado! " + ex.Message);
                    throw;
                }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, " Fora do Formato!");
        }

        [HttpDelete]
        [Route("Delete/{idItem}")]
        public HttpResponseMessage Delete(int idItem)
        {
            try
            {
                IACR.Delete(idItem);
                return Request.CreateResponse(HttpStatusCode.OK + ". Item Desativado com sucesso! ");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + ". Não foi possivel desativar o usuario => " + ex);
            }
        }
    }
}
