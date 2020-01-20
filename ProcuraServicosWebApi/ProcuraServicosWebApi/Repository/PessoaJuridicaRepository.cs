using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class PessoaJuridicaRepository : BaseRepository
    {
        /*public List<PJ> GetAll()
        {
            return DataModel.PJ.ToList();
        }*/
        public PJ GetOne(int entity)
        {
            return DataModel.PJ.FirstOrDefault(e => e.id == entity || int.Parse(e.cnpj) == entity);
        }
        public void Save(PJ entity)
        {
            DataModel.Entry(entity).State = GetOne(entity.id) == null ? EntityState.Added : EntityState.Modified;
            DataModel.SaveChanges();
        }
        public void Delete(int entity)
        {
            var GPJ = GetOne(entity);
            DataModel.PJ.Remove(GPJ);
            DataModel.SaveChanges();
        }
    }
}