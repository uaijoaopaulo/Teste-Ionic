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
    [RoutePrefix("api/PessoaJuridica")]
    public class PessoaJuridicaController : ApiController
    {
        PessoaJuridicaRepository _PJR;

        public PessoaJuridicaRepository PJR
        {
            get
            {
                if (_PJR == null)
                    _PJR = new PessoaJuridicaRepository();
                return _PJR;
            }
            set
            {
                _PJR = value;
            }
        }

        // GET: api/PessoaFisica
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        [HttpGet]
        [Route("Search/{idOUcnpj}")]
        public HttpResponseMessage Get(int idOUcnpj)
        {
            try
            {
                var PeJ = PJR.GetOne(idOUcnpj);
                return Request.CreateResponse(HttpStatusCode.OK, PeJ);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, " Algo esta errado! " + ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("Save")]
        public HttpResponseMessage Post(PJ entity)
        {
            if (ModelState.IsValid)
                try
                {
                    PJR.Save(entity);
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
        [Route("Change/{idPJ}")]
        public HttpResponseMessage Put(int idPJ, PJ entity)
        {
            if (ModelState.IsValid)
                try
                {
                    var PeJ = PJR.GetOne(idPJ);
                    entity.id = PeJ.id;
                    PJR.Save(entity);
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
        [Route("Delete/{idPJ}")]
        public HttpResponseMessage Delete(int idPJ)
        {
            try
            {
                PJR.Delete(idPJ);
                return Request.CreateResponse(HttpStatusCode.OK + ". Item Desativado com sucesso! ");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest + ". Não foi possivel desativar o usuario => " + ex);
            }
        }
    }
}
