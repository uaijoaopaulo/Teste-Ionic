using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class CategoriaRepository : BaseRepository
    {
        public List<Categoria> GetAll(string entity)
        {
            return DataModel.Categoria.Where(e => e.nome.Contains(entity) || e.nome == entity).ToList();
        }
        public Categoria GetOne(int id)
        {
            return DataModel.Categoria.FirstOrDefault(e => e.id == id);
        }
        public void Save(Categoria entity)
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