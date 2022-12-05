using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Data;

internal class AppDbContext : DbContext
{
	public AppDbContext()
	{

	}

	public AppDbContext(DbContextOptions options) : base(options)
	{

	}

	public DbSet<Crew> Crew { get; set; }
	public DbSet<Rank> Rank { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StarTrekDb;Trusted_Connection=True;");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

	}
}
