
using Microsoft.EntityFrameworkCore;
using projetointegrador.API.Model;

namespace projetointegrador.API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
			
		public DbSet<Cliente> Cliente { get; set; }

		public DbSet<Endereco> Endereco { get; set; }

	}
}
