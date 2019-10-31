using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AuthServer.Infrastructure.Data.Identity
{


    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = Constants.Roles.Consumer, NormalizedName = Constants.Roles.Consumer.ToUpper() });
            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiResource>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<DateTime>("Created")
                    .HasColumnType("DATETIME2");

                b.Property<string>("Description")
                    .HasColumnType("NVARCHAR(1000)")
                    .HasMaxLength(1000);

                b.Property<string>("DisplayName")
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.Property<bool>("Enabled")
                    .HasColumnType("BIT");

                b.Property<DateTime?>("LastAccessed")
                    .HasColumnType("DATETIME2");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.Property<bool>("NonEditable")
                    .HasColumnType("BIT");

                b.Property<DateTime?>("Updated")
                    .HasColumnType("DATETIME2");

                b.HasKey("Id");

                b.HasIndex("Name")
                    .IsUnique();

                b.ToTable("ApiResources");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiResourceClaim>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ApiResourceId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.HasKey("Id");

                b.HasIndex("ApiResourceId");

                b.ToTable("ApiClaims");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiResourceProperty>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ApiResourceId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Key")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(250)")
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(2000)")
                    .HasMaxLength(2000);

                b.HasKey("Id");

                b.HasIndex("ApiResourceId");

                b.ToTable("ApiProperties");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiScope>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ApiResourceId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Description")
                    .HasColumnType("NVARCHAR(1000)")
                    .HasMaxLength(1000);

                b.Property<string>("DisplayName")
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.Property<bool>("Emphasize")
                    .HasColumnType("BIT");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.Property<bool>("Required")
                    .HasColumnType("BIT");

                b.Property<bool>("ShowInDiscoveryDocument")
                    .HasColumnType("BIT");

                b.HasKey("Id");

                b.HasIndex("ApiResourceId");

                b.HasIndex("Name")
                    .IsUnique();

                b.ToTable("ApiScopes");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiScopeClaim>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ApiScopeId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.HasKey("Id");

                b.HasIndex("ApiScopeId");

                b.ToTable("ApiScopeClaims");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiSecret>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ApiResourceId")
                    .HasColumnType("INTEGER");

                b.Property<DateTime>("Created")
                    .HasColumnType("DATETIME2");

                b.Property<string>("Description")
                    .HasColumnType("NVARCHAR(1000)")
                    .HasMaxLength(1000);

                b.Property<DateTime?>("Expiration")
                    .HasColumnType("DATETIME2");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(250)")
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(4000)")
                    .HasMaxLength(4000);

                b.HasKey("Id");

                b.HasIndex("ApiResourceId");

                b.ToTable("ApiSecrets");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.Client>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("AbsoluteRefreshTokenLifetime")
                    .HasColumnType("INTEGER");

                b.Property<int>("AccessTokenLifetime")
                    .HasColumnType("INTEGER");

                b.Property<int>("AccessTokenType")
                    .HasColumnType("INTEGER");

                b.Property<bool>("AllowAccessTokensViaBrowser")
                    .HasColumnType("BIT");

                b.Property<bool>("AllowOfflineAccess")
                    .HasColumnType("BIT");

                b.Property<bool>("AllowPlainTextPkce")
                    .HasColumnType("BIT");

                b.Property<bool>("AllowRememberConsent")
                    .HasColumnType("BIT");

                b.Property<bool>("AlwaysIncludeUserClaimsInIdToken")
                    .HasColumnType("BIT");

                b.Property<bool>("AlwaysSendClientClaims")
                    .HasColumnType("BIT");

                b.Property<int>("AuthorizationCodeLifetime")
                    .HasColumnType("INTEGER");

                b.Property<bool>("BackChannelLogoutSessionRequired")
                    .HasColumnType("BIT");

                b.Property<string>("BackChannelLogoutUri")
                    .HasColumnType("NVARCHAR(2000)")
                    .HasMaxLength(2000);

                b.Property<string>("ClientClaimsPrefix")
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.Property<string>("ClientId")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.Property<string>("ClientName")
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.Property<string>("ClientUri")
                    .HasColumnType("NVARCHAR(2000)")
                    .HasMaxLength(2000);

                b.Property<int?>("ConsentLifetime")
                    .HasColumnType("INTEGER");

                b.Property<DateTime>("Created")
                    .HasColumnType("DATETIME2");

                b.Property<string>("Description")
                    .HasColumnType("NVARCHAR(1000)")
                    .HasMaxLength(1000);

                b.Property<int>("DeviceCodeLifetime")
                    .HasColumnType("INTEGER");

                b.Property<bool>("EnableLocalLogin")
                    .HasColumnType("BIT");

                b.Property<bool>("Enabled")
                    .HasColumnType("BIT");

                b.Property<bool>("FrontChannelLogoutSessionRequired")
                    .HasColumnType("BIT");

                b.Property<string>("FrontChannelLogoutUri")
                    .HasColumnType("NVARCHAR(2000)")
                    .HasMaxLength(2000);

                b.Property<int>("IdentityTokenLifetime")
                    .HasColumnType("INTEGER");

                b.Property<bool>("IncludeJwtId")
                    .HasColumnType("BIT");

                b.Property<DateTime?>("LastAccessed")
                    .HasColumnType("DATETIME2");

                b.Property<string>("LogoUri")
                    .HasColumnType("NVARCHAR(2000)")
                    .HasMaxLength(2000);

                b.Property<bool>("NonEditable")
                    .HasColumnType("BIT");

                b.Property<string>("PairWiseSubjectSalt")
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.Property<string>("ProtocolType")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.Property<int>("RefreshTokenExpiration")
                    .HasColumnType("INTEGER");

                b.Property<int>("RefreshTokenUsage")
                    .HasColumnType("INTEGER");

                b.Property<bool>("RequireClientSecret")
                    .HasColumnType("BIT");

                b.Property<bool>("RequireConsent")
                    .HasColumnType("BIT");

                b.Property<bool>("RequirePkce")
                    .HasColumnType("BIT");

                b.Property<int>("SlidingRefreshTokenLifetime")
                    .HasColumnType("INTEGER");

                b.Property<bool>("UpdateAccessTokenClaimsOnRefresh")
                    .HasColumnType("BIT");

                b.Property<DateTime?>("Updated")
                    .HasColumnType("DATETIME2");

                b.Property<string>("UserCodeType")
                    .HasColumnType("NVARCHAR(100)")
                    .HasMaxLength(100);

                b.Property<int?>("UserSsoLifetime")
                    .HasColumnType("INTEGER");

                b.HasKey("Id");

                b.HasIndex("ClientId")
                    .IsUnique();

                b.ToTable("Clients");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientClaim>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ClientId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(250)")
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(250)")
                    .HasMaxLength(250);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientClaims");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientCorsOrigin>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ClientId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Origin")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(150)")
                    .HasMaxLength(150);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientCorsOrigins");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientGrantType>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ClientId")
                    .HasColumnType("INTEGER");

                b.Property<string>("GrantType")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(250)")
                    .HasMaxLength(250);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientGrantTypes");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientIdPRestriction>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ClientId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Provider")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientIdPRestrictions");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientPostLogoutRedirectUri>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ClientId")
                    .HasColumnType("INTEGER");

                b.Property<string>("PostLogoutRedirectUri")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(2000)")
                    .HasMaxLength(2000);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientPostLogoutRedirectUris");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientProperty>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ClientId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Key")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(250)")
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(2000)")
                    .HasMaxLength(2000);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientProperties");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientRedirectUri>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ClientId")
                    .HasColumnType("INTEGER");

                b.Property<string>("RedirectUri")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(2000)")
                    .HasMaxLength(2000);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientRedirectUris");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientScope>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ClientId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Scope")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientScopes");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientSecret>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("ClientId")
                    .HasColumnType("INTEGER");

                b.Property<DateTime>("Created")
                    .HasColumnType("DATETIME2");

                b.Property<string>("Description")
                    .HasColumnType("NVARCHAR(2000)")
                    .HasMaxLength(2000);

                b.Property<DateTime?>("Expiration")
                    .HasColumnType("DATETIME2");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(250)")
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(4000)")
                    .HasMaxLength(4000);

                b.HasKey("Id");

                b.HasIndex("ClientId");

                b.ToTable("ClientSecrets");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.IdentityClaim>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("IdentityResourceId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.HasKey("Id");

                b.HasIndex("IdentityResourceId");

                b.ToTable("IdentityClaims");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.IdentityResource>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<DateTime>("Created")
                    .HasColumnType("DATETIME2");

                b.Property<string>("Description")
                    .HasColumnType("NVARCHAR(1000)")
                    .HasMaxLength(1000);

                b.Property<string>("DisplayName")
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.Property<bool>("Emphasize")
                    .HasColumnType("BIT");

                b.Property<bool>("Enabled")
                    .HasColumnType("BIT");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(200)")
                    .HasMaxLength(200);

                b.Property<bool>("NonEditable")
                    .HasColumnType("BIT");

                b.Property<bool>("Required")
                    .HasColumnType("BIT");

                b.Property<bool>("ShowInDiscoveryDocument")
                    .HasColumnType("BIT");

                b.Property<DateTime?>("Updated")
                    .HasColumnType("DATETIME2");

                b.HasKey("Id");

                b.HasIndex("Name")
                    .IsUnique();

                b.ToTable("IdentityResources");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.IdentityResourceProperty>( b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<int>("IdentityResourceId")
                    .HasColumnType("INTEGER");

                b.Property<string>("Key")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(250)")
                    .HasMaxLength(250);

                b.Property<string>("Value")
                    .IsRequired()
                    .HasColumnType("NVARCHAR(2000)")
                    .HasMaxLength(2000);

                b.HasKey("Id");

                b.HasIndex("IdentityResourceId");

                b.ToTable("IdentityProperties");
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiResourceClaim>( b =>
            {
                b.HasOne(d => d.ApiResource)
                    .WithMany(p=>p.UserClaims)
                    .HasForeignKey(d=>d.ApiResourceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiResourceProperty>( b =>
            {
                b.HasOne(d=>d.ApiResource)
                    .WithMany(p=>p.Properties)
                    .HasForeignKey(d=>d.ApiResourceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiScope>( b =>
            {
                b.HasOne(d=>d.ApiResource)
                    .WithMany(p=>p.Scopes)
                    .HasForeignKey(d=>d.ApiResourceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiScopeClaim>( b =>
            {
                b.HasOne(d=>d.ApiScope)
                    .WithMany(p=>p.UserClaims)
                    .HasForeignKey(d=>d.ApiScopeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ApiSecret>( b =>
            {
                b.HasOne(d=>d.ApiResource)
                    .WithMany(p=>p.Secrets)
                    .HasForeignKey(d=>d.ApiResourceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientClaim>( b =>
            {
                b.HasOne(d=>d.Client)
                    .WithMany(p=>p.Claims)
                    .HasForeignKey(d=>d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientCorsOrigin>( b =>
            {
                b.HasOne(d=>d.Client)
                    .WithMany(p=>p.AllowedCorsOrigins)
                    .HasForeignKey(d=>d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientGrantType>( b =>
            {
                b.HasOne(d=>d.Client)
                    .WithMany(p=>p.AllowedGrantTypes)
                    .HasForeignKey(d=>d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientIdPRestriction>( b =>
            {
                b.HasOne(d=>d.Client)
                    .WithMany(p=>p.IdentityProviderRestrictions)
                    .HasForeignKey(d=>d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientPostLogoutRedirectUri>( b =>
            {
                b.HasOne(d=>d.Client)
                    .WithMany(p=>p.PostLogoutRedirectUris)
                    .HasForeignKey(d=>d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientProperty>( b =>
            {
                b.HasOne(d=>d.Client)
                    .WithMany(p=>p.Properties)
                    .HasForeignKey(d=>d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientRedirectUri>( b =>
            {
                b.HasOne(d=>d.Client)
                    .WithMany(p=>p.RedirectUris)
                    .HasForeignKey(d=>d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientScope>( b =>
            {
                b.HasOne(d=>d.Client)
                    .WithMany(p=>p.AllowedScopes)
                    .HasForeignKey(d=>d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.ClientSecret>( b =>
            {
                b.HasOne(d=>d.Client)
                    .WithMany(p=>p.ClientSecrets)
                    .HasForeignKey(d=>d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.IdentityClaim>( b =>
            {
                b.HasOne(d=>d.IdentityResource)
                    .WithMany(p=>p.UserClaims)
                    .HasForeignKey(d=>d.IdentityResourceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityServer4.EntityFramework.Entities.IdentityResourceProperty>( b =>
            {
                b.HasOne(d=>d.IdentityResource)
                    .WithMany(p=>p.Properties)
                    .HasForeignKey(d=>d.IdentityResourceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
        }
    }
}
