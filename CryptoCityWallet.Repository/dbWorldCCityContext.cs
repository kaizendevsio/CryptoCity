using System;
using CryptoCityWallet.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CryptoCityWallet.Repository
{
    public partial class dbWorldCCityContext : DbContext
    {
        public dbWorldCCityContext()
        {
        }

        public dbWorldCCityContext(DbContextOptions<dbWorldCCityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAddressCity> TblAddressCity { get; set; }
        public virtual DbSet<TblAddressCountry> TblAddressCountry { get; set; }
        public virtual DbSet<TblAppSystem> TblAppSystem { get; set; }
        public virtual DbSet<TblAuditFields> TblAuditFields { get; set; }
        public virtual DbSet<TblCurrency> TblCurrency { get; set; }
        public virtual DbSet<TblExchangeRate> TblExchangeRate { get; set; }
        public virtual DbSet<TblIncomeType> TblIncomeType { get; set; }
        public virtual DbSet<TblUserAddress> TblUserAddress { get; set; }
        public virtual DbSet<TblUserAuth> TblUserAuth { get; set; }
        public virtual DbSet<TblUserAuthHistory> TblUserAuthHistory { get; set; }
        public virtual DbSet<TblUserIncomeTransaction> TblUserIncomeTransaction { get; set; }
        public virtual DbSet<TblUserInfo> TblUserInfo { get; set; }
        public virtual DbSet<TblUserMap> TblUserMap { get; set; }
        public virtual DbSet<TblUserRole> TblUserRole { get; set; }
        public virtual DbSet<TblUserWallet> TblUserWallet { get; set; }
        public virtual DbSet<TblUserWalletAddress> TblUserWalletAddress { get; set; }
        public virtual DbSet<TblUserWalletTransaction> TblUserWalletTransaction { get; set; }
        public virtual DbSet<TblUserWithdrawalRequest> TblUserWithdrawalRequest { get; set; }
        public virtual DbSet<TblWalletType> TblWalletType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=dbWorldCCity;Username=dbAdmin;Password=Jr2Ge4FvY!=Z5u!^");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TblAddressCity>(entity =>
            {
                entity.ToTable("tbl_AddressCity", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Latitude).HasColumnType("numeric(18,10)");

                entity.Property(e => e.Longitude).HasColumnType("numeric(18,10)");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.PostalCode).HasMaxLength(16);
            });

            modelBuilder.Entity<TblAddressCountry>(entity =>
            {
                entity.ToTable("tbl_AddressCountry", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.IsoCode2).HasMaxLength(2);

                entity.Property(e => e.IsoCode3).HasMaxLength(3);

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblAppSystem>(entity =>
            {
                entity.ToTable("tbl_AppSystem", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PublicByte).IsRequired();

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblAuditFields>(entity =>
            {
                entity.ToTable("tbl_AuditFields", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<TblCurrency>(entity =>
            {
                entity.ToTable("tbl_Currency", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CurrencyIsoCode3)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TblExchangeRate>(entity =>
            {
                entity.ToTable("tbl_ExchangeRate", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.EffectivityDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ExpiryDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Fee).HasColumnType("numeric(18,10)");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.SourceCurrencyId).HasColumnName("SourceCurrencyID");

                entity.Property(e => e.TargetCurrencyId).HasColumnName("TargetCurrencyID");

                entity.Property(e => e.Value).HasColumnType("numeric(18,10)");

                entity.HasOne(d => d.SourceCurrency)
                    .WithMany(p => p.TblExchangeRateSourceCurrency)
                    .HasForeignKey(d => d.SourceCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SourceCurrencyID");

                entity.HasOne(d => d.TargetCurrency)
                    .WithMany(p => p.TblExchangeRateTargetCurrency)
                    .HasForeignKey(d => d.TargetCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TargetCurrencyID");
            });

            modelBuilder.Entity<TblIncomeType>(entity =>
            {
                entity.ToTable("tbl_IncomeType", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.IncomePercentage).HasColumnType("numeric(18,10)");

                entity.Property(e => e.IncomeShortName).HasMaxLength(50);

                entity.Property(e => e.IncomeTypeCode)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.IncomeTypeDescription).HasMaxLength(500);

                entity.Property(e => e.IncomeTypeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<TblUserAddress>(entity =>
            {
                entity.ToTable("tbl_UserAddress", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.CountryIsoCode2).HasMaxLength(2);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.PostalCode).HasMaxLength(50);

                entity.Property(e => e.StateName).HasColumnType("bit varying(50)[]");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserAddress)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblUserAuth>(entity =>
            {
                entity.ToTable("tbl_UserAuth", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.PasswordByte).HasMaxLength(500);

                entity.Property(e => e.ResetPasswordCodeExpiration).HasColumnType("timestamp with time zone");

                entity.Property(e => e.TemporaryPassword).HasMaxLength(256);

                entity.Property(e => e.UserAlias).HasMaxLength(256);

                entity.Property(e => e.UserInfoId).HasColumnName("UserInfoID");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.UserInfo)
                    .WithMany(p => p.TblUserAuth)
                    .HasForeignKey(d => d.UserInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tbl_UserAuth_UserInfoID_fkey");
            });

            modelBuilder.Entity<TblUserAuthHistory>(entity =>
            {
                entity.ToTable("tbl_UserAuthHistory", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.DeviceName).HasMaxLength(50);

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(18);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LoginSource).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UserAuthId).HasColumnName("UserAuthID");
            });

            modelBuilder.Entity<TblUserIncomeTransaction>(entity =>
            {
                entity.ToTable("tbl_UserIncomeTransaction", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.IncomePercentage).HasColumnType("numeric(18,10)");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserIncomeTransaction)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblUserInfo>(entity =>
            {
                entity.ToTable("tbl_UserInfo", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.ConfirmedEmail).HasMaxLength(50);

                entity.Property(e => e.CountryIsoCode2).HasMaxLength(2);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.PhoneNumber).HasMaxLength(24);

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasColumnName("UID")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblUserMap>(entity =>
            {
                entity.ToTable("tbl_UserMap", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.SponsorUserId).HasMaxLength(100);

                entity.Property(e => e.UplineUserId).HasMaxLength(100);

                entity.Property(e => e.UserUid)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TblUserMap)
                    .HasForeignKey<TblUserMap>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblUserRole>(entity =>
            {
                entity.ToTable("tbl_UserRole", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.AccessRole).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UserAuthId).HasColumnName("UserAuthID");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserRole)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tbl_UserRole_UserAuthID_fkey");
            });

            modelBuilder.Entity<TblUserWallet>(entity =>
            {
                entity.ToTable("tbl_UserWallet", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Balance).HasColumnType("numeric(24,8)");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserWallet)
                    .HasForeignKey(d => d.UserAuthId)
                    .HasConstraintName("tbl_UserWallet_UserAuthId_fkey");

                entity.HasOne(d => d.WalletType)
                    .WithMany(p => p.TblUserWallet)
                    .HasForeignKey(d => d.WalletTypeId)
                    .HasConstraintName("tbl_UserWallet_WalletTypeId_fkey");
            });

            modelBuilder.Entity<TblUserWalletAddress>(entity =>
            {
                entity.ToTable("tbl_UserWalletAddress", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Address).HasMaxLength(512);

                entity.Property(e => e.Balance).HasColumnType("numeric(18,10)");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.CurrencyIsoCode3).HasMaxLength(3);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserWalletAddress)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblUserWalletTransaction>(entity =>
            {
                entity.ToTable("tbl_UserWalletTransaction", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("numeric(18,10)");

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserWalletTransaction)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblUserWithdrawalRequest>(entity =>
            {
                entity.ToTable("tbl_UserWithdrawalRequest", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Remarks).HasColumnType("bit varying(500)");

                entity.Property(e => e.TotalAmount).HasColumnType("numeric(18,10)");

                entity.HasOne(d => d.UserAuth)
                    .WithMany(p => p.TblUserWithdrawalRequest)
                    .HasForeignKey(d => d.UserAuthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAuthID");
            });

            modelBuilder.Entity<TblWalletType>(entity =>
            {
                entity.ToTable("tbl_WalletType", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.CreatedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Desc).HasMaxLength(500);

                entity.Property(e => e.LastChanged).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ModifiedOn).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
