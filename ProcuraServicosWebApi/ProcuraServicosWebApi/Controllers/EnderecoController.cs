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
    [RoutePrefix("api/Endereco")]
    public class EnderecoController : ApiController
    {
        EnderecoRepository _ER;

        public EnderecoRepository ER
        {
            get
            {
                if (_ER == null)
                    _ER = new EnderecoRepository();
                return _ER;
            }
            set
            {
                _ER = value;
            }
        }

        [HttpGet]
        [Route("SearchAll/{idConta}")]
        public HttpResponseMessage GetAll(int idConta)
        {
            try
            {
                var enderecos = ER.GetAll(idConta);
                return Request.CreateResponse(HttpStatusCode.OK, enderecos);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado... " + ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("Search/{idEndereco}")]
        public HttpResponseMessage Get(int idEndereco)
        {
            try
            {
                var endereco = ER.GetOneById(idEndereco);
                return Request.CreateResponse(HttpStatusCode.OK, endereco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado..." + ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Post(Endereco entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ER.Save(entity);
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

        [HttpPut]
        [Route("Change/{idEndereco}")]
        public HttpResponseMessage Put(int idEndereco, Endereco entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var endereco = ER.GetOneById(idEndereco);

                    entity.Id = endereco.Id;
                    ER.Save(entity);
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

        [HttpDelete]
        [Route("Delete/{idEndereco}")]
        public HttpResponseMessage Delete(int idEndereco)
        {
            try
            {
                ER.Delete(idEndereco);
                return Request.CreateResponse(HttpStatusCode.OK, "Endereço Deletado");
            }
            catch (Exception ex )
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + " Algo deu errado. " + ex.Message);
                throw;
            }
        }
    }
}
