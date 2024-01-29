using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RizzGamingBase.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=AppDbContext")
		{
		}

		public virtual DbSet<BillDetail> BillDetails { get; set; }
		public virtual DbSet<Comment> Comments { get; set; }
		public virtual DbSet<Developer> Developers { get; set; }
		public virtual DbSet<DiscountItem> DiscountItems { get; set; }
		public virtual DbSet<Discount> Discounts { get; set; }
		public virtual DbSet<DLC> DLCs { get; set; }
		public virtual DbSet<Game> Games { get; set; }
		public virtual DbSet<GameTag> GameTags { get; set; }
		public virtual DbSet<Image> Images { get; set; }
		public virtual DbSet<Member> Members { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }
		public virtual DbSet<Video> Videos { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Developer>()
				.HasMany(e => e.Games)
				.WithRequired(e => e.Developer)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Discount>()
				.HasMany(e => e.DiscountItems)
				.WithRequired(e => e.Discount)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Game>()
				.HasMany(e => e.Comments)
				.WithRequired(e => e.Game)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Game>()
				.HasMany(e => e.DiscountItems)
				.WithRequired(e => e.Game)
				.WillCascadeOnDelete(false);

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
				.HasOptional(e => e.Games1)
				.WithRequired(e => e.Game1);

			modelBuilder.Entity<Game>()
				.HasMany(e => e.GameTags)
				.WithRequired(e => e.Game)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Game>()
				.HasMany(e => e.Images)
				.WithRequired(e => e.Game)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Game>()
				.HasMany(e => e.Videos)
				.WithRequired(e => e.Game)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.Comments)
				.WithRequired(e => e.Member)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Tag>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Tag>()
				.HasMany(e => e.GameTags)
				.WithRequired(e => e.Tag)
				.WillCascadeOnDelete(false);
		}

        public System.Data.Entity.DbSet<RizzGamingBase.Models.ViewModels.DeveloperGameEditVm> DeveloperGameEditVms { get; set; }

        public System.Data.Entity.DbSet<RizzGamingBase.Models.ViewModels.GameIndexVm> GameIndexVms { get; set; }
    }
}
