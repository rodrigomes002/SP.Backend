using SP.Domain.Processos.Interface;

namespace SP.Domain
{
    public interface UnitOfWork
    {
        ProcessoRepository ProcessoRepository { get; }
        void Commit();
    }
}
