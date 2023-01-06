using MegaMinds_CrudTask.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaMinds_CrudTask.DataContext
{
    public class DataContextClass : DbContext
    {
		protected readonly IConfiguration Configuration;

		public DataContextClass()
		{
		}

		public DataContextClass(DbContextOptions<DataContextClass> options)
			: base(options)
		{
		}

		public DbSet<Details> Details { get; set; }
		public DbSet<City> City { get; set; }
		public DbSet<State> State { get; set; }
	}
}
