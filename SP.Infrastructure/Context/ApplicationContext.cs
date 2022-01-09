using Microsoft.EntityFrameworkCore;
using SP.Domain.Processos;

namespace SP.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Processo> Processos { get; set; }

    }
}
