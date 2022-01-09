using SP.Application.Processos.DTO;
using SP.Domain;
using SP.Domain.Processos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SP.Application.Processos
{
    public class ProcessoService
    {
        private readonly UnitOfWork unitOfWork;
        public ProcessoService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Atualizar(ProcessoDTO requisicao)
        {
            var processo = this.unitOfWork.ProcessoRepository.ListarPorId(requisicao.Id);

            if (processo is null)
            {
                throw new Exception("Processo não encontrado.");
            }

            processo.Nome = requisicao.Nome;
            this.unitOfWork.ProcessoRepository.Atualizar(processo);
            this.unitOfWork.Commit();
        }

        public void Cadastrar(ProcessoDTO requisicao)
        {
            var processo = new Processo(requisicao.Nome);
            this.unitOfWork.ProcessoRepository.Cadastrar(processo);
            this.unitOfWork.Commit();
        }

        public ProcessoDTO ListarPorId(long id)
        {
            var processo = this.unitOfWork.ProcessoRepository.ListarPorId(id);

            if (processo is null)
            {
                throw new Exception("Processo não encontrado.");
            }

            var dto = new ProcessoDTO() { Id = processo.Id, Nome = processo.Nome };
            return dto;
        }

        public IEnumerable<ProcessoDTO> ListarTodos()
        {
            var processos = this.unitOfWork.ProcessoRepository.ListarTodos();
            var resultado = processos.Select(processo => new ProcessoDTO { Id = processo.Id, Nome = processo.Nome });
            return resultado;
        }
    }
}
