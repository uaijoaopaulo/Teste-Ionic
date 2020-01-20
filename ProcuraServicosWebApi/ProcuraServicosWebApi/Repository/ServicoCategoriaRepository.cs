using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class ServicoCategoriaRepository : BaseRepository
    {
        public List<Servico_Categoria> GetAll()
        {
            return DataModel.Servico_Categoria.ToList();
        }
        public Servico_Categoria GetOne(int id)
        {
            return DataModel.Servico_Categoria.FirstOrDefault(e => e.id == id);
        }
        public Servico_Categoria GetOneByServico(int id)
        {
            return DataModel.Servico_Categoria.FirstOrDefault(e => e.id_servico == id);
        }
        public Servico_Categoria GetOneByCategoria(int id)
        {
            return DataModel.Servico_Categoria.FirstOrDefault(e => e.id_categoria == id);
        }
        public void Save(Servico_Categoria entity)
        {
            DataModel.Entry(entity).State = entity.id == 0 ? EntityState.Added : EntityState.Modified;
            DataModel.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = GetOne(id);
            DataModel.Servico_Categoria.Remove(entity);
            DataModel.SaveChanges();
        }
    }
}