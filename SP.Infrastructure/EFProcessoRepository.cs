using Microsoft.EntityFrameworkCore;
using SP.Domain.Processos;
using SP.Domain.Processos.Interface;
using SP.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace SP.Infrastructure
{
    public class EFProcessoRepository : ProcessoRepository
    {
        private readonly ApplicationContext context;
        public EFProcessoRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public void Atualizar(Processo processo)
        {
            this.context.Processos.Update(processo);
        }

        public void Cadastrar(Processo processo)
        {
            this.context.Processos.Add(processo);
        }

        public Processo ListarPorId(long id)
        {
            return this.context.Processos.AsNoTracking().Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Processo> ListarTodos()
        {
            return context.Processos.AsNoTracking().ToList();
        }
    }
}