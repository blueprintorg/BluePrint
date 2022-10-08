namespace BluePrint.Idm.DataAccess.Persistence.Context
{
    using BluePrint.Idm.Model.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{BluePrint.Idm.Model.Entities.UserEntity, BluePrint.Idm.Model.Entities.RoleEntity, System.Int32, BluePrint.Idm.Model.Entities.UserClaimEntity, BluePrint.Idm.Model.Entities.UserRoleEntity, BluePrint.Idm.Model.Entities.UserLoginEntity, BluePrint.Idm.Model.Entities.RoleClaimEntity, BluePrint.Idm.Model.Entities.UserTokenEntity}" />
    public class IdmContext : IdentityDbContext<UserEntity,RoleEntity,int, 
        UserClaimEntity,
        UserRoleEntity,
        UserLoginEntity,
        RoleClaimEntity,
        UserTokenEntity>
    {
        public DbSet<CityEntity> Cities { get; set; }

        public DbSet<CompanyEntity> Companies { get; set; }

        public DbSet<CompanyLocationEntity> CompanyLocations { get; set; }

        public DbSet<CompanyPartnerEntity> CompanyPartners { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }

        public DbSet<DistrictEntity> Districts { get; set; }

        public DbSet<NeighborhoodEntity> Neighborhoods { get; set; }

        public DbSet<PartnerEntity> Partners { get; set; }

        public DbSet<ResetPasswordEntity> ResetPasswords { get; set; }

        public DbSet<TownEntity> Towns { get; set; }
  



        /// <summary>
        /// Initializes a new instance of the <see cref="IdmContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public IdmContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
    }
}
