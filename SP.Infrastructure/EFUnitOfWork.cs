using SP.Domain;
using SP.Domain.Processos.Interface;
using SP.Infrastructure.Context;

namespace SP.Infrastructure
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly ApplicationContext context;

        public EFUnitOfWork(ApplicationContext context)
        {
            this.context = context;
            this.ProcessoRepository = new EFProcessoRepository(context);
        }
        public ProcessoRepository ProcessoRepository { get; }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
