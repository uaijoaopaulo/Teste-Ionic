using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProcuraServicosWebApi.Models;

namespace ProcuraServicosWebApi.Repository
{
    public class RecomendacaoRepository : BaseRepository
    {
        public List<RecomendacaoUsuario> GetAll()
        {
            return DataModel.RecomendacaoUsuario.ToList();
        }
        public RecomendacaoUsuario GetOneById(int id)
        {
            return DataModel.RecomendacaoUsuario.FirstOrDefault(e => e.id == id);
        }
        public RecomendacaoUsuario GetOneByIdUsuario(int id)
        {
            return DataModel.RecomendacaoUsuario.FirstOrDefault(e => e.id_usuario == id);
        }
        /*public RecomendacaoUsuario GetOneByEmail(string email)
        {
            return DataModel.RecomendacaoUsuario.FirstOrDefault(e => e.email == email);
        }*/
        public void Save(RecomendacaoUsuario entity)
        {
            DataModel.Entry(entity).State = entity.id == 0 ? EntityState.Added : EntityState.Modified;
            DataModel.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = GetOneById(id);
            DataModel.RecomendacaoUsuario.Remove(entity);
            DataModel.SaveChanges();
        }
    }
}