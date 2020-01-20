using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class ContaRepository : BaseRepository
    {
        public List<Conta> GetAll()
        {
            return DataModel.Conta.ToList();
        }
        public Conta GetOne(int id)
        {
            return DataModel.Conta.FirstOrDefault(e => e.Id == id);
        }
        public Conta GetOne(string Nome)
        {
            return DataModel.Conta.FirstOrDefault(e => e.nome == Nome);
        }
        public void Save(Conta entity)
        {
            DataModel.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
            DataModel.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = GetOne(id);
            entity.status = false;
            Save(entity);
        }
    }
}