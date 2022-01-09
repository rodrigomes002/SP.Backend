using System.Collections.Generic;

namespace SP.Domain.Processos.Interface
{
    public interface ProcessoRepository
    {
        IEnumerable<Processo> ListarTodos();
        Processo ListarPorId(long id);
        void Cadastrar(Processo processo);
        void Atualizar(Processo processo);
    }
}
