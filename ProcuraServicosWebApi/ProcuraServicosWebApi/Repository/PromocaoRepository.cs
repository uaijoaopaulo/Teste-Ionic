using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class PromocaoRepository : BaseRepository
    {
        public List<Promocao> GetAll(int id)
        {
            return DataModel.Promocao.Where(e => e.id_servico == id).ToList();
        }
        public Promocao GetOne(int id)
        {
            return DataModel.Promocao.FirstOrDefault(e => e.id == id);
        }
        public void Save(Promocao entity)
        {
            DataModel.Entry(entity).State = entity.id == 0 ? EntityState.Added : EntityState.Modified;
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