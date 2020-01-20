using ProcuraServicosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProcuraServicosWebApi.Repository
{
    public class AvaliacaoRepository : BaseRepository
    {
        public List<Avaliacao> GetAll(string funcao, int id)
        {
            if (funcao.Equals("servico"))
                return DataModel.Avaliacao.Where(e => e.id_servico == id).ToList();
            else if (funcao.Equals("avaliacaoitem"))
                return DataModel.Avaliacao.Where(e => e.id_avaliacaoitem == id).ToList();
            else
                return null;
        }
        public Avaliacao GetOne(int id)
        {
            return DataModel.Avaliacao.FirstOrDefault(e => e.id == id);
        }
        public void Save(Avaliacao entity)
        {
            DataModel.Entry(entity).State = entity.id == 0 ? EntityState.Added : EntityState.Modified;
            DataModel.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = GetOne(id);
            DataModel.Avaliacao.Remove(entity);
            DataModel.SaveChanges();
        }
    }
}