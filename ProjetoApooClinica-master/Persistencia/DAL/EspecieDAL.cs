using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    class Especies
    {
        private EFContext context = new EFContext();
        public IQueryable<Especies> ObterExamesClassificadosPorId()
        {
            return context.Especies.Include(c => c.Consulta).OrderBy(b => b.EspecieId);
        }
        public Exame ObterExamesPorId(long id)
        {
            return context.Exames.Where(f => f.ExameId == id).Include(c => c.Consulta).First();
        }
        public void GravarExame(Exame exame)
        {
            if (exame.ExameId == 0)
            {
                context.Exames.Add(exame);
            }
            else
            {
                context.Entry(exame).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Exame EliminarExamePorId(long id)
        {
            Exame exame = ObterExamesPorId(id);
            context.Exames.Remove(exame);
            context.SaveChanges();
            return exame;
        }
    }
}
