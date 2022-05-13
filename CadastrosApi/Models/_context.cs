using Microsoft.EntityFrameworkCore;

namespace CadastrosApi.Models
{
    public class _context : DbContext
    {
        public _context(DbContextOptions<_context> options) 
            : base(options)
        {

        }

        public DbSet<CadastrarUsuario> Usuarios { get; set; }
    }
}
