using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
	public class EF : DbContext
	{
		public DbSet<Artikal> Artikals { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Artikal>().HasKey(a => a.Sifra);
			//modelBuilder.Entity<Artikal>().HasRequired(a => a.Naziv);
			//modelBuilder.Entity<Artikal>().HasIndex(a => a.Naziv);
		}
	}
}
