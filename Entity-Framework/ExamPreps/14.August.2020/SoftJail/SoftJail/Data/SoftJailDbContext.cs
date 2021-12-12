namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
	{
		public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}
		public DbSet<Cell> Cells { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Mail> Mails { get; set; }
		public DbSet<Officer> Officers { get; set; }
		public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
		public DbSet<Prisoner> Prisoners { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<OfficerPrisoner>()
				.HasKey(x => new { x.PrisonerId, x.OfficerId });

			

				//FK_OfficersPrisoners_Prisoners_PrisonerId". 

			//builder.Entity<Mail>()
			//	.HasOne(x => x.Prisoner)
			//	.WithMany(x => x.Mails)
			//	.HasForeignKey(x => x.PrisonerId);

			//builder.Entity<Prisoner>()
			//	.HasMany(x => x.Mails)
			//	.WithOne(x => x.Prisoner)
			//	.HasForeignKey(x => x.PrisonerId);
		}
	}
}