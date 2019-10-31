using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using OCMovers_MC4.Models;

namespace OCMovers_MC4.DAL
{
	public class OCMovers_MVC4Context : DbContext
	{
		public DbSet<Room> Room { get; set; }
		public DbSet<InventoryItem> InventoryItem { get; set; }
		public DbSet<EstimateForm> EstimateForm { get; set; }
		public DbSet<EstimateFormInventory> EstimateFormInventory { get; set; }
        public DbSet<CustomerEstimates> CustomerEstimates { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Content> Content { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<OAuthMembership> OAuthMemberships { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<CustomerAddress> CustomerAddress { get; set; }

		//public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            modelBuilder.Entity<Membership>()
            .HasMany<Role>(r => r.Roles)
            .WithMany(u => u.Members)
            .Map(m =>
            {
                m.ToTable("webpages_UsersInRoles");
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
            });

        }
	}
}