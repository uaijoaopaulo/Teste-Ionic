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
    [RoutePrefix("api/Servico")]
    public class ServicoController : ApiController
    {
        ServicoRepository _SR;

        public ServicoRepository SR
        {
            get
            {
                if (_SR == null)
                    _SR = new ServicoRepository();
                return _SR;
            }
            set
            {
                _SR = value;
            }
        }

        [HttpGet]
        [Route("Search")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var servico = SR.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, servico);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + ". Erro ao pesquisar: " + ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("Search/{idServico}")]
        public HttpResponseMessage Get(int idServico)
        {
            try
            {
                var servico = SR.GetOneById(idServico);
                return Request.CreateResponse(HttpStatusCode.OK, servico);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + ". Erro ao pesquisar: " + ex.Message);
                throw;
            }
        }

        // POST: api/Servico
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Servico/5
        public void Put(int id, Servico entity)
        {
            
        }

        // DELETE: api/Servico/5
        public void Delete(int id)
        {
        }
    }
}
