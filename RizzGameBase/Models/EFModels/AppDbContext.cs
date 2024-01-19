using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RizzGameBase.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=AppDbContext")
		{
		}

		public virtual DbSet<DLC> DLCs { get; set; }
		public virtual DbSet<Game> Games { get; set; }
		public virtual DbSet<GameTag> GameTags { get; set; }
		public virtual DbSet<Image> Images { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Game>()
				.HasMany(e => e.DLCs)
				.WithRequired(e => e.Game)
				.HasForeignKey(e => e.AttachmentGameId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Game>()
				.HasMany(e => e.DLCs1)
				.WithRequired(e => e.Game1)
				.HasForeignKey(e => e.GameId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Game>()
				.HasMany(e => e.GameTags)
				.WithRequired(e => e.Game)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Game>()
				.HasMany(e => e.Images)
				.WithRequired(e => e.Game)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tag>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Tag>()
				.HasMany(e => e.GameTags)
				.WithRequired(e => e.Tag)
				.WillCascadeOnDelete(false);
		}
	}
}
