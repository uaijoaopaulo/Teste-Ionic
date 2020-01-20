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
    [RoutePrefix("api/PessoaFisica")]
    public class PessoaFisicaController : ApiController
    {
        PessoaFisicaRepository _PFR;
        public PessoaFisicaRepository PFR
        {
            get
            {
                if (_PFR == null)
                    _PFR = new PessoaFisicaRepository();
                return _PFR;
            }
            set
            {
                _PFR = value;
            }
        }

        // GET: api/PessoaFisica
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        [HttpGet]
        [Route("Search/{idOUcpf}")]
        public HttpResponseMessage Get(int idOUcpf)
        {
            try
            {
                var PeF = PFR.GetOne(idOUcpf);
                return Request.CreateResponse(HttpStatusCode.OK, PeF);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, " Algo esta errado! " + ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Post(PF entity)
        {
            if (ModelState.IsValid)
                try
                {
                    PFR.Save(entity);
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
        [Route("Change/{idPF}")]
        public HttpResponseMessage Put(int idPF, PF entity)
        {
            if (ModelState.IsValid)
                try
                {
                    var PeF = PFR.GetOne(idPF);
                    entity.id = PeF.id;
                    PFR.Save(entity);
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
        [Route("Delete/{idPf}")]
        public HttpResponseMessage Delete(int idPF)
        {
            try
            {
                PFR.Delete(idPF);
                return Request.CreateResponse(HttpStatusCode.OK + ". Item Desativado com sucesso! ");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + ". Não foi possivel desativar o usuario => " + ex);
            }
        }
    }
}
