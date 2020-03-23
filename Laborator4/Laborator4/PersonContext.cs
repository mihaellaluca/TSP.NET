using Microsoft.EntityFrameworkCore;



namespace Laborator4
{
	public class PersonContext : DbContext
	{
		public PersonContext()
		{
			Database.EnsureCreated();
		}
		public virtual DbSet<Person> People { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<Album> Albums { get; set; }
		public virtual DbSet<Artist> Artists { get; set; }
		public virtual DbSet<ArtistAlbum> ArtistAlbum { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    @"Data Source=(localdb)\ProjectsV13;Initial Catalog=People;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Person>();

			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Order>().HasOne(order => order.customer).WithMany(orders => orders.Orders).IsRequired();

			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<ArtistAlbum>()
				.HasKey(aa => new { aa.ArtistId, aa.AlbumId });

			modelBuilder.Entity<ArtistAlbum>()
				.HasOne(aa => aa.Artist)
				.WithMany(artist => artist.ArtistAlbum)
				.HasForeignKey(aa => aa.ArtistId);

			modelBuilder.Entity<ArtistAlbum>()
				.HasOne(aa => aa.Album)
				.WithMany(album => album.ArtistAlbum)
				.HasForeignKey(aa => aa.AlbumId);
		}
	}
}
