using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProcuraServicosWebApi.Repository
{
    public class UsuarioRepository : BaseRepository
    {
        public List<Usuario> GetAll()
        {
            return DataModel.Usuario.ToList();
        }
        public Usuario GetOne(int entity)
        {
            return DataModel.Usuario.FirstOrDefault(e => e.id == entity);
        }
        public Usuario GetOne(Usuario entity)
        {
            return DataModel.Usuario.FirstOrDefault(e => e.email == entity.email || e.nickname == entity.nickname);
        }
        public Usuario GetOne(string entity)
        {
            return DataModel.Usuario.FirstOrDefault(e => e.email == entity || e.nickname == entity);
        }
        public bool Logar(Usuario entity)
        {
            if(DataModel.Usuario.Where(e => (e.email == entity.email|| e.nickname == entity.nickname) && e.senha == entity.senha).Count() == 0)
                return false;
            else 
                return true;
        }
        public void Save(Usuario entity)
        {
            DataModel.Entry(entity).State = GetOne(entity.id) == null ? EntityState.Added : EntityState.Modified;
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