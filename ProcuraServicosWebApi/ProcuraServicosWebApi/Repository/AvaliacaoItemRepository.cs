using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class AvaliacaoItemRepository : BaseRepository
    {
        public List<AvaliacaoItem> GetAll(int id_itemavaliacaocategoria)
        {
            return DataModel.AvaliacaoItem.Where(e => e.id_itemavaliacaocategoria == id_itemavaliacaocategoria).ToList();
        }
        public AvaliacaoItem GetOne(int id)
        {
            return DataModel.AvaliacaoItem.FirstOrDefault(e => e.Id == id);
        }
        public void Save(AvaliacaoItem entity)
        {
            DataModel.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
            DataModel.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = GetOne(id);
            DataModel.AvaliacaoItem.Remove(entity);
            DataModel.SaveChanges();
        }
    }
}