using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class PessoaFisicaRepository : BaseRepository
    {
        public PF GetOne(int entity)
        {
            return DataModel.PF.FirstOrDefault(e => e.id == entity || int.Parse(e.cpf) == entity);
        }
        public void Save(PF entity)
        {
            DataModel.Entry(entity).State = GetOne(entity.id) == null ? EntityState.Added : EntityState.Modified;
            DataModel.SaveChanges();
        }
        public void Delete(int entity)
        {
            var GPF = GetOne(entity);
            DataModel.PF.Remove(GPF);
            DataModel.SaveChanges();
        }
    }
}