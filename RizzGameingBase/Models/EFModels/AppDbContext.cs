using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RizzGameingBase.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		//�s�u�r��
		public AppDbContext()
			: base("name=AppDbContext")
		{
		}

		public virtual DbSet<Member> Members { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
