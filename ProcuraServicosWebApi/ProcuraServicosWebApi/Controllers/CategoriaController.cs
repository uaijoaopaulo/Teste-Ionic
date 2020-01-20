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
    [RoutePrefix("api/Categoria")]
    public class CategoriaController : ApiController
    {
        CategoriaRepository _CR;

        public CategoriaRepository CR
        {
            get
            {
                if (_CR == null)
                    _CR = new CategoriaRepository();
                return _CR;
            }
            set
            {
                _CR = value;
            }
        }

        [HttpGet]
        [Route("SearchAll/{nomeCategoria}")]
        public HttpResponseMessage Get(string nomeCategoria)
        {
            try
            {
                var categorias = CR.GetAll(nomeCategoria);
                return Request.CreateResponse(HttpStatusCode.OK, categorias);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
                throw;
            }
        }

        [HttpGet]
        [Route("Search/{idCategoria}")]
        public HttpResponseMessage Get(int idCategoria)
        {
            try
            {
                var categoria = CR.GetOne(idCategoria);
                return Request.CreateResponse(HttpStatusCode.OK, categoria);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado! " + ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Post(Categoria entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CR.Save(entity);
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado. " + ex.Message);
                    throw;
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Fora dos padrões");
        }

        [HttpPost]
        [Route("Change/{idCategoria}")]
        public HttpResponseMessage Put(int idCategoria, Categoria entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoria = CR.GetOne(idCategoria);

                    entity.id = categoria.id;
                    CR.Save(entity);
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
        [Route("Delete/{idCategoria}")]
        public HttpResponseMessage Delete(int idCategoria)
        {
            try
            {
                CR.Delete(idCategoria);
                return Request.CreateResponse(HttpStatusCode.MovedPermanently);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Não excluido!, " + ex.Message);
                throw;
            }
        }
    }
}
