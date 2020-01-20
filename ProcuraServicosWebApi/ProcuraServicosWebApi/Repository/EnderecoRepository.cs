using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class EnderecoRepository : BaseRepository
    {
        public List<Endereco> GetAll(int id)
        {
            return DataModel.Endereco.Where(e => e.id_conta == id).ToList();
        }
        public Endereco GetOneById(int id)
        {
            return DataModel.Endereco.FirstOrDefault(e => e.Id == id);
        }
        /*public Endereco GetOneByIdConta(int id)
        {
            return DataModel.Endereco.FirstOrDefault(e => e.id_conta == id);
        }*/
        /*public Endereco GetOneByCEP(int CEP)
        {
            return DataModel.Endereco.FirstOrDefault(e => e.cep == CEP);
        }*/
        public void Save(Endereco entity)
        {
            DataModel.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
            DataModel.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = GetOneById(id);
            DataModel.Endereco.Remove(entity);
            DataModel.SaveChanges();
        }
    }
}