using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class TelefoneRepository : BaseRepository
    {
        public List<Telefone> GetAll()
        {
            return DataModel.Telefone.ToList();
        }
        public Telefone GetOneById(int entity)
        {
            return DataModel.Telefone.FirstOrDefault(e => e.id == entity);
        }
        public Telefone GetOneByIdConta(int entity)
        {
            return DataModel.Telefone.FirstOrDefault(e => e.id_conta == entity);
        }
        public void Save(Telefone entity)
        {
            DataModel.Entry(entity).State = entity.id == 0 ? EntityState.Added : EntityState.Modified;
            DataModel.SaveChanges();
        }
        public void Delete(int entity)
        {
            var GTelefone = GetOneById(entity);
            DataModel.Telefone.Remove(GTelefone);
            DataModel.SaveChanges();
        }
    }
}