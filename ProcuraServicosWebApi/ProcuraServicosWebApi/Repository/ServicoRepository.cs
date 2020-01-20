using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class ServicoRepository : BaseRepository
    {
        public List<Servico> GetAll()
        {
            return DataModel.Servico.ToList();
        }
        public List<Servico> GetAll(string entity)
        {
            return DataModel.Servico.Where(e => e.nome == entity || e.descricao.Contains(entity)).ToList();
        }
        public Servico GetOneById(int id)
        {
            return DataModel.Servico.FirstOrDefault(e => e.Id == id);
        }
        public Servico GetOneByIdUsuario(int id)
        {
            return DataModel.Servico.FirstOrDefault(e => e.id_usuario == id);
        }
        public void Save(Servico entity)
        {
            DataModel.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
            DataModel.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = GetOneById(id);
            entity.status = false;
            Save(entity);
        }
    }
}