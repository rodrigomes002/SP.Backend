using System;

namespace SP.Domain.Processos
{
    public class Processo
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;

        public Processo(string nome)
        {
            this.Nome = nome;
        }
    }
}
