using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class ItemAvaliacaoCategoriaRepository : BaseRepository
    {
        public List<ItemAvaliacaoCategoria> GetAll(int id_categoria)
        {
            return DataModel.ItemAvaliacaoCategoria.Where(e => e.id_categoria == id_categoria).ToList();
        }
        public ItemAvaliacaoCategoria GetOne(int id)
        {
            return DataModel.ItemAvaliacaoCategoria.FirstOrDefault(e => e.id == id);
        }
        public void Save(ItemAvaliacaoCategoria entity)
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